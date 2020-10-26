﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
            double DampingUp = 1.0;//0.6;
            double DampingDown = 1.0;//0.4;
            int iter_max = 50;
            int changed = 0;
            bool stress_satisfied = true;

            //string builders
            StringBuilder sb = new StringBuilder(100);
            StringBuilder sb_virtual = new StringBuilder(100);

            //file paths
            string sBaseFile = "";
            sBaseFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), System.IO.Path.GetFileNameWithoutExtension(file));
            string optFolder = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), "Optimisation results");
            System.IO.Directory.CreateDirectory(optFolder);
            string sOutPath = System.IO.Path.Combine(optFolder, "Section changes.txt");
            try { System.IO.File.Delete(sOutPath); }
            catch { }
            string sSt7LSAPath = sBaseFile + " - optimised.LSA";
            string sSt7NLAPath = sBaseFile + " - optimised.NLA";
            string sSt7FreqPath = sBaseFile + " - optimised.NFA";
            string sSt7BucPath = sBaseFile + " - optimised.LBA";
            string sSt7ResPath = "";
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

            double[][] SectionDoubles = new double[nSections + 1][];
            for (int i = 0; i < nSections; i++) { SectionDoubles[i] = new double[] { D1[i], D2[i], D3[i], T1[i], T2[i], T3[i] };}
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

            init = false;

            //####################################
            //############## Loop ################
            //####################################
            #region LOOP
            for (int iter = 1; iter < iter_max; iter++)
            {
                string sOutPathVirtualStresses = System.IO.Path.Combine(optFolder, "virtual stresses" + iter.ToString() + ".txt");
                sb_virtual.Append("TITLE Virtual stresses\n");
                bool looping = true;
                stat = "Iteration: " + iter.ToString();
                stat2 = "";
                stat3 = Environment.NewLine + "ITERATION: " + iter.ToString(); ;
                if (changed > 0) { stat2 = changed.ToString() + " changes in previous iteration"; }
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });


                //outer loop

                //optimise stresses loop

                //optimise deflections loop







                #region Analyse and Collect Results
                //#############################################
                //####### Analyse and Collect results #########
                //#############################################

                double[] BeamPos = new double[St7.kMaxBeamResult];
                int NumPrimary = new int();
                int NumSecondary = new int();
                double Freq = 0;
                double FreqReq = 5;

                stat2 = "running solver...";
                stat3 = "";
                worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

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

                        sSt7ResPath = sSt7FreqPath;
                        iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                        if (CheckiErr(iErr)) { return; };

                        double[] ModalRes = new double[10];
                        iErr = St7.St7GetModalResultsNFA(1, 1, ModalRes);
                        Freq = ModalRes[0];

                        iErr = St7.St7CloseResultFile(1);
                        if (CheckiErr(iErr)) { return; };
                        break;
                }

                if (iter == 1)
                {
                    if (ResList_stress.Count == 0)
                    {
                        for (int i = 1; i < NumPrimary + NumSecondary; i++)
                        {
                            ResList_stress.Add(i);
                        }
                    }
                    if (ResList_def.Count == 0)
                    {
                        for (int i = 1; i < NumPrimary + NumSecondary; i++)
                        {
                            ResList_def.Add(i);
                        }
                    }
                    if (optDeflections)
                    {
                        iErr = St7.St7NewLoadCase(1, "Virtual Load");
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7GetNumLoadCase(1, ref virtual_case);
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7EnableLoadCase(1, virtual_case);
                        if (CheckiErr(iErr)) { return; };
                    }
                }

                double def_max = 0;
                int def_node = 0;
                int def_case = 0;
                bool def_exceeded = false;

                //Collect beam stresses
                if (!optDeflections)
                {
                    //reset variables
                    for (int i = 0; i < nBeams; i++)
                    {
                        A_x[i] = 0;
                        M_11[i] = 0;
                        M_22[i] = 0;
                    }

                    iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                    if (CheckiErr(iErr)) { return; };

                    foreach (int ResCase in ResList_stress)
                    {
                        stat2 = "collecting stress results for case no " + ResCase.ToString() +"...";
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        for (int i = 0; i < nBeams; i++)
                        {
                            if (Eval_Beam[i])
                            {
                                int NumPoints = 0;
                                int NumColumns = 0;
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

                                //iErr = St7.St7GetBeamResultArray(1, St7.rtBeamDisp, St7.stBeamLocal, i + 1, 3, ResCase, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                            }
                        }
                    }
                    iErr = St7.St7CloseResultFile(1);
                    if (CheckiErr(iErr)) { return; };
                }

                //Collect beam virtual stresses
                if (optDeflections)
                {
                    double[] virtual_load = new double[3];

                    //collect worst case deflections
                    iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                    if (CheckiErr(iErr)) { return; };
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
                                def_case = ResCase;
                                virtual_load[0] = dx / def;
                                virtual_load[1] = dy / def;
                                virtual_load[2] = dz / def;
                            }
                        }
                        stat2 = String.Format("max displacement is: {0:0.0}mm, \nload case number: {1}", def_max, def_case);
                        stat3 = stat2;
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                    }
                    iErr = St7.St7CloseResultFile(1);
                    if (CheckiErr(iErr)) { return; };

                    //check if deflection limit exceeded
                    if (def_max > def_limit) { def_exceeded = true; }

                    //apply unit force to worst case node
                    iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, virtual_load);
                    if (CheckiErr(iErr)) { return; };

                    stat2 = "running solver...";
                    stat3 = "";
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                    //re-run solver
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

                            sSt7ResPath = sSt7FreqPath;
                            iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                            if (CheckiErr(iErr)) { return; };

                            double[] ModalRes = new double[10];
                            iErr = St7.St7GetModalResultsNFA(1, 1, ModalRes);
                            Freq = ModalRes[0];

                            iErr = St7.St7CloseResultFile(1);
                            if (CheckiErr(iErr)) { return; };
                            break;
                    }

                    //delete unit force on worst case node
                    iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, new double[] { 0, 0, 0 });
                    if (CheckiErr(iErr)) { return; };

                    //collect beam results
                    int[] ResList_virtual = new int[] { def_case, virtual_case };
                    iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                    if (CheckiErr(iErr)) { return; };

                    //reset variables
                    for (int i = 0; i < nBeams; i++)
                    {
                        A_x[i] = 1;
                        M_11[i] = 1;
                        M_22[i] = 1;
                    }

                    foreach (int ResCase in ResList_virtual)
                    {
                        stat2 = "collecting virtual results for case no " + ResCase.ToString();
                        stat3 = "";
                        worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });

                        for (int i = 0; i < nBeams; i++)
                        {
                            if (Eval_Beam[i])
                            {
                                int NumPoints = 0;
                                int NumColumns = 0;
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
                }
                #endregion

                if (worker.CancellationPending)
                {
                    iErr = St7.St7CloseFile(1);
                    if (CheckiErr(iErr)) { return; };
                    iErr = St7.St7Release();
                    if (CheckiErr(iErr)) { return; };
                    e.Cancel = true;
                    //Environment.Exit(0);
                    return;
                }

                #region Set best section
                //##################################
                //####### Set best section #########
                //##################################

                changed = 0;
                double[] stressA = new double[nBeams];
                stress_satisfied = true;
                foreach (int i in iList) { NewSectArray[i] = 0; }

                #region calculate stresses (true and virtual)
                if ((sCase == Solver.linear || sCase == Solver.nonlin) && !optDeflections)
                {
                    for (int i = 0; i < nBeams; i++)
                    {
                        if (Eval_Beam[i])
                        {
                            for (int j = NewSectArray[PropMapping[i] - 1]; j < nSections; j++)
                            {
                                stressA[i] = A_x[i] / A[j] + M_11[i] / Z11[j] + M_22[i] / Z22[j];
                                if (stressA[i] < UtilMax * DesignStress)
                                {
                                    NewSectArray[PropMapping[i] - 1] = j;
                                    break;
                                }
                                else if (j == (nSections - 1))
                                {
                                    NewSectArray[PropMapping[i] - 1] = j;
                                    if (stressA[i] > UtilMax * DesignStress) stress_satisfied = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (optDeflections) //average stress based for deflections
                {
                    // virtual stresses
                    #region virtual stresses

                    double def_approx = def_max;
                    int[] CurrentSectArray_temp = new int[nProps];
                    CurrentSectArray.CopyTo(CurrentSectArray_temp, 0);
                    CurrentSectArray.CopyTo(NewSectArray, 0);
                    double total_mass = 0;

                    while (def_approx > def_limit)
                    {
                        double[] group_def_current = new double[nProps];
                        double[] group_mass_current = new double[nProps];
                        double[,] group_def_new = new double[nProps, nSections];
                        double[,] group_mass_new = new double[nProps, nSections];
                        double[,] group_efficiency = new double[nProps, nSections];
                        double best_efficiency = 0;
                        int[] ibest_efficiency = new int[2];
                        total_mass = 0;

                        //Calc prop group current deflection and mass contributions
                        foreach (int p in iList)
                        {
                            int iSect = CurrentSectArray_temp[p];
                            NewSectArray[p] = iSect;

                            foreach (int i in propList[p])
                            {
                                group_def_current[p] += Optimisation.Deflection(A_x[i], M_11[i], M_22[i], A[iSect], I11[iSect], I22[iSect], BeamLength[i]);
                                group_mass_current[p] += BeamLength[i] * A[iSect] * 0.00000000785;

                                //Calc prop group new deflections and masses
                                for (int s = 0; s < nSections; s++)
                                {
                                    group_def_new[p, s] += Optimisation.Deflection(A_x[i], M_11[i], M_22[i], A[s], I11[s], I22[s], BeamLength[i]);
                                    group_mass_new[p, s] += BeamLength[i] * A[s] * 0.00000000785;
                                }
                            }
                            total_mass += group_mass_current[p];


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

                    double new_mass = 0;
                    foreach (int p in iList)
                    {
                        int iSect = NewSectArray[p];
                        foreach (int i in propList[p])
                        {
                            new_mass += BeamLength[i] * A[iSect] * 0.00000000785;
                        }
                    }
                    stat2 = String.Format("total mass (of beam selection): {0:0.0}T", new_mass);
                    stat3 = stat2;
                    worker.ReportProgress(0, new object[] { stat, stat2, stat3, init });
                    #endregion virtual stresses
                }
                else if (false) //average stress based for deflections
                {
                    // virtual stresses
                    #region virtual stresses
                    double Factor = def_limit / def_max;

                    double stressAverage = 0;
                    double total_deflection = 0;
                    double[] stressVirtual = new double[nBeams];
                    double[] deflectionVirtual = new double[nBeams];

                    //Calculate current deflection
                    for (int i = 0; i < nBeams; i++)
                    {
                        int iSect = CurrentSectArray[PropMapping[i] - 1];
                        deflectionVirtual[i] = Optimisation.Deflection(A_x[i], M_11[i], M_22[i], A[iSect], I11[iSect], I22[iSect], BeamLength[i]);
                        total_deflection += deflectionVirtual[i];
                    }
                    //MessageBox.Show(String.Format("Predicted deflection: {0:0.00}mm, \nActual deflection: {1:0.00}mm",total_deflection,def_max));

                    //Calculate current stress average
                    foreach (int p in iList)
                    {
                        foreach (int i in propList[p])
                        {
                            if (Eval_Beam[i])
                            {
                                int iSect = CurrentSectArray[p];
                                stressVirtual[i] = Optimisation.Stress(A_x[i], M_11[i], M_22[i], A[iSect], I11[iSect], I22[iSect], BeamLength[i]);
                                stressAverage += stressVirtual[i];
                            }
                        }
                    }
                    stressAverage = stressAverage / nBeams;

                    for (int i = 0; i < nBeams; i++)
                    {
                        sb_virtual.Append((i + 1).ToString() + " " + stressVirtual[i].ToString() + " " + stressVirtual[i].ToString() + "\n");
                    }

                    //choose new sections
                    for (int i = 0; i < nBeams; i++)
                    {
                        if (Eval_Beam[i])
                        {
                            for (int j = 0; j < nSections; j++)
                            {
                                stressVirtual[i] = Optimisation.Stress(A_x[i], M_11[i], M_22[i], A[j], I11[j], I22[j], BeamLength[i]);

                                if (stressVirtual[i] < (stressAverage * Math.Pow(Factor, 1.5)))
                                {
                                    NewSectArray_def[PropMapping[i] - 1] += j;
                                    break;
                                }
                                else if (j == (nSections - 1))
                                {
                                    NewSectArray_def[PropMapping[i] - 1] += j;
                                    break;
                                }
                            }
                        }
                    }
                    for (int p = 0; p < nProps; p++)
                    {
                        if (Prop_Count[p] > 0)
                        {
                            NewSectArray_def[p] /= Prop_Count[p];
                            NewSectArray[p] = Convert.ToInt32(NewSectArray_def[p]);
                        }
                    }

                    //Calculate new stress average
                    for (int i = 0; i < nBeams; i++)
                    {
                        if (Eval_Beam[i])
                        {
                            int iSect = NewSectArray[PropMapping[i] - 1];
                            stressVirtual[i] = Optimisation.Stress(A_x[i], M_11[i], M_22[i], A[iSect], I11[iSect], I22[iSect], BeamLength[i]);
                            stressAverage += stressVirtual[i];
                        }
                    }
                    stressAverage = stressAverage / nBeams;

                    for (int i = 0; i < nBeams; i++)
                    {
                        sb_virtual.Append((i + 1).ToString() + " " + stressVirtual[i].ToString() + " " + stressVirtual[i].ToString() + "\n");
                    }

                    #endregion virtual stresses
                }
                else
                {
                    double stressAverage = 0;

                    for (int i = 0; i < nBeams; i++)
                    {
                        if (Eval_Beam[i])
                        {
                            //stressA[i] = A_x[i] / A[CurrentSectArray[PropList[i] - 1]] + M_11[i] / Z11[CurrentSectArray[PropList[i] - 1]] + M_22[i] / Z22[CurrentSectArray[PropList[i] - 1]];
                            stressA[i] = A_x[i] / A[CurrentSectArray[PropMapping[i] - 1]] + M_11[i] / Z11[CurrentSectArray[PropMapping[i] - 1]] / 2 + M_22[i] / Z22[CurrentSectArray[PropMapping[i] - 1]] / 2;
                            stressAverage += stressA[i];
                        }
                    }

                    stressAverage = stressAverage / nBeams;

                    for (int i = 0; i < nBeams; i++)
                    {
                        if (Eval_Beam[i])
                        {
                            for (int j = NewSectArray[PropMapping[i] - 1]; j < nSections; j++)
                            {
                                //stressA[i] = A_x[i] / A[j] + M_11[i] / Z11[j] + M_22[i] / Z22[j];
                                stressA[i] = A_x[i] / A[j] + M_11[i] / Z11[j] / 2 + M_22[i] / Z22[j] / 2;
                                if (stressA[i] < stressAverage * Freq / FreqReq)
                                {
                                    NewSectArray[PropMapping[i] - 1] = j;
                                    break;
                                }
                                else if (j == (nSections - 1))
                                {
                                    NewSectArray[PropMapping[i] - 1] = j;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                foreach (int i in iList)
                {
                    incPrev[i] = inc[i];

                    if ((NewSectArray[i] - CurrentSectArray[i]) > 0)
                    {
                        inc[i] = (NewSectArray[i] - CurrentSectArray[i]) * DampingUp;// DampingUp * (NewSectArray[i] - CurrentSectArray[i]);
                    }
                    else if ((NewSectArray[i] - CurrentSectArray[i]) < 0)
                    {
                        inc[i] = (NewSectArray[i] - CurrentSectArray[i]) * DampingDown;
                        //if (iter < 15) inc[i] = (NewSectArray[i] - CurrentSectArray[i]) * DampingDown;// DampingDown * (NewSectArray[i] - CurrentSectArray[i]);
                        //else inc[i] = 0;
                    }
                    else inc[i] = 0;

                    if (inc[i] != 0)
                    {
                        CurrentSectArray[i] += Convert.ToInt32(inc[i]);
                        iErr = St7.St7SetBeamSectionGeometry(1, i + 1, SType[CurrentSectArray[i]], SectionDoubles[CurrentSectArray[i]]);
                        if (CheckiErr(iErr)) { return; };
                        iErr = St7.St7CalculateBeamSectionProperties(1, i + 1, St7.btFalse, St7.btFalse);
                        if (CheckiErr(iErr)) { return; };
                        changed++;
                        if (inc[i] != -incPrev[i])
                        {
                            looping = false;
                        }
                    }
                    sb.Append(CurrentSectArray[i].ToString() + ",");
                }

                System.IO.File.AppendAllText(sOutPath, sb.ToString() + System.Environment.NewLine);
                sb.Clear();
                System.IO.File.AppendAllText(sOutPathVirtualStresses, sb_virtual.ToString() + System.Environment.NewLine);
                sb_virtual.Clear();
                #endregion

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
                if (changed == 0) { break; }
            }
            #endregion

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
        static void SetInputs(DoWorkEventArgs e)
        {
            List<object> args = (List<object>)e.Argument;
            file = (string)args[0];
            iList = (List<int>)args[1];
            ResList_stress = (List<int>)args[2];
            sCase = (Solver)args[3];
            optDeflections = (bool)args[4];
            ResList_def = (List<int>)args[5];
            def_limit = (double)args[6];
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
        }
        public static double Stress(double A_x,double M_11, double M_22, double A, double I11, double I22, double L)
        {
            double Stress = (A_x / A + M_11 / I11/2 + M_22 / I22/2);// / L;
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
        private static double def_limit = new double();

        public enum Solver { linear, nonlin, frequency }
        #endregion
    }
}
