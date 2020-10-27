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

namespace Strand7_Steel_Section_Sizing
{
    class Optimisation
    {
        public static void Optimise(BackgroundWorker worker, DoWorkEventArgs e)
        {
            bool init = true;
            string stat = "Initialising...";
            string stat2 = "opening Strand7 file...";
            string stat3 = "Optimisation started at: " + DateTime.Now;
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
            //#####################################################################################

            SetInputs(e);
            CollectSections();
            int nSections = D1.Count;

            //#############################################
            //############## Set constants ################
            //#############################################
            #region Set constants

            //optimisation settings
            double UtilMax = 0.99;
            double DesignStress = 355;//157.9;//355/1.1;
            DampingUp = 1.0;//0.6;
            DampingDown = 1.0;//0.4;
            int iter_max = 50;
            changed = 0;

            //string builders
            StringBuilder sb = new StringBuilder(100);
            StringBuilder sb_virtual = new StringBuilder(100);

            //file paths
            string sBaseFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), System.IO.Path.GetFileNameWithoutExtension(file));
            string optFolder = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), "Optimisation results");
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
            if (CheckiErr(iErr)) { return; };
            int nBeams = new int();
            int nNodes = new int();
            iErr = St7.St7GetTotal(1, St7.tyBEAM, ref nBeams);
            if (CheckiErr(iErr)) { return; };
            iErr = St7.St7GetTotal(1, St7.tyNODE, ref nNodes);
            if (CheckiErr(iErr)) { return; };
            int[] NumProperties = new int[St7.kMaxEntityTotals];
            int[] LastProperty = new int[St7.kMaxEntityTotals];
            iErr = St7.St7GetTotalProperties(1, NumProperties, LastProperty);
            if (CheckiErr(iErr)) { return; };
            int nProps = NumProperties[St7.ipBeamPropTotal]; //EDIT

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return; };
                e.Cancel = true;
                return;
            }

            double[] BeamResults = new double[St7.kMaxBeamResult];
            double[] NodeResults = new double[St7.kMaxDisp];
            double[] A_x = new double[nBeams];
            double[] M_11 = new double[nBeams];
            double[] M_22 = new double[nBeams];
            int[] CurrentSectArray = new int[nProps];
            int[] NewSectArray = new int[nProps];
            double[] NewSectArray_def = new double[nProps];
            double[] inc = new double[nProps];
            double[] incPrev = new double[nProps];
            int virtual_case = 0;

            if (nProps < 1)
            {
                MessageBox.Show("No beams sections available. window");
                throw new Exception("No beams sections available.");
                return;
            }
            List<List<int>> propList = new List<List<int>>();
            for (int p = 0; p < nProps; p++) { propList.Add(new List<int>()); }
            if (iList.Count < 1)
            {
                int PropNum = 0;
                for (int i = 1; i <= nProps; i++)
                {
                    iErr = St7.St7GetPropertyNumByIndex(1, St7.tyBEAM, i, ref PropNum);
                    if (CheckiErr(iErr)) { return; };
                    iList.Add(PropNum);
                }
            }
            for (int i = 0; i < iList.Count; i++)
            {
                iList[i] = iList[i] - 1;
            }

            //set beams to biggest sections (to avoid instabilities)
            foreach (int i in iList) { CurrentSectArray[i] = 0; }

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return; };
                e.Cancel = true;
                return;
            }

            stat2 = "setting initial sections...";
            stat3 = "";
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

            foreach (int i in iList)
            {
                iErr = St7.St7SetBeamSectionGeometry(1, i + 1, SType[CurrentSectArray[i]], SectionDoubles[CurrentSectArray[i]]);
                if (CheckiErr(iErr)) { return; };

                stat2 = "setting property " + i.ToString();
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                iErr = St7.St7CalculateBeamSectionProperties(1, i + 1, St7.btFalse, St7.btFalse);
                if (CheckiErr(iErr)) { return; };
            }
            #endregion

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return; };
                e.Cancel = true;
                return;
            }

            #region Set up List of beams for each property
            //########################################################
            //####### Set up List of beams for each property #########
            //########################################################

            int[] PropMapping = new int[nBeams];
            int[] Prop_Count = new int[nBeams];
            bool[] Eval_Beam = new bool[nBeams];
            double[] BeamLength = new double[nBeams];

            for (int i = 0; i < nBeams; i++)
            {
                int PropNum = 0;
                iErr = St7.St7GetElementProperty(1, St7.tyBEAM, i + 1, ref PropNum);
                if (CheckiErr(iErr)) { return; };
                PropMapping[i] = PropNum;
                Prop_Count[PropNum - 1]++;
                propList[PropNum - 1].Add(i);

                foreach (int p in iList)
                {
                    if (PropNum == p + 1) { Eval_Beam[i] = true; break; }
                }
                iErr = St7.St7GetElementData(1, St7.tyBEAM, i + 1, ref BeamLength[i]);
                if (CheckiErr(iErr)) { return; };
            }
            #endregion

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return; };
                e.Cancel = true;
                return;
            }

            int[] units = new int[] { St7.luMILLIMETRE, St7.fuNEWTON, St7.suMEGAPASCAL, St7.muKILOGRAM, St7.tuCELSIUS, St7.euJOULE };
            iErr = St7.St7ConvertUnits(1, units);
            if (CheckiErr(iErr)) { return; };
            iErr = St7.St7SaveFileTo(1, optFolder + @"\iter 0.st7");
            if (CheckiErr(iErr)) { return; };

            //initial solve and open results file
            stat2 = "running solver...";
            stat3 = "";
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
            int NumPrimary = new int();
            int NumSecondary = new int();
            RunSolver(sCase, ref NumPrimary, ref NumSecondary);
            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return; };
                e.Cancel = true;
                return;
            }
            iErr = St7.St7CloseResultFile(1);
            if (CheckiErr(iErr)) { return; };

            //set up load cases
            if (ResList_stress.Count == 0)
            {
                for (int i = 1; i < NumPrimary + NumSecondary; i++) ResList_stress.Add(i);
            }
            if (ResList_def.Count == 0)
            {
                for (int i = 1; i < NumPrimary + NumSecondary; i++) ResList_def.Add(i);
            }
            if (optDeflections)
            {
                //add 1 to cases as virtual load case will be created
                for (int i = 0; i < ResList_stress.Count; i++)
                {
                    if (ResList_stress[i] > NumPrimary)
                    { ResList_stress[i]++; }
                }
                for (int i = 0; i < ResList_def.Count; i++)
                {
                    if (ResList_def[i] > NumPrimary)
                    { ResList_def[i]++; }
                }
                iErr = St7.St7NewLoadCase(1, "Virtual Load");
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7GetNumLoadCase(1, ref virtual_case);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7EnableLoadCase(1, virtual_case);
                if (CheckiErr(iErr)) { return; };
            }

            init = false;
            bool stress_satisfied = true;
            bool[] def_governed = new bool[nBeams];

            //####################################
            //############## Loop ################
            //####################################
            for (int iter = 1; iter < iter_max; iter++)
            {
                int changes = 0;

                string sOutPathVirtualStresses = System.IO.Path.Combine(optFolder, "virtual stresses" + iter.ToString() + ".txt");
                sb_virtual.Append("TITLE Virtual stresses\n");
                looping = true;
                stat = "Iteration: " + iter.ToString();
                stat2 = "";
                stat3 = Environment.NewLine + "ITERATION: " + iter.ToString(); ;
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
                {
                    for (int iter_stress = 1; iter_stress < 50; iter_stress++)
                    {
                        int changes_stress = 0;
                        stress_satisfied = true;

                        foreach (int p in iList)
                        { if (!def_governed[p]) { NewSectArray[p] = 0;} }

                        //solve and open results file
                        stat2 = "running solver...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                        if (worker.CancellationPending)
                        {
                            iErr = St7.St7CloseFile(1);
                            if (CheckiErr(iErr)) { return; };
                            iErr = St7.St7Release();
                            if (CheckiErr(iErr)) { return; };
                            e.Cancel = true;
                            return;
                        }

                        //collect results
                        stat2 = "collecting results...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        foreach (int ResCase in ResList_stress)
                        {
                            stat2 = "collecting stress results for case no " + ResCase.ToString() + "...";
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                            foreach (int p in iList) //loop through properties
                            {
                                foreach (int i in propList[p])
                                {
                                    int NumPoints = 0;
                                    int NumColumns = 0;
                                    double[] BeamPos = new double[St7.kMaxBeamResult];
                                    iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, i + 1, 1, ResCase, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                                    if (CheckiErr(iErr)) { return; };
                                    double A_x_max = Math.Abs(BeamResults[St7.ipBeamAxialF]);
                                    double M_11_max = Math.Abs(BeamResults[St7.ipBeamBM2]);
                                    double M_22_max = Math.Abs(BeamResults[St7.ipBeamBM1]);

                                    for (int j = 1; j < NumPoints; j++)
                                    {
                                        double A_x_max_j = Math.Abs(BeamResults[j * NumColumns + St7.ipBeamAxialF]);
                                        double M_11_max_j = Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM2]);
                                        double M_22_max_j = Math.Abs(BeamResults[j * NumColumns + St7.ipBeamBM1]);
                                        if (A_x_max_j > A_x_max) { A_x_max = A_x_max_j; }
                                        if (M_11_max_j > M_11_max) { M_11_max = M_11_max_j; }
                                        if (M_22_max_j > M_22_max) { M_22_max = M_22_max_j; }
                                    }

                                    A_x[i] = Math.Max(A_x_max, A_x[i]);
                                    M_11[i] = Math.Max(M_11_max, M_11[i]);
                                    M_22[i] = Math.Max(M_22_max, M_22[i]);
                                }
                            }
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

                        //choose sections
                        stat2 = "choosing sections...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        foreach (int p in iList) //loop through property groups
                        {
                            foreach (int i in propList[p]) //loop through beams in each property list
                            {
                                for (int s = NewSectArray[p]; s < nSections; s++) //find minimum weight that satisfies strength constraint
                                {
                                    double stress = Stress(A_x[i], M_11[i], M_22[i], A[s], I11[s], I22[s], BeamLength[s], Z11[s], Z22[s]);
                                    if (stress < UtilMax * DesignStress)
                                    {
                                        NewSectArray[p] = s;
                                        break;
                                    }
                                    else if (s == (nSections - 1))
                                    {
                                        NewSectArray[p] = s;
                                        if (stress > UtilMax * DesignStress) stress_satisfied = false;
                                        break;
                                    }
                                }
                            }
                        }

                        //update sections
                        UpdateSections(CurrentSectArray, NewSectArray, incPrev, inc, ref changes_stress);

                        if (changes_stress > 0) { stat2 = String.Format("stress iteration {0}: {1} section changes",iter_stress, changes_stress); }
                        else { stat2 = stat2 = String.Format("stress iteration {0}: sizing for stresses converged", iter_stress); }
                        stat3 = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() +" - stress "+ iter_stress.ToString() + ".st7");
                        if (CheckiErr(iErr)) { return; };

                        changes += changes_stress;
                        if (changes_stress == 0) { break; }
                    }
                }

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
                    for (int iter_def = 1; iter_def < 50; iter_def++)
                    {
                        int changes_def = 0;

                        //solve and open results file
                        stat2 = "running solver...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                        if (worker.CancellationPending)
                        {
                            iErr = St7.St7CloseFile(1);
                            if (CheckiErr(iErr)) { return; };
                            iErr = St7.St7Release();
                            if (CheckiErr(iErr)) { return; };
                            e.Cancel = true;
                            return;
                        }

                        //reset variables
                        for (int i = 0; i < nBeams; i++)
                        {
                            A_x[i] = 1;
                            M_11[i] = 1;
                            M_22[i] = 1;
                        }

                        //collect worst case deflection
                        stat2 = "applying virtual load...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        double def_max = 0;
                        int def_node = 0;
                        double[] virtual_load = new double[3];
                        foreach (int ResCase in ResList_def)
                        {
                            stat2 = "collecting deflection results for case no " + ResCase.ToString();
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                            for (int i = 0; i < nNodes; i++)
                            {
                                iErr = St7.St7GetNodeResult(1, St7.rtNodeDisp, i + 1, ResCase, NodeResults);
                                if (CheckiErr(iErr)) { return; };

                                double dx = NodeResults[0];
                                double dy = NodeResults[1];
                                double dz = NodeResults[2];
                                double def = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                                if (def > def_max)
                                {
                                    def_max = def;
                                    def_node = i + 1;
                                    virtual_load[0] = dx / def;
                                    virtual_load[1] = dy / def;
                                    virtual_load[2] = dz / def;
                                }
                            }
                        }
                        stat2 = String.Format("max def: {0:0.0}mm", def_max);
                        stat3 = "";
                        string sDef = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        iErr = St7.St7CloseResultFile(1);
                        if (CheckiErr(iErr)) { return; };

                        //apply unit force to worst case node
                        iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, virtual_load);
                        if (CheckiErr(iErr)) { return; };

                        //solve and open results file
                        stat2 = "running solver...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        RunSolver(sCase, ref NumPrimary, ref NumSecondary);
                        if (worker.CancellationPending)
                        {
                            iErr = St7.St7CloseFile(1);
                            if (CheckiErr(iErr)) { return; };
                            iErr = St7.St7Release();
                            if (CheckiErr(iErr)) { return; };
                            e.Cancel = true;
                            return;
                        }

                        //collect results
                        stat2 = "collecting results...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                        foreach (int ResCase in ResList_stress)
                        {
                            stat2 = "collecting stress results for case no " + ResCase.ToString() + "...";
                            stat3 = "";
                            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                            foreach (int p in iList) //loop through properties
                            {
                                foreach (int i in propList[p])
                                {
                                    int NumPoints = 0;
                                    int NumColumns = 0;
                                    double[] BeamPos = new double[St7.kMaxBeamResult];
                                    iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, i + 1, 8, ResCase, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                                    if (CheckiErr(iErr)) { return; };
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
                                    A_x[i] *= (A_x_addition / NumPoints);
                                    M_11[i] *= (M_11_addition / NumPoints);
                                    M_22[i] *= (M_22_addition / NumPoints);
                                }
                            }
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
                        int[] CurrentSectArray_temp = new int[nProps];
                        CurrentSectArray.CopyTo(CurrentSectArray_temp, 0);
                        CurrentSectArray.CopyTo(NewSectArray, 0);
                        while (def_approx > def_limit)
                        {
                            double[] group_def_current = new double[nProps];
                            double[] group_mass_current = new double[nProps];
                            double[,] group_def_new = new double[nProps, nSections];
                            double[,] group_mass_new = new double[nProps, nSections];
                            double[,] group_efficiency = new double[nProps, nSections];
                            double best_efficiency = 0;
                            int[] ibest_efficiency = new int[2];

                            //Calc prop group current deflection and mass contributions
                            foreach (int p in iList)
                            {
                                int iSect = CurrentSectArray_temp[p];
                                NewSectArray[p] = iSect;

                                foreach (int i in propList[p])
                                {
                                    group_def_current[p] += Deflection(A_x[i], M_11[i], M_22[i], A[iSect], I11[iSect], I22[iSect], BeamLength[i]);
                                    group_mass_current[p] += BeamLength[i] * A[iSect] * 0.00000000785;

                                    //Calc prop group new deflections and masses
                                    for (int s = 0; s < nSections; s++)
                                    {
                                        group_def_new[p, s] += Deflection(A_x[i], M_11[i], M_22[i], A[s], I11[s], I22[s], BeamLength[i]);
                                        group_mass_new[p, s] += BeamLength[i] * A[s] * 0.00000000785;
                                    }
                                }

                                //Calc efficiencies
                                for (int s = 0; s < nSections; s++)
                                {
                                    if (group_mass_new[p, s] - group_mass_current[p] != 0) group_efficiency[p, s] = (group_def_current[p] - group_def_new[p, s]) / (group_mass_new[p, s] - group_mass_current[p]);
                                    else group_efficiency[p, s] = 0;
                                    //Choose most efficient
                                    if (group_efficiency[p, s] > best_efficiency && (group_def_new[p, s] - group_def_current[p]) < 0)
                                    {
                                        best_efficiency = group_efficiency[p, s];
                                        ibest_efficiency = new int[] { p, s };
                                    }
                                }
                            }

                            int property = ibest_efficiency[0];
                            int section = ibest_efficiency[1];
                            NewSectArray_def[property] = section;
                            NewSectArray[property] = section;
                            CurrentSectArray_temp[property] = section;

                            def_approx += (group_def_new[property, section] - group_def_current[property]);
                        }

                        //calc current mass
                        double new_mass = 0;
                        foreach (int p in iList)
                        {
                            int iSect = NewSectArray[p];
                            foreach (int i in propList[p])
                            {
                                new_mass += BeamLength[i] * A[iSect] * 0.00000000785;
                            }
                        }
                        stat2 = String.Format("mass (of selection): {0:0.0}T", new_mass);
                        stat3 = "";
                        string sMass = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        //update sections
                        UpdateSections(CurrentSectArray, NewSectArray, incPrev, inc, ref changes_def);
                        foreach (int p in iList)
                        { if (inc[p] > 0) def_governed[p] = true; }

                        if (changes_def > 0) { stat2 = String.Format("def iteration {0}: {1} section changes", iter_def, changes_def) +", "+ sMass + ", " + sDef; }
                        else { stat2 = stat2 = String.Format("def iteration {0}: sizing for deflection converged", iter_def) + ", " + sMass + ", " + sDef; }
                        stat3 = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + " - deflection " + iter_def.ToString() + ".st7");
                        if (CheckiErr(iErr)) { return; };

                        changes += changes_def;
                        if (changes_def == 0) { break; }
                    }
                }

                iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + ".st7");
                if (CheckiErr(iErr)) { return; };

                if (worker.CancellationPending)
                {
                    iErr = St7.St7CloseFile(1);
                    if (CheckiErr(iErr)) { return; };
                    iErr = St7.St7Release();
                    if (CheckiErr(iErr)) { return; };
                }

                if (looping) { DampingDown = 1.0; }// 0.4; }
                if (changes == 0) { break; }
            }

            //#####################################################################################

            //Set Property names:
            foreach (int i in iList)
            {
                string sPropertyName = D1[CurrentSectArray[i]].ToString() + " x " + D2[CurrentSectArray[i]].ToString() + " x " + T1[CurrentSectArray[i]].ToString() + " x " + T2[CurrentSectArray[i]].ToString();
                iErr = St7.St7SetPropertyName(1, St7.tyBEAM, i + 1, sPropertyName);
            }

            iErr = St7.St7SaveFileTo(1, optFolder + @"/Optimised.st7");
            if (CheckiErr(iErr)) { return; };
            iErr = St7.St7SaveFileTo(1, sSt7OptimisedPath);
            if (CheckiErr(iErr)) { return; };
            iErr = St7.St7CloseFile(1);
            if (CheckiErr(iErr)) { return; };
            iErr = St7.St7Release();
            if (CheckiErr(iErr)) { return; };

            stat = "complete";
            stat2 = "";
            stat3 = Environment.NewLine + "Optimisation completed at: " + DateTime.Now;
            init = false;
            worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

            if (!stress_satisfied) { MessageBox.Show("Warning: One or more beams are still overstressed!"); }
            else if (changed == 0) { MessageBox.Show("Section sizing has converged!"); }
            else { MessageBox.Show("Section sizing has NOT converged. Maximum number of iterations reached."); }
        }
        private static void SetInputs(DoWorkEventArgs e)
        {
            List<object> args = (List<object>)e.Argument;
            file = (string)args[0];
            iList = (List<int>)args[1];
            ResList_stress = (List<int>)args[2];
            sCase = (Solver)args[3];
            optDeflections = (bool)args[4];
            ResList_def = (List<int>)args[5];
            def_limit = (double)args[6];
            optStresses = (bool)args[7];
        }
        private static void CollectSections()
        {
            int iErr;
            string filePath = System.IO.Path.GetTempPath() + "Section_CSV.txt";
            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("section data file does not exist. window");
                iErr = St7.St7CloseFile(1);
                if (CheckiErr(iErr)) { return; };
                iErr = St7.St7Release();
                if (CheckiErr(iErr)) { return; };
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

                    D1.Add(Convert.ToDouble(values[0]));
                    D2.Add(Convert.ToDouble(values[1]));
                    D3.Add(Convert.ToDouble(values[2]));
                    T1.Add(Convert.ToDouble(values[3]));
                    T2.Add(Convert.ToDouble(values[4]));
                    T3.Add(Convert.ToDouble(values[5]));
                    A.Add(Convert.ToDouble(values[6]));
                    Z11.Add(Convert.ToDouble(values[7]));
                    Z22.Add(Convert.ToDouble(values[8]));
                    SType.Add(Convert.ToInt32(values[9]));
                    I11.Add(Convert.ToDouble(values[10]));
                    I22.Add(Convert.ToDouble(values[11]));
                }
            }

            if (D1.Count == 0)
            {
                MessageBox.Show("No section properties found.");
                return;
            }

            SectionDoubles = new double[D1.Count + 1][];
            for (int i = 0; i < D1.Count; i++) { SectionDoubles[i] = new double[] { D1[i], D2[i], D3[i], T1[i], T2[i], T3[i] }; }
        }
        private static void RunSolver(Solver sCase, ref int NumPrimary, ref int NumSecondary)
        {
            int iErr;
            switch (sCase)
            {
                case Solver.linear:
                    iErr = St7.St7SetResultFileName(1, sSt7LSAPath);
                    if (CheckiErr(iErr)) { return; };
                    iErr = St7.St7RunSolver(1, St7.stLinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                    if (CheckiErr(iErr)) { return; };
                    sSt7ResPath = sSt7LSAPath;
                    break;
                case Solver.nonlin:
                    iErr = St7.St7SetResultFileName(1, sSt7NLAPath);
                    if (CheckiErr(iErr)) { return; };
                    iErr = St7.St7RunSolver(1, St7.stNonlinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                    if (CheckiErr(iErr)) { return; };
                    sSt7ResPath = sSt7NLAPath;
                    break;
                case Solver.frequency:
                    iErr = St7.St7SetResultFileName(1, sSt7FreqPath);
                    if (CheckiErr(iErr)) { return; };
                    iErr = St7.St7RunSolver(1, St7.stNaturalFrequencySolver, St7.smProgressRun, St7.btTrue);
                    if (CheckiErr(iErr)) { return; };
                    sSt7ResPath = sSt7NLAPath;
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
        private static void UpdateSections(int[] CurrentSectArray, int[] NewSectArray, double[] incPrev, double[] inc, ref int changes)
        {
            int iErr = 0;
            foreach (int i in iList)
            {
                incPrev[i] = inc[i];

                if ((NewSectArray[i] - CurrentSectArray[i]) > 0)
                {
                    inc[i] = (NewSectArray[i] - CurrentSectArray[i]);// * DampingUp;
                }
                else if ((NewSectArray[i] - CurrentSectArray[i]) < 0)
                {
                    inc[i] = (NewSectArray[i] - CurrentSectArray[i]);// * DampingDown;
                }
                else inc[i] = 0;

                if (inc[i] != 0)
                {
                    CurrentSectArray[i] += Convert.ToInt32(inc[i]);
                    iErr = St7.St7SetBeamSectionGeometry(1, i + 1, SType[CurrentSectArray[i]], SectionDoubles[CurrentSectArray[i]]);
                    if (CheckiErr(iErr)) { return; };
                    iErr = St7.St7CalculateBeamSectionProperties(1, i + 1, St7.btFalse, St7.btFalse);
                    if (CheckiErr(iErr)) { return; };
                    changes++;
                    if (inc[i] != -incPrev[i])
                    {
                        looping = false;
                    }
                }
                sb.Append(CurrentSectArray[i].ToString() + ",");
            }
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

                Stress = Math.Abs(A_x) / A / chi_n + M_11 / Z11 + M_22 / Z22;
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

                return true;
            }
            return false;
        }

        #region variables
        private static List<double> A = new List<double>();
        private static List<double> D1 = new List<double>();
        private static List<double> D2 = new List<double>();
        private static List<double> D3 = new List<double>();
        private static List<double> T1 = new List<double>();
        private static List<double> T2 = new List<double>();
        private static List<double> T3 = new List<double>();
        private static List<double> I11 = new List<double>();
        private static List<double> I22 = new List<double>();
        private static List<double> Z11 = new List<double>();
        private static List<double> Z22 = new List<double>();
        private static List<int> SType = new List<int>();

        private static string file = "";
        private static List<int> iList = new List<int>();
        private static List<int> ResList_stress = new List<int>();
        private static List<int> ResList_def = new List<int>();
        private static Solver sCase = new Solver();
        private static bool optDeflections = new bool();
        private static bool optStresses = new bool();
        private static double def_limit = new double();

        private static string sSt7ResPath = "";
        private static string sSt7LSAPath = "";
        private static string sSt7NLAPath = "";
        private static string sSt7FreqPath = "";

        private static bool looping = true;
        private static int changed = 0;
        private static StringBuilder sb = new StringBuilder();
        private static double DampingUp = 1.0;
        private static double DampingDown = 0;
        private static double[][] SectionDoubles;

        public enum Solver { linear, nonlin, frequency }
        #endregion
    }
}
