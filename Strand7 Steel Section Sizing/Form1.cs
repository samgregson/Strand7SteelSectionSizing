using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strand7_Steel_Section_Sizing
{
    public partial class Form1 : Form
    {
        bool initialising;
        string status;
        string status2;
        Timer timer1;
        enum Solver { linear, nonlin, frequency }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initialising = true;
            this.worker.DoWork += worker_DoWork;
            this.worker.ProgressChanged += worker_ProgressChanged;
            this.worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            timer1 = new Timer();
            timer1.Enabled = false;
        }
        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool init = true;
            string stat = "initialising";
            string stat2 = "opening Strand7 file";
            worker.ReportProgress(0, new object[] { stat, stat2, init });
            //#####################################################################################

            int NumPoints = 0;
            int NumColumns = 0;
            int iErr;
            iErr = St7.St7Init();
            CheckiErr(iErr);

            //##########################################
            //########### CODE GOES HERE ###############
            //##########################################
            List<object> args = (List<object>) e.Argument;
            string file = (string) args[0];
            List<int> iList = (List<int>) args[1];
            List<int> ResList_stress = (List<int>)args[2];
            Solver sCase = (Solver)args[3];
            bool optDeflections = (bool)args[4];
            List<int> ResList_def = (List<int>)args[5];
            double def_limit = (double)args[6];

            //open file
            try
            {
                iErr = St7.St7OpenFile(1, file, System.IO.Path.GetTempPath());
                CheckiErr(iErr);
            }
            catch
            {
                iErr = St7.St7Release();
                CheckiErr(iErr);
                e.Cancel = true;
                Environment.Exit(0);
                return;
            }

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                CheckiErr(iErr);
                iErr = St7.St7Release();
                CheckiErr(iErr);
                e.Cancel = true;
                Environment.Exit(0);
                return;
            }

            #region Set constants
            //#############################################
            //############## Set constants ################
            //#############################################
            double UtilMax = 0.99;
            double DesignStress = 355;//157.9;//355/1.1;
            double DampingUp = 1.0;//0.6;
            double DampingDown = 1.0;//0.4;
            int iter_max = 50;

            string sBaseFile = "";
            sBaseFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), System.IO.Path.GetFileNameWithoutExtension(file));

            StringBuilder sb = new StringBuilder(100);
            StringBuilder sb_virtual = new StringBuilder(100);

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

            #region Section Properties
            //##################################################
            //############## Section Properties ################
            //##################################################

            string filePath = System.IO.Path.GetTempPath() + "Section_CSV.txt";

            int changed = 0;
            bool stress_satisfied = true;
            List<double> D1 = new List<double>();
            List<double> D2 = new List<double>();
            List<double> D3 = new List<double>();
            List<double> T1 = new List<double>();
            List<double> T2 = new List<double>();
            List<double> T3 = new List<double>();
            List<double> A = new List<double>();
            List<double> I11 = new List<double>();
            List<double> I22 = new List<double>();
            List<double> Z11 = new List<double>();
            List<double> Z22 = new List<double>();
            List<int> SType = new List<int>();

            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("section data file does not exist.");
                iErr = St7.St7CloseFile(1);
                CheckiErr(iErr);
                iErr = St7.St7Release();
                CheckiErr(iErr);
                e.Cancel = true;
                Environment.Exit(0);
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
                Environment.Exit(0);
            }
            #endregion

            int nSections = D1.Count;

            int nBeams = new int();
            int nNodes = new int();
            iErr = St7.St7GetTotal(1, St7.tyBEAM, ref nBeams);
            CheckiErr(iErr);
            iErr = St7.St7GetTotal(1, St7.tyNODE, ref nNodes);
            CheckiErr(iErr);

            int[] NumProperties = new int[St7.kMaxEntityTotals];
            int[] LastProperty = new int[St7.kMaxEntityTotals];
            iErr = St7.St7GetTotalProperties(1, NumProperties, LastProperty);
            CheckiErr(iErr);
            int nProps = NumProperties[St7.ipBeamPropTotal]; //EDIT
            
            double[] BeamResults = new double[St7.kMaxBeamResult];
            double[] NodeResults = new double[St7.kMaxDisp];
            double[] A_x = new double[nBeams];
            double[] M_11 = new double[nBeams];
            double[] M_22 = new double[nBeams];


            if (nProps < 1)
            {
                MessageBox.Show("No beams sections available");
                Environment.Exit(0);
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
                    CheckiErr(iErr);
                    iList.Add(PropNum);
                }
            }
            for (int i = 0; i < iList.Count; i++)
            {
                iList[i] = iList[i] - 1;
            }

            int[] CurrentSectArray = new int[nProps];
            int[] NewSectArray = new int[nProps];
            double[] NewSectArray_def = new double[nProps];
            double[] inc = new double[nProps];
            double[] incPrev = new double[nProps];
            int virtual_case = 0;

            //set beams to biggest sections (to avoid instabilities)
            foreach (int i in iList){ CurrentSectArray[i] = 0; }

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                CheckiErr(iErr);
                iErr = St7.St7Release();
                CheckiErr(iErr);
                e.Cancel = true;
                Environment.Exit(0);
                return;
            }

            stat2 = "setting initial sections";
            worker.ReportProgress(0, new object[] { stat, stat2, init });

            double[][] SectionDoubles = new double[nSections+1][];

            for (int i = 0; i < nSections; i++)
            {
                stat2 = "setting property " + i.ToString();
                worker.ReportProgress(0, new object[] { stat, stat2, init });
                SectionDoubles[i] = new double[] { D1[i], D2[i], D3[i], T1[i], T2[i], T3[i] };
            }

            foreach (int i in iList)
            {
                iErr = St7.St7SetBeamSectionGeometry(1, i + 1, SType[CurrentSectArray[i]], SectionDoubles[CurrentSectArray[i]]);
                CheckiErr(iErr);
                
                stat2 = "setting property " + i.ToString();
                worker.ReportProgress(0, new object[] { stat, stat2, init });

                iErr = St7.St7CalculateBeamSectionProperties(1, i + 1, St7.btFalse, St7.btFalse);
                CheckiErr(iErr);
            }
            #endregion

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                CheckiErr(iErr);
                iErr = St7.St7Release();
                CheckiErr(iErr);
                e.Cancel = true;
                Environment.Exit(0);
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
                CheckiErr(iErr);
                PropMapping[i] = PropNum;
                Prop_Count[PropNum-1]++;
                propList[PropNum-1].Add(i);

                foreach (int p in iList)
                {
                    if (PropNum == p+1) { Eval_Beam[i] = true; break; }
                }
                iErr = St7.St7GetElementData(1, St7.tyBEAM, i + 1, ref BeamLength[i]);
                CheckiErr(iErr);
            }
            #endregion

            if (worker.CancellationPending)
            {
                iErr = St7.St7CloseFile(1);
                CheckiErr(iErr);
                iErr = St7.St7Release();
                CheckiErr(iErr);
                e.Cancel = true;
                Environment.Exit(0);
                return;
            }

            #region LOOP
            //################################
            //########### LOOP ###############
            //################################

            int[] units = new int[] { St7.luMILLIMETRE, St7.fuNEWTON, St7.suMEGAPASCAL, St7.muKILOGRAM, St7.tuCELSIUS, St7.euJOULE };
            iErr = St7.St7ConvertUnits(1, units);
            CheckiErr(iErr);
            iErr = St7.St7SaveFileTo(1, optFolder + @"\iter 0.st7");
            CheckiErr(iErr);

            init = false;

            for (int iter = 1; iter < iter_max; iter++)
            {
                string sOutPathVirtualStresses = System.IO.Path.Combine(optFolder, "virtual stresses"+iter.ToString()+".txt");
                sb_virtual.Append("TITLE Virtual stresses\n");

                bool looping = true;
                stat = "iteration: " + iter.ToString();
                stat2 = "";
                if (changed > 0) {stat2 = changed.ToString() + " changes in previous iteration";}
                worker.ReportProgress(0, new object[] { stat, stat2, init });

                #region Analyse and Collect Results
                //#############################################
                //####### Analyse and Collect results #########
                //#############################################

                double[] BeamPos = new double[St7.kMaxBeamResult];
                int NumPrimary = new int();
                int NumSecondary = new int();
                double Freq = 0;
                double FreqReq = 5;

                switch (sCase)
                {
                    case Solver.linear:
                        iErr = St7.St7SetResultFileName(1, sSt7LSAPath);
                        CheckiErr(iErr);
                        iErr = St7.St7RunSolver(1, St7.stLinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                        CheckiErr(iErr);
                        sSt7ResPath = sSt7LSAPath;
                        break;
                    case Solver.nonlin:
                        iErr = St7.St7SetResultFileName(1, sSt7NLAPath);
                        CheckiErr(iErr);
                        iErr = St7.St7RunSolver(1, St7.stNonlinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                        CheckiErr(iErr);
                        sSt7ResPath = sSt7NLAPath;
                        break;
                    case Solver.frequency:
                        iErr = St7.St7SetResultFileName(1, sSt7FreqPath);
                        CheckiErr(iErr);
                        iErr = St7.St7RunSolver(1, St7.stNaturalFrequencySolver, St7.smProgressRun, St7.btTrue);
                        CheckiErr(iErr);

                        sSt7ResPath = sSt7FreqPath;
                        iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                        CheckiErr(iErr);

                        double[] ModalRes = new double[10];
                        iErr = St7.St7GetModalResultsNFA(1, 1, ModalRes);
                        Freq = ModalRes[0];

                        iErr = St7.St7CloseResultFile(1);
                        CheckiErr(iErr);
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
                        CheckiErr(iErr);
                        iErr = St7.St7GetNumLoadCase(1, ref virtual_case);
                        CheckiErr(iErr);
                        iErr = St7.St7EnableLoadCase(1, virtual_case);
                        CheckiErr(iErr);
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
                    CheckiErr(iErr);

                    foreach (int ResCase in ResList_stress)
                    {
                        stat2 = "collecting stress results for case no " + ResCase.ToString();
                        worker.ReportProgress(0, new object[] { stat, stat2, init });

                        for (int i = 0; i < nBeams; i++)
                        {
                            if (Eval_Beam[i])
                            {
                                iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, i + 1, 1, ResCase, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                                CheckiErr(iErr);
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
                    CheckiErr(iErr);
                }

                //Collect beam virtual stresses
                if (optDeflections)
                {
                    double[] virtual_load = new double[3];

                    //collect worst case deflections
                    iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                    CheckiErr(iErr);
                    foreach (int ResCase in ResList_def)
                    {
                        stat2 = "collecting deflection results for case no " + ResCase.ToString();
                        worker.ReportProgress(0, new object[] { stat, stat2, init });

                        for (int i = 0; i < nNodes; i++)
                        {
                            iErr = St7.St7GetNodeResult(1, St7.rtNodeDisp, i+1, ResCase, NodeResults);
                            CheckiErr(iErr);

                            double dx = NodeResults[0];
                            double dy = NodeResults[1];
                            double dz = NodeResults[2];
                            double def = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                            if (def > def_max)
                            { 
                                def_max = def;
                                def_node = i+1;
                                def_case = ResCase;
                                virtual_load[0] = dx / def;
                                virtual_load[1] = dy / def;
                                virtual_load[2] = dz / def;
                            }
                        }
                        stat2 = String.Format("max displacement is: {0:0.0}mm,\nload case number: {1}",def_max,def_case);
                        worker.ReportProgress(0, new object[] { stat, stat2, init });
                    }
                    iErr = St7.St7CloseResultFile(1);
                    CheckiErr(iErr);

                    //check if deflection limit exceeded
                    if(def_max > def_limit) { def_exceeded = true; }

                    //apply unit force to worst case node
                    iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, virtual_load);
                    CheckiErr(iErr);

                    //re-run solver
                    switch (sCase)
                    {
                        case Solver.linear:
                            iErr = St7.St7SetResultFileName(1, sSt7LSAPath);
                            CheckiErr(iErr);
                            iErr = St7.St7RunSolver(1, St7.stLinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                            CheckiErr(iErr);
                            sSt7ResPath = sSt7LSAPath;
                            break;
                        case Solver.nonlin:
                            iErr = St7.St7SetResultFileName(1, sSt7NLAPath);
                            CheckiErr(iErr);
                            iErr = St7.St7RunSolver(1, St7.stNonlinearStaticSolver, St7.smBackgroundRun, St7.btTrue);
                            CheckiErr(iErr);
                            sSt7ResPath = sSt7NLAPath;
                            break;
                        case Solver.frequency:
                            iErr = St7.St7SetResultFileName(1, sSt7FreqPath);
                            CheckiErr(iErr);
                            iErr = St7.St7RunSolver(1, St7.stNaturalFrequencySolver, St7.smProgressRun, St7.btTrue);
                            CheckiErr(iErr);

                            sSt7ResPath = sSt7FreqPath;
                            iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                            CheckiErr(iErr);

                            double[] ModalRes = new double[10];
                            iErr = St7.St7GetModalResultsNFA(1, 1, ModalRes);
                            Freq = ModalRes[0];

                            iErr = St7.St7CloseResultFile(1);
                            CheckiErr(iErr);
                            break;
                    }

                    //delete unit force on worst case node
                    iErr = St7.St7SetNodeForce3(1, def_node, virtual_case, new double[] { 0, 0, 0 });
                    CheckiErr(iErr);

                    //collect beam results
                    int[] ResList_virtual = new int[] {def_case,virtual_case };
                    iErr = St7.St7OpenResultFile(1, sSt7ResPath, "", St7.btTrue, ref NumPrimary, ref NumSecondary);
                    CheckiErr(iErr);

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
                        worker.ReportProgress(0, new object[] { stat, stat2, init });

                        for (int i = 0; i < nBeams; i++)
                        {
                            if (Eval_Beam[i])
                            {
                                iErr = St7.St7GetBeamResultArray(1, St7.rtBeamForce, St7.stBeamLocal, i + 1, 8, ResCase, ref NumPoints, ref NumColumns, BeamPos, BeamResults);
                                CheckiErr(iErr);
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
                    CheckiErr(iErr);
                }
                #endregion

                if (worker.CancellationPending)
                {
                    iErr = St7.St7CloseFile(1);
                    CheckiErr(iErr);
                    iErr = St7.St7Release();
                    CheckiErr(iErr);
                    e.Cancel = true;
                    Environment.Exit(0);
                    //return;
                }

                #region Set best section
                //##################################
                //####### Set best section #########
                //##################################

                changed = 0;
                double[] stressA = new double[nBeams];
                stress_satisfied = true;
                foreach (int i in iList) { NewSectArray[i] = 0; NewSectArray_def[i] = 0; }

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
                    int[] CurrentSectArray_temp = CurrentSectArray;

                    //while (def_approx > def_limit)
                    //{
                        double[] group_def_current = new double[nProps];
                        double[] group_mass_current = new double[nProps];
                        double[,] group_def_new = new double[nProps, nSections];
                        double[,] group_mass_new = new double[nProps, nSections];
                        double[,] group_efficiency = new double[nProps, nSections];
                        double best_efficiency = double.PositiveInfinity;
                        int[] ibest_efficiency = new int[2];
                        double total_mass = 0;

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
                                group_efficiency[p, s] = (group_def_current[p] - group_def_new[p, s]) / (group_mass_new[p, s] - group_mass_current[p]);

                                //Choose most efficient
                                if (group_efficiency[p, s] < best_efficiency && (group_def_new[p, s] - group_def_current[p]) < 0)
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

                    //    def_approx += (group_def_new[property, section] - group_def_current[property]);
                    //}

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
                        sb_virtual.Append((i+1).ToString() + " " +stressVirtual[i].ToString() + " " + stressVirtual[i].ToString() + "\n");
                    }

                    //choose new sections
                    for (int i = 0; i < nBeams; i++)
                    {
                        if (Eval_Beam[i])
                        {
                            for (int j = 0; j < nSections; j++)
                            {
                                stressVirtual[i] = Optimisation.Stress(A_x[i], M_11[i], M_22[i], A[j], I11[j], I22[j], BeamLength[i]);

                                if (stressVirtual[i] < (stressAverage * Math.Pow(Factor,1.5)))
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
                else { 
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

                    //int updatedSect = CurrentSectArray[i] + Convert.ToInt32(inc[i]);
                    //CurrentSectArray_double[i] += inc[i];

                    if (inc[i] != 0)
                    {
                        CurrentSectArray[i] += Convert.ToInt32(inc[i]);
                        //CurrentSectArray[i] = updatedSect;
                        //CurrentSectArray[i] = Convert.ToInt32(CurrentSectArray_double[i]);
                        iErr = St7.St7SetBeamSectionGeometry(1, i + 1, SType[CurrentSectArray[i]], SectionDoubles[CurrentSectArray[i]]);
                        CheckiErr(iErr);
                        iErr = St7.St7CalculateBeamSectionProperties(1, i + 1, St7.btFalse, St7.btFalse);
                        CheckiErr(iErr);
                        changed++;
                        if (inc[i] != -incPrev[i])
                        {
                            looping = false;
                        }
                    }
                    sb.Append(CurrentSectArray[i].ToString()+",");
                }

                System.IO.File.AppendAllText(sOutPath, sb.ToString() + System.Environment.NewLine);
                sb.Clear();
                System.IO.File.AppendAllText(sOutPathVirtualStresses, sb_virtual.ToString() + System.Environment.NewLine);
                sb_virtual.Clear();
                #endregion

                iErr = St7.St7SaveFileTo(1, optFolder + @"\iter " + iter.ToString() + ".st7");
                CheckiErr(iErr);

                if (worker.CancellationPending)
                {
                    iErr = St7.St7CloseFile(1);
                    CheckiErr(iErr);
                    iErr = St7.St7Release();
                    CheckiErr(iErr);
                    Environment.Exit(0);
                }

                if (looping) { DampingDown = 1.0; }// 0.4; }
                if (changed == 0)  { break; }
            }
            #endregion

            foreach (int i in iList)
            {
                string sPropertyName = D1[CurrentSectArray[i]].ToString() + " x " +  D2[CurrentSectArray[i]].ToString() + " x " + T1[CurrentSectArray[i]].ToString() + " x " + T2[CurrentSectArray[i]].ToString();
                iErr = St7.St7SetPropertyName(1, St7.tyBEAM, i+1, sPropertyName);
            }

            iErr = St7.St7SaveFileTo(1, optFolder + @"/Optimised.st7");
            CheckiErr(iErr);
            iErr = St7.St7SaveFileTo(1, sSt7OptimisedPath);
            CheckiErr(iErr);
            iErr = St7.St7CloseFile(1);
            CheckiErr(iErr);

            //##########################################
            //############ END OF CODE #################
            //##########################################

            iErr = St7.St7Release();
            CheckiErr(iErr);

            //#####################################################################################
            stat = "complete";
            stat2 = "";
            init = false;
            worker.ReportProgress(0, new object[] { stat, stat2, init });

            if (!stress_satisfied) { MessageBox.Show("Warning: One or more beams are still overstressed!"); }
            else if (changed == 0) { MessageBox.Show("Section sizing has converged!");}
            else { MessageBox.Show("Section sizing has NOT converged. Maximum number of iterations reached."); }
            Environment.Exit(0);
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            if (initialising)
            {
                status += ".";
                if (status == "initialising....")
                {
                    status = "initialising";
                }
                label1.Text = status;
                label1.Refresh();
                label2.Text = status2;
                label2.Refresh();
            }
            else
            {
                timer1.Stop();
            }
        }
        public void updatetext()
        {
            if (initialising)
            {
                if (!timer1.Enabled)
                {
                    label1.Refresh();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Enabled = true;
                    timer1.Interval = 1000;
                    timer1.Start();
                }
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                label1.Text = status;
                label1.Refresh();
                label2.Text = status2;
                label2.Refresh();
            }
        }
        private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            object[] results = (object[])e.UserState;
            status = results[0].ToString();
            status2 = results[1].ToString();
            initialising = (bool) results[2];
            updatetext();
        }
        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Environment.Exit(0);
        }
        public static void CheckiErr(int iErr)
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
                MessageBox.Show(errorstring);
                //Console.WriteLine("");
                //Console.WriteLine("Strand7 API error: " + errorstring);
                //Console.WriteLine("The program has terminated early.");

                string sFilePath = System.IO.Path.GetTempPath() + "API Error Log.txt";
                System.IO.File.WriteAllText(sFilePath, errorstring);

                Environment.Exit(0);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (SecListBox.Text == "")
            { MessageBox.Show("Please provide list of section numbers to operate on."); }
            else if (StressCaseBox.Text == "")
            { MessageBox.Show("Please provide list of result case numbers to operate on."); }
            else
            {
                List<int> sPropList = new List<int>();
                List<int> ResList_stress = new List<int>();
                List<int> ResList_def = new List<int>();
                double def_limit = 0;

                string error = "";
                bool flag = true;

                if (!ConvertString(SecListBox.Text, ref sPropList, ref error))
                {
                    MessageBox.Show(error);
                    return;
                }
                if (!ConvertString(StressCaseBox.Text, ref ResList_stress, ref error))
                {
                    MessageBox.Show(error);
                    return;
                }
                if (Def_checkbox.Checked) 
                {
                    if (!ConvertString(DefCaseBox.Text, ref ResList_def, ref error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    if (!double.TryParse(DefLimitBox.Text,out def_limit) || def_limit <= 0)
                    {
                        MessageBox.Show("input for deflection limit is not valid");
                        return;
                    }
                }

                //message
                string SResList = "";
                string SPropList = "";
                if (ResList_stress.Count > 0) { SResList = string.Join(",", ResList_stress.Select(x => x.ToString()).ToArray()); }
                else { SResList = "All"; }
                if (sPropList.Count > 0) { SPropList = string.Join(",", sPropList.Select(x => x.ToString()).ToArray()); }
                else { SPropList = "All"; }
                //string message = "Result case list: " + SResList + Environment.NewLine + "Properties list: " + SPropList;
                //MessageBox.Show(message);

                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Strand7 file for beam section sizing";
                fdlg.Filter = "Strand7 files (*.st7)|*.st7";
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    List<object> args = new List<object>();

                    string sFile = fdlg.FileName;

                    //Dictionary<string, object> input = new Dictionary<string, object>();
                    //input.Add("sFile", sFile);
                    //input.Add("sPropList", sPropList);
                    //input.Add("ResList_stress", ResList_stress);

                    args.Add(sFile);
                    args.Add(sPropList);
                    args.Add(ResList_stress);
                    if (Button_LSA.Checked && !Button_NLA.Checked) { args.Add(Solver.linear); }
                    else if (!Button_LSA.Checked && Button_NLA.Checked) { args.Add(Solver.nonlin); }
                    args.Add(Def_checkbox.Checked);
                    args.Add(ResList_def);
                    args.Add(def_limit);
                    try { worker.RunWorkerAsync(args); }
                    catch { }
                }
                else
                {
                    this.Close();
                }
            }
        }
        bool ConvertString(string s_in, ref List<int> iList, ref string error)
        {
            List<int> sList = new List<int>();

            char[] splitter = { ',' };
            s_in = string.Join("", s_in.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            string[] str = s_in.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            bool flag = true;
            error = "";

            if (s_in.ToLower().Contains("all"))
            {
                flag = true;
                return flag;
            }
            else
            {
                foreach (string s in str)
                {
                    if (s.Contains("-"))
                    {
                        string[] str_temp = s.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str_temp.Length == 2)
                        {
                            int i_1 = 0;
                            if (Int32.TryParse(str_temp[0], out i_1))
                            {
                                sList.Add(i_1);
                            }
                            else
                            { error += "cannot convert string: '" + str_temp[0] + "' to int"; flag = false; break; }

                            int i_2 = 0;
                            if (Int32.TryParse(str_temp[1], out i_2))
                            {
                                for (int i = i_1 + 1; i <= i_2; i++)
                                { sList.Add(i); }
                            }
                            else
                            { error += "cannot convert string: '" + str_temp[1] + "' to int"; flag = false; break; }
                        }
                        else
                        { error += "cannot convert string: '" + s + "' to int"; flag = false; break; }
                    }
                    else
                    {
                        int i = 0;
                        if (Int32.TryParse(s, out i))
                        {
                            sList.Add(i);
                        }
                        else
                        { error += "cannot convert string: '" + s + "' to int"; flag = false; break; }
                    }
                }
            }

            iList = sList;
            return flag;
        }
    }
}
