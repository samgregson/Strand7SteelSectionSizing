using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Strand7_Steel_Section_Sizing
{
    class Optimisation
    {
        public static void Optimise(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //#####################################################################################

            SetInputs(e);
            DateTime startTime = DateTime.Now;
            init = true;
            stat = "Initialising...";
            stat2 = "opening Strand7 file...";
            stat3 = "Optimisation started at: " + startTime + Environment.NewLine + "Optimising file: " + file;
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

            //#############################################
            //############## Set constants ################
            //#############################################
            #region Set constants

            DampingUp = 1.0;//0.6;
            DampingDown = 1.0;//0.4;
            int iter_max = 50;

            //string builders
            StringBuilder sb = new StringBuilder(100);
            StringBuilder sb_virtual = new StringBuilder(100);

            //file paths
            string sBaseFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), System.IO.Path.GetFileNameWithoutExtension(file));
            optFolder = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), "Optimisation results");
            System.IO.Directory.CreateDirectory(optFolder);
            string sOutPath = System.IO.Path.Combine(optFolder, "Section changes.txt");
            try { System.IO.File.Delete(sOutPath); }
            catch { }
            sSt7LSAPath = sBaseFile + " - optimised.LSA";
            sSt7NLAPath = sBaseFile + " - optimised.NLA";
            sSt7FreqPath = sBaseFile + " - optimised.NFA";
            string sSt7BucPath = sBaseFile + " - optimised.LBA";
            sSt7ResPath = "";
            string sSt7OptimisedPath = sBaseFile + " - optimised.st7";

            //Strand7 model properties
            int iErr;
            iErr = St7.St7Init();
            if (CheckiErr(iErr)) { return; }
            iErr = St7.St7OpenFile(1, file, System.IO.Path.GetTempPath());
            if (CheckiErr(iErr)) { return; }
            int nBeams = new int();
            nNodes = new int();
            iErr = St7.St7GetTotal(1, St7.tyBEAM, ref nBeams);
            if (CheckiErr(iErr)) { return; }
            iErr = St7.St7GetTotal(1, St7.tyNODE, ref nNodes);
            if (CheckiErr(iErr)) { return; }
            int[] NumProperties = new int[St7.kMaxEntityTotals];
            int[] LastProperty = new int[St7.kMaxEntityTotals];
            iErr = St7.St7GetTotalProperties(1, NumProperties, LastProperty);
            if (CheckiErr(iErr)) { return; }
            int nProps = NumProperties[St7.ipBeamPropTotal]; //EDIT
            nProps2 = LastProperty[St7.ipBeamPropTotal]; //EDIT
            int numGroups = 0;
            iErr = St7.St7GetNumGroups(1, ref numGroups);
            int[] units = new int[] { St7.luMETRE, St7.fuNEWTON, St7.suMEGAPASCAL, St7.muKILOGRAM, St7.tuCELSIUS, St7.euJOULE };
            iErr = St7.St7ConvertUnits(1, units);
            if (CheckiErr(iErr)) { return; }
            CollectCSVSections(System.IO.Path.GetDirectoryName(file), numGroups);

            if (nProps2 < 1)
            {
                MessageBox.Show("No beams sections available");
                throw new Exception("No beams sections available.");
                return;
            }

            inc = new double[nProps2];
            incPrev = new double[nProps2];

            beams = new Beam[nBeams];
            beamProperties = new BeamProperty[nProps2];
            
            if (useExisting)
            {
                SetupBeamsAndProperties(false, nBeams, beams);
                foreach (BeamProperty p in beamProperties)
                {
                    int g = p.Group;
                    foreach (Section s in SecLib.GetGroup(g))
                    {
                        if (p.Name == s.Name)
                            p.CurrentSectionInt = s.Number;
                    }
                    if (p != null && p.Optimise)
                    {
                        int ip = p.Number;
                        Section sec = p.CurrentSection;

                        iErr = St7.St7SetBeamSectionGeometry(1, ip, sec.SType, sec.sectionDoubles);
                        if (CheckiErr(iErr)) { return; };

                        iErr = St7.St7CalculateBeamSectionProperties(1, ip, St7.btFalse, St7.btFalse);
                        if (CheckiErr(iErr)) { return; }
                    }
                }
            }
            else
            {
                SetupBeamsAndProperties(true, nBeams, beams);
            }

            maxDeflectionChanges = (int) Math.Round(Convert.ToDouble(beamProperties.Count(p => p.Optimise == true)) * 0.3);
            #endregion

            if (CheckCancel(worker, e)) return;

            StringBuilder sb_debug = new StringBuilder();

            iErr = St7.St7SaveFileTo(1, optFolder + @"\iter 0.st7");
            if (CheckiErr(iErr)) { return; };

            //initial solve and open results file
            stat2 = "setting load cases...";
            stat3 = "";
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
            St7.St7GetNumLoadCase(1, ref NumPrimary);
            if (CheckiErr(iErr)) { return; }
            St7.St7GetNumLSACombinations(1, ref NumSecondary);
            if (CheckiErr(iErr)) { return; }

            //set up load cases if "all" is used
            if (ResList_stress.Count == 0)
            {
                for (int i = 1; i < NumPrimary + NumSecondary; i++) ResList_stress.Add(i);
            }
            if (ResList_def.Count == 0)
            {
                for (int i = 1; i <= NumPrimary + NumSecondary; i++) ResList_def.Add(i);
            }
            foreach (DeflectionLimit d in deflectionLimits)
            {
                if (d.LoadCasesOutput == null)
                { d.LoadCasesOutput = new List<int>(); }
                if (d.LoadCasesOutput.Count == 0)
                {
                    for (int i = 1; i <= NumPrimary + NumSecondary; i++) d.LoadCasesOutput.Add(i);
                }
            }

            if (optDeflections || optFrequency)
            {
                //add 1 to cases as virtual load case will be created
                for (int i = 0; i < ResList_stress.Count; i++)
                {
                    if (ResList_stress[i] > NumPrimary)
                    { ResList_stress[i]++; }
                }
                foreach (DeflectionLimit d in deflectionLimits)
                {
                    for (int i = 0; i < d.LoadCasesOutput.Count; i++)
                    {
                        if (d.LoadCasesOutput[i] > NumPrimary)
                        { d.LoadCasesOutput[i]++; }
                    }
                }
                iErr = St7.St7NewLoadCase(1, "Virtual Load");
                if (CheckiErr(iErr)) { return; }
                iErr = St7.St7GetNumLoadCase(1, ref virtual_case);
                if (CheckiErr(iErr)) { return; }
                iErr = St7.St7EnableLoadCase(1, virtual_case);
                if (CheckiErr(iErr)) { return; }
                if (optFrequency)
                {   //allow beam forces to be collected
                    iErr = St7.St7SetEntityResult(1, St7.frBeamForcePattern, St7.btTrue);
                    if (CheckiErr(iErr)) { return; }
                }
            }

            init = false;
            bool stress_satisfied = true;
            bool deflections_satisfied = true;
            bool frequency_satisfied = true;
            bool[] def_governed = new bool[nBeams];

            WeighStructure(worker, ref stat3);
            stat3 = Environment.NewLine + "Current "+ stat3 +Environment.NewLine;
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

            //####################################
            //############## Loop ################
            //####################################
            for (int iter = 1; iter < iter_max; iter++)
            {
                DampingDown = 1.0;
                int changes = 0;

                string sOutPathVirtualStresses = System.IO.Path.Combine(optFolder, "virtual stresses" + iter.ToString() + ".txt");
                sb_virtual.Append("TITLE Virtual stresses\n");
                looping = true;
                stat = "Iteration: " + iter.ToString();
                stat2 = "";
                stat3 = Environment.NewLine + "########## ITERATION: " + iter.ToString() + " ##########";
                if (changed > 0) { stat2 = changed.ToString() + " changes in previous iteration"; }
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                //###################################
                //####### Optimise Stresses #########
                //###################################
                ///optimise stresses loop
                ///     solve
                ///     collect results
                ///     choose sections
                ///     update sections
                ///     iterate
                if (optStresses)
                { OptStresses(worker, e, ref iter, ref stress_satisfied, ref changes); }

                changes = 0;

                //######################################
                //####### Optimise Deflections #########
                //######################################
                //optimise deflections loop
                ///     collect deflection results
                ///     apply unit force
                ///     solve
                ///     choose sections
                ///     update sections
                ///     iterate
                if (optDeflections)
                {
                    bool[] defStatisfied = new bool[deflectionLimits.Count];
                    deflections_satisfied = false;

                    int running_changes = 0;
                    while (running_changes < maxDeflectionChanges && deflections_satisfied==false)
                    {
                        deflections_satisfied = true;
                        for (int i = 0; i< deflectionLimits.Count; i++)
                        {
                            DeflectionLimit d = deflectionLimits[i];
                            if (running_changes > maxDeflectionChanges) break;
                            stat3 = Environment.NewLine + "########## Optimising Deflections: ##########";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                            stat3 = String.Format("Deflection constraint: {0}, limit: {1}mm", i+1, d.Deflection);
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                            OptDeflections(worker, e, d, ref iter, ref defStatisfied[i], ref changes, ref running_changes);
                            if (defStatisfied[i] == false) deflections_satisfied = false;
                        }
                    }
                }

                //####################################
                //####### Optimise Frequency #########
                //####################################
                //optimise frequency loop
                ///     collect deflection results
                ///     apply unit force
                ///     solve
                ///     choose sections
                ///     update sections
                ///     iterate
                if (optFrequency)
                {
                    stat3 = Environment.NewLine + "########## Optimising Frequency: ##########";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                    for (int iter_freq = 1; iter_freq < 50; iter_freq++)
                    {
                        int changes_freq = 0;

                        //solve and open results file
                        stat2 = "running solver...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        RunSolver(Optimisation.Solver.frequency, ref NumPrimary, ref NumSecondary);
                        if (worker.CancellationPending)
                        {
                            iErr = St7.St7CloseResultFile(1);
                            if (CheckiErr(iErr)) { return; };
                            iErr = St7.St7CloseFile(1);
                            if (CheckiErr(iErr)) { return; };
                            iErr = St7.St7Release();
                            if (CheckiErr(iErr)) { return; };
                            e.Cancel = true;
                            return;
                        }

                        //collect worst case deflection
                        stat2 = "applying virtual load...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        double def_max = 0;
                        int def_node = 0;
                        int def_max_case = 0;
                        double[] virtual_load = new double[3];

                        double freq_current = 0;
                        iErr = St7.St7GetFrequency(1, 1, ref freq_current);
                        if (CheckiErr(iErr)) { return; }

                        foreach (int ResCase in new List<int> { 1 })
                        {
                            stat2 = "collecting deflection results for case no " + ResCase.ToString();
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                            for (int i = 0; i < nNodes; i++)
                            {
                                double[] NodeResults = new double[St7.kMaxDisp];
                                iErr = St7.St7GetNodeResult(1, St7.rtNodeDisp, i + 1, ResCase, NodeResults);
                                if (CheckiErr(iErr)) { return; };

                                double dx = NodeResults[0];
                                double dy = NodeResults[1];
                                double dz = NodeResults[2];
                                //double def = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                                double def = Math.Max(Math.Max(Math.Abs(dx), Math.Abs(dy)), Math.Abs(dz));
                                if (def > def_max)
                                {
                                    def_max = def;
                                    def_node = i + 1;
                                    def_max_case = ResCase;
                                    virtual_load[0] = dx / def;
                                    virtual_load[1] = dy / def;
                                    virtual_load[2] = dz / def;
                                }
                            }
                        }

                        stat2 = String.Format("     current frequency: {0:0.00}Hz", freq_current);
                        stat3 = stat2;
                        string sDef = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        iErr = St7.St7CloseResultFile(1);
                        if (CheckiErr(iErr)) { return; };

                        if (freq_current < freq_limit)
                        {
                            //apply unit force to worst case node
                            iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, virtual_load);
                            if (CheckiErr(iErr)) { return; };

                            //solve and open results file
                            stat2 = "running solver...";
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                            //RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                            RunSolver(Solver.frequency, ref NumPrimary, ref NumSecondary);
                            if (worker.CancellationPending)
                            {
                                iErr = St7.St7CloseResultFile(1);
                                if (CheckiErr(iErr)) { return; }
                                iErr = St7.St7CloseFile(1);
                                if (CheckiErr(iErr)) { return; }
                                iErr = St7.St7Release();
                                if (CheckiErr(iErr)) { return; }
                                e.Cancel = true;
                                return;
                            }

                            //collect results
                            stat2 = "collecting virtual deflection results...";
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                            //reset variables
                            foreach (Beam b in beams)
                            {
                                b.A_x_def = 1;
                                b.M_11_def = 1;
                                b.M_22_def = 1;
                            }

                            //List<int> cases = new List<int> { 1 };// virtual_case };//, freq_case };

                            foreach (Beam b in beams)
                            {
                                if (!b.isValid) continue;
                                int c = 1;
                                //foreach (int c in cases)
                                //{
                                int NumPoints = 0;
                                int NumColumns = 0;
                                double[] BeamPos = new double[St7.kMaxBeamResult];
                                double[] BeamResults = new double[St7.kMaxBeamResult];
                                iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, b.Number, 8, c, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                                if (CheckiErr(iErr)) { return; }

                                double A_x_addition = 0;
                                double M_11_addition = 0;
                                double M_22_addition = 0;

                                for (int j = 0; j < NumPoints; j++)
                                {
                                    A_x_addition += Math.Abs(BeamResults[j * NumColumns + St7.ipBeamAxialF]);
                                    M_11_addition += Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM2]);
                                    M_22_addition += Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM1]);
                                }

                                //Multiply for sensitivity
                                b.A_x_def = (A_x_addition / NumPoints);// * (A_x_addition / NumPoints);
                                b.M_11_def = (M_11_addition / NumPoints);//* (M_11_addition / NumPoints);
                                b.M_22_def = (M_22_addition / NumPoints);//*(M_22_addition / NumPoints);

                                iErr = St7.St7GetBeamResultArray(1, St7.rtBeamDisp, St7.stBeamGlobal, b.Number, 2, c, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                                if (CheckiErr(iErr)) { return; }

                                double disp = 0;
                                double dx = 0;
                                double dy = 0;
                                double dz = 0;
                                for (int j = 0; j < NumPoints; j++)
                                {
                                    dx += BeamResults[j * NumColumns + 0];
                                    dy += BeamResults[j * NumColumns + 1];
                                    dz += BeamResults[j * NumColumns + 2];
                                    disp += Math.Sqrt(dx * dx + dy * dy + dz * dz);
                                }
                                double dx1 = BeamResults[0 * NumColumns + 0] / def_max;
                                double dy1 = BeamResults[0 * NumColumns + 1] / def_max;
                                double dz1 = BeamResults[0 * NumColumns + 2] / def_max;
                                double dx2 = BeamResults[1 * NumColumns + 0] / def_max;
                                double dy2 = BeamResults[1 * NumColumns + 1] / def_max;
                                double dz2 = BeamResults[1 * NumColumns + 2] / def_max;
                                //double dx1 = BeamResults[0 * NumColumns + 0];
                                //double dy1 = BeamResults[0 * NumColumns + 1];
                                //double dz1 = BeamResults[0 * NumColumns + 2];
                                //double dx2 = BeamResults[1 * NumColumns + 0];
                                //double dy2 = BeamResults[1 * NumColumns + 1];
                                //double dz2 = BeamResults[1 * NumColumns + 2];

                                //b.d_freq = disp / NumPoints;
                                b.d_freq = (dx1 * dx1 + dy1 * dy1 + dz1 * dz1 + dx2 * dx2 + dy2 * dy2 + dz2 * dz2);
                                //b.d_freq = disp / NumPoints / def_max;
                                b.d_freq_x = dx / NumPoints;
                                b.d_freq_y = dy / NumPoints;
                                b.d_freq_z = dz / NumPoints;
                                //}
                            }

                            iErr = St7.St7CloseResultFile(1);
                            if (CheckiErr(iErr)) { return; };
                            if (worker.CancellationPending)
                            {
                                iErr = St7.St7CloseFile(1);
                                if (CheckiErr(iErr)) { return; };
                                iErr = St7.St7Release();
                                if (CheckiErr(iErr)) { return; };
                                e.Cancel = true;
                                return;
                            }

                            //delete unit force on worst case node
                            iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, new double[] { 0, 0, 0 });
                            if (CheckiErr(iErr)) { return; };

                            //choose sections
                            stat2 = "choosing sections...";
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                            double def_approx = def_max;

                            //foreach(BeamProperty p in beamProperties)
                            //{ p.TempSectionInt = p.CurrentSectionInt; }

                            int counter = 0;
                            double lambda = 0.5; //the higher the number the more changes made per iteration. l=1 tries to hit exactly.
                            double def_limit_freq = def_max * Math.Pow(freq_current / freq_limit, 2);
                            double def_target = def_max + lambda * (def_limit_freq - def_max);
                            while (def_approx > def_target && counter < 500)
                            {
                                counter++;

                                double[] group_def_current = new double[nProps2];
                                double[] group_mass_current = new double[nProps2];
                                double[] group_modal_mass_current = new double[nProps2];
                                double[][] group_def_new = new double[nProps2][];
                                double[][] group_mass_new = new double[nProps2][];
                                double[][] group_modal_mass_new = new double[nProps2][];
                                double[][] group_efficiency = new double[nProps2][];
                                foreach (BeamProperty p in beamProperties)
                                {
                                    int ip = p.Number - 1;
                                    int g = p.Group;
                                    int num_sections = SecLib.GetGroup(g).Count;

                                    group_def_new[ip] = new double[num_sections];
                                    group_mass_new[ip] = new double[num_sections];
                                    group_efficiency[ip] = new double[num_sections];
                                    group_modal_mass_new[ip] = new double[num_sections];
                                }
                                double best_efficiency = 0;
                                int best_property = 0;
                                int best_section = 0;
                                double total_def_approx = 0;
                                double total_modal_mass_approx = 0;
                                double total_freq_approx = 0;
                                double def_factor = 0;

                                //Calc prop group current deflection and mass contributions
                                foreach (Beam b in beams)
                                {
                                    if (!b.isValid) continue;
                                    int p = b.PropertyNum - 1;
                                    int g = beamProperties[p].Group;
                                    int iCurrent = beamProperties[p].NewSectionInt;
                                    Section s_current = SecLib.GetSection(g, iCurrent);

                                    //Calc deflections and masses per property for current properties
                                    group_def_current[p] += b.CalcFreq(s_current);
                                    group_mass_current[p] += b.CalcMass(s_current);
                                    group_modal_mass_current[p] += b.CalcModalMass(s_current);
                                    total_def_approx += b.CalcFreq(s_current);
                                    total_modal_mass_approx += b.CalcModalMass(s_current);

                                    //Calc deflections and masses per property for all potential beams
                                    foreach (Section sec in SecLib.GetGroup(g))
                                    {
                                        group_def_new[p][sec.Number] += b.CalcFreq(sec);
                                        group_mass_new[p][sec.Number] += b.CalcMass(sec);
                                        group_modal_mass_new[p][sec.Number] += b.CalcModalMass(sec);
                                    }
                                }

                                total_freq_approx = Math.Sqrt(total_def_approx / total_modal_mass_approx) / 2 / Math.PI;
                                def_factor = def_max / total_def_approx;

                                foreach (BeamProperty p in beamProperties)
                                {
                                    if (p.Optimise)
                                    {
                                        int g = p.Group;
                                        int ip = p.Number - 1;

                                        //Calc efficiencies
                                        foreach (Section sec in SecLib.GetGroup(g))
                                        {
                                            if (group_mass_new[ip][sec.Number] - group_mass_current[ip] != 0) group_efficiency[ip][sec.Number] = (1 / group_def_new[ip][sec.Number] / group_modal_mass_new[ip][sec.Number] - 1 / group_def_current[ip] / group_modal_mass_current[ip]) / (group_mass_new[ip][sec.Number] - group_mass_current[ip]);
                                            else group_efficiency[ip][sec.Number] = 0;
                                            //Choose most efficient
                                            double def_modmass = ((group_def_current[ip] - group_def_new[ip][sec.Number]) / (group_modal_mass_new[ip][sec.Number] - group_modal_mass_current[ip]));
                                            if (group_efficiency[ip][sec.Number] > best_efficiency && ((1 / group_def_new[ip][sec.Number] / group_modal_mass_new[ip][sec.Number] - 1 / group_def_current[ip] / group_modal_mass_current[ip])) > 0)
                                            {
                                                best_efficiency = group_efficiency[ip][sec.Number];
                                                best_property = ip;
                                                best_section = sec.Number;
                                            }
                                        }
                                    }
                                }

                                double def_inc = (group_def_new[best_property][best_section] - group_def_current[best_property]);
                                if (def_inc >= 0) { break; }
                                def_approx += def_inc * def_factor;
                                beamProperties[best_property].NewSectionInt = best_section;
                                beamProperties[best_property].DeflectionGoverned = true;

                                int rem = 0;
                                Math.DivRem(counter, 50, out rem);
                                if (rem == 0)
                                {
                                    stat3 = String.Format("     freq_approx = {0:0.00}Hz", freq_current * def_max / def_approx);
                                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                                }

                                if (worker.CancellationPending)
                                {
                                    iErr = St7.St7CloseFile(1);
                                    if (CheckiErr(iErr)) { return; };
                                    iErr = St7.St7Release();
                                    if (CheckiErr(iErr)) { return; };
                                }
                            }

                            //update sections
                            UpdateSections(beamProperties, incPrev, inc, ref changes_freq);
                        }

                        //calc current mass
                        double new_mass = 0;
                        double new_modal_mass = 0;
                        foreach (Beam b in beams)
                        {
                            if (!b.isValid) continue;
                            int p = b.PropertyNum - 1;
                            int g = beamProperties[p].Group;
                            int iCurrent = beamProperties[p].CurrentSectionInt;
                            Section s_current = SecLib.GetSection(g, iCurrent);

                            new_mass += b.CalcMass(s_current);
                            new_modal_mass += b.CalcModalMass(s_current);
                        }
                        new_mass /= 1000;

                        stat2 = String.Format("mass (of selection): {0:0.0}T", new_mass);
                        stat3 = "";
                        string sMass = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        if (changes_freq > 0) { stat2 = String.Format("freq iteration {0}: {1} section changes", iter_freq, changes_freq) + ", " + sMass; }
                        else { stat2 = String.Format("freq iteration {0}: sizing for deflection converged", iter_freq) + ", " + sMass; }
                        stat3 = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + " - frequency " + iter_freq.ToString() + ".st7");
                        if (CheckiErr(iErr)) { return; };

                        changes += changes_freq;
                        if (freq_current > freq_limit) { frequency_satisfied = true; break; }
                        if (changes_freq == 0)
                        {
                            frequency_satisfied = false;
                            stat2 = "WARNING: Frequencies cannot be further increased, check section catalogue.";
                            stat3 = stat2;
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                            break;
                        }
                    }
                }

                iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + ".st7");
                if (CheckiErr(iErr)) { return; };

                if (CheckCancel(worker, e)) return;

                if (looping) { DampingDown = 1.0; }// 0.4; }
                if (changes == 0) { break; }
            }

            //#####################################################################################

            //Delete virtual load case
            if (optFrequency || optDeflections)
            {
                iErr = St7.St7DeleteLoadCase(1, virtual_case);
                if (CheckiErr(iErr)) { return; }
            } 
            // clustering
            if (combineProperties) 
            {
                string s_cluster="";
                ClusterProperties(true,false, ref s_cluster,sBaseFile);
                stat = "";
                stat2 = "";
                stat3 = s_cluster;
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
            } 
            //Rerun solvers for final solution
            if (optStresses || optDeflections)
            {
                RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                iErr = St7.St7CloseResultFile(1);
                if (CheckiErr(iErr)) { return; };
            }
            if (optFrequency)
            {
                RunSolver(Solver.frequency, ref NumPrimary, ref NumSecondary);
                iErr = St7.St7CloseResultFile(1);
                if (CheckiErr(iErr)) { return; };
            }
            iErr = St7.St7SaveFileTo(1, optFolder + @"/Optimised.st7");
            if (CheckiErr(iErr)) { return; }
            iErr = St7.St7SaveFileTo(1, sSt7OptimisedPath);
            if (CheckiErr(iErr)) { return; }
            iErr = St7.St7CloseFile(1);
            if (CheckiErr(iErr)) { return; }
            iErr = St7.St7Release();
            if (CheckiErr(iErr)) { return; }

            stat = "complete";
            stat2 = "";
            DateTime endTime = DateTime.Now;
            TimeSpan timeDifference = endTime.Subtract(startTime);
            double timeMinutes = Math.Floor(timeDifference.TotalMinutes);
            double timeSeconds = timeDifference.TotalSeconds - timeMinutes * 60;
            stat3 = Environment.NewLine + "Optimisation completed at: " + endTime + ", in " + String.Format("{0:0} minutes {1:0.0} seconds", timeMinutes,timeSeconds);
            init = false;
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

            string sOverstressed_beams = "";
            foreach (int i in overstressed_beams) { sOverstressed_beams += i.ToString() + " "; }

            if (!stress_satisfied) { MessageBox.Show("Warning: The following beams may still be overstressed - " + sOverstressed_beams); }
            if (!deflections_satisfied) { MessageBox.Show("Warning: Deflection limits are not satisfied!"); }
            if (!frequency_satisfied) { MessageBox.Show("Warning: Frequency limits are not satisfied!"); }
            else if (changed == 0) { MessageBox.Show("Section sizing has converged!"); }
            else { MessageBox.Show("Section sizing has NOT converged. Maximum number of iterations reached."); }
        }
        private static void SetInputs(DoWorkEventArgs e)
        {
            List<object> args = (List<object>)e.Argument;
            file = (string)args[0];
            iList = (List<List<int>>)args[1];
            ResList_stress = (List<int>)args[2];
            sCase = (Solver)args[3];
            optDeflections = (bool)args[4];
            //ResList_def = (List<int>)args[5];
            //def_limit = (double)args[6]/1e3;
            optStresses = (bool)args[7];
            stress_limit = (double)args[8]*1e6;
            optFrequency = (bool)args[9];
            freq_limit = (double)args[10];
            freq_case = (int)args[11];
            combineProperties = (bool)args[12];
            useExisting = (bool)args[13];
            deflectionLimits = (List<DeflectionLimit>)args[14];
        }
        public static void ConsolidateProperties()
        {

        }
        public static void ClusterProperties(bool saveStrandFiles, bool cluster, ref string s_cluster, string sBaseFile)
        {
            int iErr;
            List<BeamProperty> new_beamProperties = ObjectExtension.CloneList<BeamProperty>(beamProperties.ToList());

            //add all beams to similar beam properties
            for (int i=0;i<new_beamProperties.Count;i++ )
            {
                BeamProperty prop = new_beamProperties[i];
                if (prop == null) continue;
                BeamProperty propMatch = new_beamProperties.Where(x => x != null).Where(x => x.Name == prop.Name).Where(x => x.Group == prop.Group).First();
                if (propMatch.Number != prop.Number)
                {
                    new_beamProperties[propMatch.Number - 1].Beams.AddRange(prop.Beams);
                    new_beamProperties[prop.Number - 1].Beams.Clear();
                }
            }

            //reorder
            new_beamProperties = new_beamProperties.Where(x => x != null).OrderBy(x => x.CurrentSection.A).ToList();
            new_beamProperties.Reverse();

            int count = 0;
            int count_optimise = 0;
            foreach (BeamProperty prop in new_beamProperties)
            {
                if (prop.Beams.Count > 0)
                {
                    count++;
                    prop.Number = count;
                    Section s = prop.CurrentSection;

                    iErr = St7.St7SetBeamSectionGeometry(1, prop.Number, s.SType, s.sectionDoubles);
                    if (iErr > 0)
                    {
                        iErr = St7.St7NewBeamProperty(1, prop.Number, St7.kBeamTypeBeam, s.Name);
                        if (CheckiErr(iErr)) { return; }
                        iErr = St7.St7SetBeamSectionGeometry(1, prop.Number, s.SType, s.sectionDoubles);
                        if (CheckiErr(iErr)) { return; }
                    }
                    foreach (Beam b in prop.Beams)
                    {
                        iErr = St7.St7SetElementProperty(1, St7.tyBEAM, b.Number, prop.Number);
                        if (CheckiErr(iErr)) { return; }
                    }
                    iErr = St7.St7CalculateBeamSectionProperties(1, prop.Number, St7.btFalse, St7.btFalse);
                    if (CheckiErr(iErr)) { return; }

                    if (prop.Optimise)
                    {
                        count_optimise++;
                        iErr = St7.St7SetPropertyName(1, St7.tyBEAM, prop.Number, prop.CurrentSection.Name);
                        if (CheckiErr(iErr)) { return; }
                    }
                }
            }

            int NumDeleted = 0;
            iErr = St7.St7DeleteUnusedProperties(1, St7.tyBEAM, ref NumDeleted);
            if (CheckiErr(iErr)) { return; }

            /// ######################
            /// ##### Clustering #####
            /// ######################
            if (cluster)
            {
                alglib.clusterizerstate state;
                alglib.ahcreport rep;
                //double {h,b,t1,t2}
                double[,] keys = new double[count_optimise, 5];

                count_optimise = 0;
                //create keys array and remove irrelavent beam properties
                for (int p = 0; p < new_beamProperties.Count; p++)
                {
                    BeamProperty prop = new_beamProperties[p];
                    if (prop.Beams.Count > 0)
                    {
                        if (prop.Optimise)
                        {
                            keys[count_optimise, 0] = prop.CurrentSection.D1;
                            keys[count_optimise, 1] = prop.CurrentSection.D2;
                            keys[count_optimise, 2] = prop.CurrentSection.T1;
                            keys[count_optimise, 3] = prop.CurrentSection.T2;
                            keys[count_optimise, 4] = prop.Group * 1e3;
                            count_optimise++;
                        }
                        else { new_beamProperties.RemoveAt(p); p--; }
                    }
                    else { new_beamProperties.RemoveAt(p); p--; }
                }

                alglib.clusterizercreate(out state);
                alglib.clusterizersetpoints(state, keys, count_optimise, 5, 2);
                alglib.clusterizerrunahc(state, out rep);

                //MessageBox.Show(alglib.ap.format(rep.z));

                //initial weight
                List<double> total_weight = new List<double>();
                total_weight.Add(0);
                foreach (BeamProperty prop in new_beamProperties)
                { foreach (Beam b in prop.Beams) total_weight[total_weight.Count - 1] += b.CalcMass(prop.CurrentSection) / 1000; }

                NumDeleted = 0;
                iErr = St7.St7DeleteUnusedProperties(1, St7.tyBEAM, ref NumDeleted);
                if (CheckiErr(iErr)) { return; }
                string sSt7ClusterPath = sBaseFile + " - clustered - " + (count_optimise).ToString() + ".st7";
                iErr = St7.St7SaveFileTo(1, sSt7ClusterPath);
                if (CheckiErr(iErr)) { return; }

                for (int i = 0; i < count_optimise - 1; i++)
                {
                    //get biggest section of merge
                    Section s_big = new Section();
                    Section s0 = new_beamProperties[rep.z[i, 0]].CurrentSection;
                    Section s1 = new_beamProperties[rep.z[i, 1]].CurrentSection;

                    int i_big; int i_small;
                    if (s0.A > s1.A) { i_big = 0; i_small = 1; }
                    else { i_big = 1; i_small = 0; }

                    s_big = new_beamProperties[rep.z[i, i_big]].CurrentSection;

                    //save new beamproperty and move beams
                    int p_new = new_beamProperties[rep.z[i, i_big]].Number;
                    new_beamProperties.Add(new BeamProperty(p_new, SecLib));
                    new_beamProperties[new_beamProperties.Count - 1].CurrentSection = s_big;
                    new_beamProperties[new_beamProperties.Count - 1].Beams.AddRange(new_beamProperties[rep.z[i, 0]].Beams);
                    new_beamProperties[new_beamProperties.Count - 1].Beams.AddRange(new_beamProperties[rep.z[i, 1]].Beams);
                    foreach (Beam b in new_beamProperties[rep.z[i, i_small]].Beams)
                    {
                        iErr = St7.St7SetElementProperty(1, St7.tyBEAM, b.Number, new_beamProperties[rep.z[i, i_big]].Number);
                        if (CheckiErr(iErr)) { return; }
                    }
                    new_beamProperties[rep.z[i, 0]].Beams.Clear();
                    new_beamProperties[rep.z[i, 1]].Beams.Clear();

                    //calc weight for this merge
                    total_weight.Add(0);
                    foreach (BeamProperty prop in new_beamProperties)
                    { foreach (Beam b in prop.Beams) total_weight[total_weight.Count - 1] += b.CalcMass(prop.CurrentSection) / 1000; }


                    NumDeleted = 0;
                    iErr = St7.St7DeleteUnusedProperties(1, St7.tyBEAM, ref NumDeleted);
                    if (CheckiErr(iErr)) { return; }
                    sSt7ClusterPath = sBaseFile + " - clustered - " + (count_optimise - 1 - i).ToString() + ".st7";
                    iErr = St7.St7SaveFileTo(1, sSt7ClusterPath);
                    if (CheckiErr(iErr)) { return; }
                }
                s_cluster = Environment.NewLine + "Approximate Rationalisation Results:"
                    + Environment.NewLine + "Properties  Weight [tonne]" + Environment.NewLine;
                int prop_count = count_optimise;
                foreach (double w in total_weight)
                {
                    s_cluster += prop_count.ToString() + String.Format("        {0:0.0}", w) + Environment.NewLine;
                    prop_count--;
                }
            }
        }
        private static void OptStresses(BackgroundWorker worker, DoWorkEventArgs e, ref int iter, ref bool stress_satisfied, ref int changes)
        {
            int iErr = 0;

            DampingDown = 1.0;
            DampingUp = 1.0;

            stat3 = Environment.NewLine + "########## Optimising Stresses: ##########";
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

            for (int iter_stress = 1; iter_stress < 50; iter_stress++)
            {
                foreach (Beam b in beams)
                {
                    b.A_x_stress_max = 0;
                    b.A_x_stress_min = 0;
                    b.M_11_stress = 0;
                    b.M_22_stress = 0;
                }
                if (iter_stress > 3) { DampingDown = 0.0; }
                int changes_stress = 0;
                stress_satisfied = true;
                overstressed_beams.Clear();

                //reset unconstrained sections
                foreach (BeamProperty p in beamProperties) { if (!p.DeflectionGoverned) p.NewSectionInt = 0; }

                //solve and open results file
                stat2 = "running solver...";
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                if (CheckCancel(worker, e)) return;

                //collect results
                stat2 = "collecting results...";
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                foreach (int ResCase in ResList_stress)
                {
                    stat2 = "collecting stress results for case no " + ResCase.ToString() + "...";
                    stat3 = "";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                    foreach (Beam b in beams)
                    {
                        if (!b.isValid) continue;
                        int NumPoints = 0;
                        int NumColumns = 0;
                        double[] BeamPos = new double[St7.kMaxBeamResult];
                        double[] BeamResults = new double[St7.kMaxBeamResult];
                        iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, b.Number, 1, ResCase, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                        if (CheckiErr(iErr)) { return; }
                        double A_x_max = 0;
                        double A_x_min = 0;
                        double M_11_max = 0;
                        double M_22_max = 0;

                        for (int j = 0; j < NumPoints; j++)
                        {
                            double A_x_j = BeamResults[j * NumColumns + St7.ipBeamAxialF];
                            double M_11_j = Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM2]);
                            double M_22_j = Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM1]);
                            if (A_x_j > A_x_max) { A_x_max = A_x_j; }
                            if (A_x_j < A_x_min) { A_x_min = A_x_j; }
                            if (M_11_j > M_11_max) { M_11_max = M_11_j; }
                            if (M_22_j > M_22_max) { M_22_max = M_22_j; }
                        }

                        if (A_x_max > b.A_x_stress_max) { b.A_x_stress_max = A_x_max; }
                        if (A_x_min < b.A_x_stress_min) { b.A_x_stress_min = A_x_min; }
                        if (M_11_max > b.M_11_stress) { b.M_11_stress = M_11_max; }
                        if (M_22_max > b.M_22_stress) { b.M_22_stress = M_22_max; }
                    }
                }

                iErr = St7.St7CloseResultFile(1);
                if (CheckiErr(iErr)) { return; };
                if (CheckCancel(worker, e)) return;

                //choose sections
                stat2 = "choosing sections...";
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                foreach (Beam b in beams)
                {
                    if (!b.isValid) continue;
                    if (beamProperties[b.PropertyNum - 1].Optimise) //&& !beamProperties[b.PropertyNum - 1].Overstressed)
                    {
                        int p = b.PropertyNum - 1;
                        int g = beamProperties[p].Group;
                        int iCurrent = beamProperties[p].NewSectionInt;

                        for (int s = iCurrent; s < SecLib.GetGroup(g).Count; s++)
                        {
                            double stress = b.CalcStress(SecLib.GetSection(g, s));

                            if (stress < stress_limit)
                            {
                                beamProperties[p].NewSectionInt = s;
                                break;
                            }
                            ///temporarily decrease overstressed beams to smallest section
                            ///in order to force others to increase.
                            else if (s == (SecLib.GetGroup(g).Count - 1))
                            {
                                if (stress > stress_limit)
                                {
                                    beamProperties[p].NewSectionInt = s;
                                    //beamProperties[p].NewSectionInt = 0;
                                    beamProperties[p].Overstressed = true;
                                    overstressed_beams.Add(b.Number);
                                    stress_satisfied = false;
                                }
                            }
                        }
                    }
                }

                //update sections
                UpdateSections(beamProperties, incPrev, inc, ref changes_stress);

                string sMass = "";
                WeighStructure(worker, ref sMass);

                if (changes_stress > 0) { stat2 = String.Format("stress iteration {0}: {1} section changes", iter_stress, changes_stress) + ", " + sMass; ; }
                else { stat2 = stat2 = String.Format("stress iteration {0}: sizing for stresses converged", iter_stress) +", " +sMass; }
                stat3 = stat2;
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + " - stress " + iter_stress.ToString() + ".st7");
                if (CheckiErr(iErr)) { return; };

                changes += changes_stress;
                if (changes_stress == 0 && stress_satisfied) { break; }
                else if (changes_stress == 0) { break; }
            }
        }
        private static bool CheckCancel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            int iErr;
            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return true; }
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return true; }
                e.Cancel = true;
                return true;
            }
            else return false;
        }
        private static void OptDeflections(BackgroundWorker worker, DoWorkEventArgs e, DeflectionLimit d, ref int iter, ref bool deflectionsSatisfied, ref int changes, ref int running_changes)
        {
            DampingDown = 1.0;
            DampingUp = 1.0;
            int iErr = 0;
            string stat="", stat2="", stat3="";
            int local_changes = 0;
            ResList_def = d.LoadCasesOutput;
            def_limit = d.Deflection / 1000;
            relNode = d.ReferenceNode;

            int localMaxDeflectionChanges = (int)Math.Round(Convert.ToDouble(maxDeflectionChanges) / deflectionLimits.Count);

            for (int iter_def = 1; iter_def < 50; iter_def++)
            {
                if (local_changes > localMaxDeflectionChanges) break;
                int changes_def = 0;

                //solve and open results file
                stat2 = "running solver...";
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                if (CheckCancel(worker, e)) return;

                //collect worst case deflection
                stat2 = "applying virtual load...";
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                double def_max = 0;
                double def_relNode = 0;
                int def_node = 0;
                int def_max_case = 0;
                double[] virtual_load = new double[3];
                double[] d_rel = new double[3];

                foreach (int ResCase in ResList_def)
                {
                    stat2 = "collecting deflection results for case no " + ResCase.ToString();
                    stat3 = "";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                    if (relNode > 0)
                    {
                        double[] NodeResults = new double[St7.kMaxDisp];
                        iErr = St7.St7GetNodeResult(1, St7.rtNodeDisp, relNode, ResCase, NodeResults);
                        if (CheckiErr(iErr)) { return; }
                        double dx = (d.X == true ? NodeResults[0] : 0);
                        double dy = (d.Y == true ? NodeResults[1] : 0);
                        double dz = (d.Z == true ? NodeResults[2] : 0);
                        d_rel[0] = dx;
                        d_rel[1] = dy;
                        d_rel[2] = dz;
                        def_relNode = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                    }

                    if (d.DeflectionNodesOutput == null || d.DeflectionNodesOutput.Count == 0)
                    {
                        for (int i = 0; i < nNodes; i++)
                        {
                            double[] NodeResults = new double[St7.kMaxDisp];
                            iErr = St7.St7GetNodeResult(1, St7.rtNodeDisp, i + 1, ResCase, NodeResults);
                            if (CheckiErr(iErr)) { return; }

                            double dx = (d.X == true ? NodeResults[0] : 0);
                            double dy = (d.Y == true ? NodeResults[1] : 0);
                            double dz = (d.Z == true ? NodeResults[2] : 0);
                            double def = Math.Sqrt(dx * dx + dy * dy + dz * dz);

                            if ((def - def_relNode) > def_max)
                            {
                                def_max = def - def_relNode;
                                def_node = i + 1;
                                def_max_case = ResCase;
                                virtual_load[0] = (dx - d_rel[0]) / (def - def_relNode);
                                virtual_load[1] = (dy - d_rel[1]) / (def - def_relNode);
                                virtual_load[2] = (dz - d_rel[2]) / (def - def_relNode);
                            }
                        }
                    }
                    else
                    {
                        foreach (int n in d.DeflectionNodesOutput)
                        {
                            int i = n - 1;
                            double[] NodeResults = new double[St7.kMaxDisp];
                            iErr = St7.St7GetNodeResult(1, St7.rtNodeDisp, i + 1, ResCase, NodeResults);
                            if (CheckiErr(iErr)) { return; }

                            double dx = (d.X == true ? NodeResults[0] : 0);
                            double dy = (d.Y == true ? NodeResults[1] : 0);
                            double dz = (d.Z == true ? NodeResults[2] : 0);
                            double def = Math.Sqrt(dx * dx + dy * dy + dz * dz);

                            if ((def - def_relNode) > def_max)
                            {
                                def_max = def - def_relNode;
                                def_node = i + 1;
                                def_max_case = ResCase;
                                virtual_load[0] = (dx - d_rel[0]) / (def - def_relNode);
                                virtual_load[1] = (dy - d_rel[1]) / (def - def_relNode);
                                virtual_load[2] = (dz - d_rel[2]) / (def - def_relNode);
                            }
                        }
                    }
                }

                stat2 = String.Format("     current max def: {0:0.0}mm, at node: {1}, load case: {2}", def_max * 1e3, def_node, def_max_case);
                stat3 = stat2;
                string sDef = stat2;
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                iErr = St7.St7CloseResultFile(1);
                if (CheckiErr(iErr)) { return; }

                if (def_max > def_limit)
                {
                    //apply unit force to worst case node
                    iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, virtual_load);
                    if (CheckiErr(iErr)) { return; };
                    needsSolving = true;

                    //solve and open results file
                    stat2 = "running solver...";
                    stat3 = "";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                    RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                    if (CheckCancel(worker, e)) return;

                    //collect results
                    stat2 = "collecting virtual deflection results...";
                    stat3 = "";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                    //reset variables
                    foreach (Beam b in beams)
                    {
                        b.A_x_def = 1;
                        b.M_11_def = 1;
                        b.M_22_def = 1;
                    }

                    List<int> cases = new List<int> { virtual_case, def_max_case };

                    foreach (Beam b in beams)
                    {
                        if (!b.isValid) continue;
                        foreach (int c in cases)
                        {
                            int NumPoints = 0;
                            int NumColumns = 0;
                            double[] BeamPos = new double[St7.kMaxBeamResult];
                            double[] BeamResults = new double[St7.kMaxBeamResult];
                            iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, b.Number, 8, c, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                            if (CheckiErr(iErr)) { return; }
                            double A_x_addition = Math.Abs(BeamResults[St7.ipBeamAxialF]);
                            double M_11_addition = Math.Abs(BeamResults[St7.ipBeamBM2]);
                            double M_22_addition = Math.Abs(BeamResults[St7.ipBeamBM1]);

                            for (int j = 1; j < NumPoints; j++)
                            {
                                A_x_addition += Math.Abs(BeamResults[j * NumColumns + St7.ipBeamAxialF]);
                                M_11_addition += Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM2]);
                                M_22_addition += Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM1]);
                            }

                            //Multiply for sensitivity
                            b.A_x_def *= (A_x_addition / NumPoints);
                            b.M_11_def *= (M_11_addition / NumPoints);
                            b.M_22_def *= (M_22_addition / NumPoints);
                        }
                    }

                    iErr = St7.St7CloseResultFile(1);
                    if (CheckiErr(iErr)) { return; };
                    if (CheckCancel(worker, e)) return;

                    //delete unit force on worst case node
                    iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, new double[] { 0, 0, 0 });
                    if (CheckiErr(iErr)) { return; };

                    //choose sections
                    stat2 = "choosing sections...";
                    stat3 = "";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                    double def_approx = def_max;

                    double[] group_def_current = new double[nProps2];
                    double[] group_mass_current = new double[nProps2];
                    double[][] group_def_new = new double[nProps2][];
                    double[][] group_mass_new = new double[nProps2][];
                    double[][] group_efficiency = new double[nProps2][];
                    foreach (BeamProperty p in beamProperties)
                    {
                        if (p.Optimise)
                        {
                            int ip = p.Number - 1;
                            int g = p.Group;
                            int num_sections = SecLib.GetGroup(g).Count;

                            group_def_new[ip] = new double[num_sections];
                            group_mass_new[ip] = new double[num_sections];
                            group_efficiency[ip] = new double[num_sections];
                        }
                    }

                    //Calc prop group current deflection and mass contributions
                    foreach (Beam b in beams)
                    {
                        if (!b.isValid) continue;
                        int p = b.PropertyNum - 1;
                        if (beamProperties[p].Optimise)
                        {
                            int g = beamProperties[p].Group;
                            int iCurrent = beamProperties[p].NewSectionInt;
                            Section s_current = SecLib.GetSection(g, iCurrent);

                            //Calc deflections and masses per property for current properties
                            group_def_current[p] += b.CalcDeflection(s_current);
                            group_mass_current[p] += b.CalcMass(s_current);

                            //Calc deflections and masses per property for all potential beams
                            foreach (Section sec in SecLib.GetGroup(g))
                            {
                                group_def_new[p][sec.Number] += b.CalcDeflection(sec);
                                group_mass_new[p][sec.Number] += b.CalcMass(sec);
                            }
                        }
                    }
                    foreach (BeamProperty p in beamProperties)
                    {
                        if (p.Optimise)
                        {
                            int g = p.Group;
                            int ip = p.Number - 1;

                            //Calc efficiencies
                            foreach (Section sec in SecLib.GetGroup(g))
                            {
                                if (group_mass_new[ip][sec.Number] - group_mass_current[ip] != 0) group_efficiency[ip][sec.Number] = (group_def_current[ip] - group_def_new[ip][sec.Number]) / (group_mass_new[ip][sec.Number] - group_mass_current[ip]);
                                else group_efficiency[ip][sec.Number] = 0;
                            }
                        }
                    }

                    int counter = 0;
                    // The higher the number the more changes made per iteration. l=1 tries to hit exactly.
                    double lambda = 1.0;
                    //if (def_max / def_limit > 1.5) lambda = 1.5;
                    // Reduce approximated target by 1mm to avoid many runs of solving the model.
                    double def_target = def_max + lambda * (def_limit - def_max) - 0.001;

                    while (def_approx > def_target && counter < maxDeflectionChanges)
                    {
                        counter++;
                        double best_efficiency = 0;
                        int best_property = 0;
                        int best_section = 0;

                        foreach (BeamProperty p in beamProperties)
                        {
                            if (p.Optimise)
                            {
                                int g = p.Group;
                                int ip = p.Number - 1;
                                foreach (Section sec in SecLib.GetGroup(g))
                                {
                                    //Choose most efficient
                                    if (group_efficiency[ip][sec.Number] > best_efficiency && (group_def_new[ip][sec.Number] - group_def_current[ip]) < 0)
                                    {
                                        best_efficiency = group_efficiency[ip][sec.Number];
                                        best_property = ip;
                                        best_section = sec.Number;
                                    }
                                }
                            }
                        }

                        double def_inc = (group_def_new[best_property][best_section] - group_def_current[best_property]);
                        if (def_inc >= 0) { break; }
                        def_approx += def_inc;
                        beamProperties[best_property].NewSectionInt = best_section;
                        beamProperties[best_property].DeflectionGoverned = true;

                        // Update deflections and masses per property for current properties
                        group_def_current[best_property] = group_def_new[best_property][best_section];
                        group_mass_current[best_property] = group_mass_new[best_property][best_section];
                        int best_group = beamProperties[best_property].Group;
                        int best_p = beamProperties[best_property].Number - 1;

                        // Update efficiencies
                        foreach (Section sec in SecLib.GetGroup(best_group))
                        {
                            if (group_mass_new[best_p][sec.Number] - group_mass_current[best_p] != 0) group_efficiency[best_p][sec.Number] = (group_def_current[best_p] - group_def_new[best_p][sec.Number]) / (group_mass_new[best_p][sec.Number] - group_mass_current[best_p]);
                            else group_efficiency[best_p][sec.Number] = 0;
                        }

                        int rem = 0;
                        Math.DivRem(counter, 100, out rem);
                        if (rem == 0)
                        {
                            stat3 = String.Format("     def_approx = {0:0.00}mm", def_approx * 1e3);
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        }

                        if (CheckCancel(worker, e)) return;
                    }

                    //update sections
                    UpdateSections(beamProperties, incPrev, inc, ref changes_def);
                }

                string sMass="";
                WeighStructure(worker, ref sMass);
                if (changes_def > 0) { stat2 = String.Format("def iteration {0}: {1} section changes", iter_def, changes_def) + ", " + sMass; }
                else { stat2 = String.Format("def iteration {0}: sizing for deflection converged", iter_def) + ", " + sMass; }
                stat3 = stat2;
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + " - deflection " + iter_def.ToString() + ".st7");
                if (CheckiErr(iErr)) { return; }

                changes += changes_def;
                running_changes += changes_def;
                local_changes += changes_def;

                if (def_max < def_limit) { deflectionsSatisfied = true; break; }
                if (changes_def == 0)
                {
                    deflectionsSatisfied = false;
                    stat2 = "WARNING: Deflections cannot be further reduced, check section catalogue.";
                    stat3 = stat2;
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                    break;
                }
            }
        }
        public static void WeighStructure(BackgroundWorker worker, ref string sMass)
        {
            //calc current mass
            double new_mass = 0;
            foreach (Beam b in beams)
            {
                if (!b.isValid) continue;

                int p = b.PropertyNum - 1;
                if (beamProperties[p].Optimise)
                {
                    int g = beamProperties[p].Group;
                    int iCurrent = beamProperties[p].CurrentSectionInt;
                    Section s_current = SecLib.GetSection(g, iCurrent);
                    new_mass += b.CalcMass(s_current);
                }
            }
            new_mass /= 1000;

            sMass = String.Format("mass (of selection): {0:0.0}T", new_mass);
        }
        public static void SetupBeamsAndProperties(bool setBeams, int nBeams, Beam[] beams)
        {
            int iErr;

            //get beam properties (prop number, length, group number)
            for (int i = 0; i < nBeams; i++)
            {
                beams[i] = new Beam(i + 1);
                Beam b = beams[i];

                int propNum = 0;
                iErr = St7.St7GetElementProperty(1, St7.tyBEAM, b.Number, ref propNum);
                if (CheckiErr(iErr)) { return; };

                double L = 0;
                iErr = St7.St7GetElementData(1, St7.tyBEAM, b.Number, ref L);
                if (CheckiErr(iErr)) { return; };

                int group = 0;
                iErr = St7.St7GetElementGroup(1, St7.tyBEAM, b.Number, ref group);
                if (CheckiErr(iErr)) { return; };

                b.PropertyNum = propNum;
                b.Length = L;

                if (propNum > 0)
                {
                    BeamProperty p = beamProperties[propNum - 1];

                    if (p == null)
                    {
                        p = new BeamProperty(propNum, SecLib);
                        p.Group = group - 2;
                    }
                    else
                    {
                        if (p.Group != group - 2)
                        {
                            MessageBox.Show("Some beams of a given property have different group numbers");
                            throw new Exception("Some beams of a given property have different group numbers.");
                            return;
                        }
                    }
                    p.Beams.Add(b);
                    if (p.Group > -1) { p.Optimise = true; p.CurrentSectionInt = 0; }
                    beamProperties[propNum - 1] = p;
                }
                else
                {
                    b.isValid = false;
                }
            }

            for (int ip = 0; ip < nProps2; ip++)
            {
                if (beamProperties[ip] == null)
                { 
                    beamProperties[ip] = new BeamProperty(ip + 1, SecLib);
                }
            }
            if (!beamProperties.Where(x => x !=null).Any(x => x.Optimise))
            {
                MessageBox.Show("No beams with positive group IDs are defined");
                throw new Exception("No beams with positive group IDs are defined.");
                return;
            }
            foreach (BeamProperty prop in beamProperties)
            {
                if (prop != null)
                {
                    if (prop.Optimise && setBeams)
                    {
                        int p = prop.Number;
                        Section sec = prop.CurrentSection;

                        iErr = St7.St7SetBeamSectionGeometry(1, p, sec.SType, sec.sectionDoubles);
                        if (CheckiErr(iErr)) { return; };

                        iErr = St7.St7CalculateBeamSectionProperties(1, p, St7.btFalse, St7.btFalse);
                        if (CheckiErr(iErr)) { return; }
                    }
                    else if (prop.Beams.Count > 0)
                    {
                        int p = prop.Number;
                        int sectionType = new int();
                        double[] doubles = new double[6];
                        iErr = St7.St7GetBeamSectionGeometry(1, p, ref sectionType, doubles);
                        if (CheckiErr(iErr)) { return; }
                        double[] doubles2 = new double[11];
                        int[] integers = new int[1];
                        iErr = St7.St7GetBeamSectionPropertyData(1, p, integers, doubles2);
                        if (CheckiErr(iErr)) { return; }
                        Section sec = new Section(doubles[0], doubles[1], doubles[2], doubles[3], doubles[4], doubles[5], doubles2[0], 0, 0, sectionType, doubles2[1], doubles2[2], 0);
                        prop.CurrentSection = sec;
                    }
                }
            }
        }
        public static void CollectCSVSections(string sFolder, int numGroups)
        {
            for (int g = 0; g < numGroups-1; g++)
            {
                int iErr;
                string filePath = System.IO.Path.Combine(sFolder, "Section_CSV" + (g + 1).ToString() + ".txt");
                if (!System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("section data file does not exist");
                    throw new Exception("section data file does not exist.");
                    return;
                }

                using (var fs = System.IO.File.OpenRead(filePath))
                using (var reader = new System.IO.StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        double d1 = Convert.ToDouble(values[0]) / 1e3;
                        double d2 = Convert.ToDouble(values[1]) / 1e3;
                        double d3 = Convert.ToDouble(values[2]) / 1e3;
                        double t1 = Convert.ToDouble(values[3]) / 1e3;
                        double t2 = Convert.ToDouble(values[4]) / 1e3;
                        double t3 = Convert.ToDouble(values[5]) / 1e3;
                        double a = Convert.ToDouble(values[6]) / 1e6;
                        double z11 = Convert.ToDouble(values[7]) / 1e9;
                        double z22 = Convert.ToDouble(values[8]) / 1e9;
                        int stype = Convert.ToInt32(values[9]);
                        double i11 = Convert.ToDouble(values[10]) / 1e12;
                        double i22 = Convert.ToDouble(values[11]) / 1e12;

                        Section s = new Section(d1, d2, d3, t1, t2, t3, a, z11, z22, stype, i11, i22, g);
                        SecLib.AddSection(s, g);
                    }
                }

                if (SecLib.GetGroup(g).Count == 0)
                {
                    MessageBox.Show("No section properties found.");
                    return;
                }
            }
        }
        private static void RunSolver(Solver sCase, ref int NumPrimary, ref int NumSecondary)
        {
            int iErr;
            switch (sCase)
            {
                case Solver.linear:
                    if (needsSolving)
                    {
                        iErr = St7.St7SetResultFileName(1, sSt7LSAPath);
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7RunSolver(1, St7.stLinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                        if (CheckiErr(iErr)) { return; };
                        needsSolving = false;
                    }
                    sSt7ResPath = sSt7LSAPath;
                    break;
                case Solver.nonlin:
                    if (needsSolving)
                    {
                        iErr = St7.St7SetResultFileName(1, sSt7NLAPath);
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7RunSolver(1, St7.stNonlinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                        if (CheckiErr(iErr)) { return; };
                        needsSolving = false;
                    }
                    sSt7ResPath = sSt7NLAPath;
                    break;
                case Solver.frequency:
                    if (needsSolving)
                    {
                        iErr = St7.St7SetResultFileName(1, sSt7FreqPath);
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7RunSolver(1, St7.stNaturalFrequencySolver, St7.smBackgroundRun, St7.btTrue);
                        if (CheckiErr(iErr)) { return; };
                        needsSolving = false;
                    }
                    sSt7ResPath = sSt7FreqPath;
                    break;

                    //sSt7ResPath = sSt7FreqPath;
                    //iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                    //if (CheckiErr(iErr)) { return; };

                    //double[] ModalRes = new double[10];
                    //iErr = St7.St7GetModalResultsNFA(1, 1, ModalRes);
                    //Freq = ModalRes[0];

                    //iErr = St7.St7CloseResultFile(1);
                    //if (CheckiErr(iErr)) { return; };
                    //break;
            }

            iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
            if (CheckiErr(iErr)) { return; };
        }
        private static void UpdateSections(BeamProperty[] beamProperties, double[] incPrev, double[] inc, ref int changes)
        {
            int iErr = 0;
            foreach (BeamProperty p in beamProperties)
            {
                if (p.Optimise)
                {
                    int ip = p.Number - 1;

                    incPrev[ip] = inc[ip];

                    if ((p.NewSectionInt - p.CurrentSectionInt) > 0)
                    {
                        inc[ip] = (p.NewSectionInt - p.CurrentSectionInt);// * DampingUp;
                    }
                    else if ((p.NewSectionInt - p.CurrentSectionInt) < 0)
                    {
                        inc[ip] = (p.NewSectionInt - p.CurrentSectionInt) * DampingDown;
                    }
                    else inc[ip] = 0;

                    if (inc[ip] != 0)
                    {
                        p.CurrentSectionInt += Convert.ToInt32(inc[ip]);
                        int g = p.Group;
                        int s = p.CurrentSectionInt;
                        int stype = SecLib.GetSection(g,s).SType;
                        double[] SectionDoubles = SecLib.GetSection(g,s).sectionDoubles;

                        iErr = St7.St7SetBeamSectionGeometry(1, p.Number, stype, SectionDoubles);
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7CalculateBeamSectionProperties(1, p.Number, St7.btFalse, St7.btFalse);
                        if (CheckiErr(iErr)) { return; };
                        changes++;
                        if (inc[ip] != -incPrev[ip])
                        {
                            looping = false;
                        }
                    }
                    sb.Append(p.CurrentSectionInt.ToString() + ",");
                }
            }
            if (changes > 0) { needsSolving = true; }
        }
        public static double Stress(double A_x,double M_11, double M_22, double A, double I11, double I22, double L, double Z11, double Z22)
        {
            double Stress = 0;
            if (A_x < 0)
            {
                //### Buckling Check ####
                double E_s = 210000;
                double f_y = 355;
                double alpha_c = 0.49;
                double lambda = Math.Sqrt(Math.Pow(L, 2) * A / Math.Min(I11, I22));
                double N_cr = Math.Pow(Math.PI, 2) * E_s * A / Math.Pow(lambda, 2);
                double lambda_nd = Math.Max(0.2, Math.Sqrt(A * f_y / N_cr));
                double phi_m = 0.5 * (1 + alpha_c * (lambda_nd - 0.2) + Math.Pow(lambda_nd, 2));
                double chi_n = 1 / (phi_m + Math.Sqrt(Math.Pow(phi_m, 2) - Math.Pow(lambda_nd, 2)));

                Stress = Math.Abs(A_x) / A * chi_n + M_11 / Z11 + M_22 / Z22;
            }
            else
            {
                Stress = A_x / A + M_11 / Z11 + M_22 / Z22;
            }
            return Stress;
        }
        public static double Deflection(double A_x, double M_11, double M_22, double A, double I11, double I22, double L)
        {
            double Deflection = (A_x / A + M_11 / I11 + M_22 / I22) * L / 210000;
            return Deflection;
        }
        public static bool CheckiErr(int iErr)
        {
            StringBuilder sb = new StringBuilder(St7.kMaxStrLen);
            string errorstring;
            St7.St7GetAPIErrorString(iErr, sb, sb.Capacity);
            errorstring = sb.ToString();
            if (errorstring == "")
            {
                St7.St7GetSolverErrorString(iErr, sb, sb.Capacity);
                errorstring = sb.ToString();
            }
            if (errorstring != "No error.")
            {
                //MessageBox.Show(errorstring);
                //Console.WriteLine("");
                //Console.WriteLine("Strand7 API error: " + errorstring);
                //Console.WriteLine("The program has terminated early.");

                string sFilePath = System.IO.Path.GetTempPath() + "API Error Log.txt";
                System.IO.File.WriteAllText(sFilePath, errorstring);

                throw new Exception(errorstring);

                St7.St7CloseFile(1);
                St7.St7Release();

                return true;
            }

            return false;
        }

        #region variables
        private static bool useExisting;
        private static SectionLibrary SecLib = new SectionLibrary();
        private static Beam[] beams;
        private static bool needsSolving = true;
        private static int maxDeflectionChanges;

        private static List<int> overstressed_beams = new List<int>();

        private static string stat;
        private static string stat2;
        private static string stat3;

        private static int NumPrimary;
        private static int NumSecondary;
        private static int nNodes;
        private static int virtual_case;
        private static int nProps2;
        private static bool init;
        public static BeamProperty[] beamProperties;
        private static double[] incPrev;
        private static double[] inc;
        private static string optFolder;

        //private static List<List<double>> A = new List<List<double>>();
        //private static List<List<double>> D1 = new List<List<double>>();
        //private static List<List<double>> D2 = new List<List<double>>();
        //private static List<List<double>> D3 = new List<List<double>>();
        //private static List<List<double>> T1 = new List<List<double>>();
        //private static List<List<double>> T2 = new List<List<double>>();
        //private static List<List<double>> T3 = new List<List<double>>();
        //private static List<List<double>> I11 = new List<List<double>>();
        //private static List<List<double>> I22 = new List<List<double>>();
        //private static List<List<double>> Z11 = new List<List<double>>();
        //private static List<List<double>> Z22 = new List<List<double>>();
        //private static List<List<int>> SType = new List<List<int>>();

        private static string file = "";
        private static List<List<int>> iList = new List<List<int>>();
        private static List<int> ResList_stress = new List<int>();
        private static List<int> ResList_def = new List<int>();
        private static int freq_case = 0;
        private static Solver sCase = new Solver();
        private static bool optDeflections = new bool();
        private static bool optStresses = new bool();
        private static bool optFrequency = new bool();
        private static bool combineProperties = new bool();
        private static double def_limit = new double();
        private static double stress_limit = new double();
        private static double freq_limit = new double();
        private static int relNode = 0;

        private static string sSt7ResPath = "";
        private static string sSt7LSAPath = "";
        private static string sSt7NLAPath = "";
        private static string sSt7FreqPath = "";

        private static bool looping = true;
        private static int changed = 0;
        private static StringBuilder sb = new StringBuilder();
        private static double DampingUp = 1.0;
        private static double DampingDown = 1.0;
        private static List<DeflectionLimit> deflectionLimits;
        //private static double[][][] SectionDoubles;

        public enum Solver { linear, nonlin, frequency }
        #endregion
    }

    public static class ObjectExtension
    {
        public static List<T> CloneList<T>(List<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
        }
    }
}
