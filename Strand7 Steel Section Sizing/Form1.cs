using Newtonsoft.Json;
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
        string status3;
        Timer timer1;
        private BindingList<DeflectionLimit> deflectionLimits;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";

            int iErr;
            iErr = St7.St7Init();
            if (Optimisation.CheckiErr(iErr)) { return; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            deflectionLimits = LoadDeflectionLimits();
            this.deflectionGrid.DataSource = deflectionLimits;
            initialising = true;
            this.worker.DoWork += worker_DoWork;
            this.worker.ProgressChanged += worker_ProgressChanged;
            this.worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            timer1 = new Timer();
            timer1.Enabled = false;
        }
        private BindingList<DeflectionLimit> LoadDeflectionLimits()
        {
            string deflectionSettings = Properties.Settings.Default.deflection_limits;
            var list = JsonConvert.DeserializeObject<BindingList<DeflectionLimit>>(deflectionSettings);

            if (list == null || list.Count == 0)
            {
                list = new BindingList<DeflectionLimit>() { new DeflectionLimit()};
            }
            return list;
        }
        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker1 = sender as BackgroundWorker;
            Optimisation.Optimise(worker1, e);
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
            }
            label1.Text = status;
            label1.Refresh();
            label2.Text = status2;
            label2.Refresh();
            if (status3 != "")
            {
                outputBox.AppendText(status3 + Environment.NewLine);
                outputBox.Refresh();
            }
        }
        private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            object[] results = (object[])e.UserState;
            status = results[0].ToString();
            status2 = results[1].ToString();
            status3 = results[2].ToString();
            initialising = (bool) results[3];
            updatetext();
        }
        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            { MessageBox.Show(e.Error.Message);}
            else if (e.Cancelled)
            { status = "Cancelled"; }
            else
            { status = "Complete"; }
            status2 = "";
            status3 = "";
            updatetext();
            //Environment.Exit(0);
        }
        private void Optimise_Click(object sender, EventArgs e)
        {
            List<List<int>> sPropList = new List<List<int>>();
            List<int> ResList_stress = new List<int>();
            List<int> ResList_def = new List<int>();
            int freq_case = 0;
            double def_limit = 0;
            double stress_limit = 0;
            double freq_limit = 0;

            string error = "";
            bool flag = true;
            
            string sFile = fileBox.Text;

            if (fileBox.Text == "")
            {
                MessageBox.Show(@"Please provide Strand7 file to operate on using the ""Browse"" button.");
                return;
            }

            if (StressCaseBox.Text == "")
            {
                MessageBox.Show("Please provide list of result case numbers to operate on.");
                return;
            }

            if (Stress_checkbox.Checked)
            {
                if (!ConvertString(StressCaseBox.Text, ref ResList_stress, ref error))
                {
                    MessageBox.Show(error);
                    return;
                }
                if (!double.TryParse(StressLimitBox.Text, out stress_limit) || stress_limit <= 0)
                {
                    MessageBox.Show("input for stress limit is not valid");
                    return;
                }
            }
            if (Def_checkbox.Checked)
            {
                foreach (var d in deflectionLimits)
                {
                    if (!ConvertString(d, ref error))
                    {
                        MessageBox.Show(error);
                        return;
                    }
                    if (d.Deflection <= 0)
                    {
                        MessageBox.Show("input for deflection limit is not valid");
                        return;
                    }
                }
            }
            if (Freq_checkbox.Checked)
            {
                //if (!int.TryParse(FreqCaseBox.Text, out freq_case) || freq_case <= 0)
                //{
                //    MessageBox.Show("input for frequency case is not valid");
                //    return;
                //}
                freq_case = 1;
                if (!double.TryParse(FreqLimitBox.Text, out freq_limit) || freq_limit <= 0)
                {
                    MessageBox.Show("input for frequency limit is not valid");
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

            List<object> args = new List<object>();

            args.Add(sFile);
            args.Add(sPropList);
            args.Add(ResList_stress);
            if (Button_LSA.Checked && !Button_NLA.Checked) { args.Add(Optimisation.Solver.linear); }
            else if (!Button_LSA.Checked && Button_NLA.Checked) { args.Add(Optimisation.Solver.nonlin); }
            args.Add(Def_checkbox.Checked);
            args.Add(ResList_def);
            args.Add(def_limit);
            args.Add(Stress_checkbox.Checked);
            args.Add(stress_limit);
            args.Add(Freq_checkbox.Checked);
            args.Add(freq_limit);
            args.Add(freq_case);
            args.Add(Combine_checkbox.Checked);
            args.Add(useExisting.Checked);
            args.Add(deflectionLimits.ToList());

            try { worker.RunWorkerAsync(args); }
            catch { }
            
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
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
        bool ConvertString(DeflectionLimit d, ref string error)
        {
            bool flag = true;
            string error1 = "";
            string error2 = "";
            
            // Check Load Cases input
            List<int> casesList = new List<int>();
            if (d.LoadCasesInput != null && ConvertString(d.LoadCasesInput, ref casesList, ref error1))
            {
                if (d.LoadCasesOutput == null) d.LoadCasesOutput = new List<int>();
                d.LoadCasesOutput = casesList;
            }
            else
            { error = error1; return false; }

            // Check Nodes input
            List<int> nodesList = new List<int>();
            if (d.LoadCasesInput != null && ConvertString(d.DeflectionNodesInput, ref nodesList, ref error1))
            {
                if (d.DeflectionNodesOutput == null) d.DeflectionNodesOutput = new List<int>();
                d.DeflectionNodesOutput = nodesList;
            }
            else
            { error = error2; return false; }

            return flag;
        }
        bool ConvertStringArray(string s_in, ref List<List<int>> iList, ref string error)
        {
            List<List<int>> sList = new List<List<int>>();
            char[] splitter = { ';' };
            s_in = string.Join("", s_in.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); //removing whitespace
            string[] str = s_in.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in str)
            {
                string err = "";
                List<int> iList_temp = new List<int>();
                if (!ConvertString(s, ref iList_temp, ref err))
                {
                    error = err;
                    return false;
                }
                else
                { sList.Add(iList_temp); }
            }
            iList = sList;

            error = "";
            return true;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            worker.Dispose();
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.stress_cases = this.StressCaseBox.Text;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.opt_stress = this.Stress_checkbox.Checked;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.opt_def = this.Def_checkbox.Checked;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.stress_lim = this.StressLimitBox.Text;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.opt_freq = this.Freq_checkbox.Checked;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.freq_lim = this.FreqLimitBox.Text;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.freq_case = this.FreqCaseBox.Text;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.combine = this.Combine_checkbox.Checked;
            Strand7_Steel_Section_Sizing.Properties.Settings.Default.deflection_limits = JsonConvert.SerializeObject(this.deflectionLimits);

            Strand7_Steel_Section_Sizing.Properties.Settings.Default.Save();

            int iErr;
            iErr = St7.St7Release();
            if (Optimisation.CheckiErr(iErr)) { return; }
        }
        private void ExplodeButton_Click(object sender, EventArgs e)
        {

            string sFile = fileBox.Text;

            if (fileBox.Text == "")
            {
                MessageBox.Show(@"Please provide Strand7 file to operate on using the ""Browse"" button.");
                return;
            }

            //Strand7 model properties
            int iErr;
            //iErr = St7.St7Init();
            //if (Optimisation.CheckiErr(iErr)) { return; }
            iErr = St7.St7OpenFile(1, sFile, System.IO.Path.GetTempPath());
            if (Optimisation.CheckiErr(iErr)) { return; }
            int nBeams = new int();
            iErr = St7.St7GetTotal(1, St7.tyBEAM, ref nBeams);
            if (Optimisation.CheckiErr(iErr)) { return; }
            int[] NumProperties = new int[St7.kMaxEntityTotals];
            int[] LastProperty = new int[St7.kMaxEntityTotals];
            iErr = St7.St7GetTotalProperties(1, NumProperties, LastProperty);
            if (Optimisation.CheckiErr(iErr)) { return; }
            int nProps = NumProperties[St7.ipBeamPropTotal];
            int nProps2 = LastProperty[St7.ipBeamPropTotal];
            for (int i = 0; i < nBeams; i++)
            {
                int groupNum = 0;
                iErr = St7.St7GetElementGroup(1, St7.tyBEAM, i + 1, ref groupNum);
                if (Optimisation.CheckiErr(iErr)) { return; }

                int propNum = 0;
                iErr = St7.St7GetElementProperty(1, St7.tyBEAM, i + 1, ref propNum);
                if (Optimisation.CheckiErr(iErr)) { return; }

                if (propNum > 0 && groupNum > 1)
                {
                    int[] Integers = new int[4];
                    double[] SectionData = new double[St7.kNumBeamSectionData];
                    double[] BeamMaterial = new double[St7.kNumMaterialData];
                    iErr = St7.St7GetBeamPropertyData(1, propNum, Integers, SectionData, BeamMaterial);
                    if (Optimisation.CheckiErr(iErr)) { return; }

                    double[] Doubles = new double[9];
                    iErr = St7.St7GetBeamMaterialData(1, propNum, Doubles);

                    iErr = St7.St7NewBeamProperty(1, nProps2 + i + 1, St7.kBeamTypeBeam, "Beam " + (i + 1).ToString());
                    if (Optimisation.CheckiErr(iErr)) { return; }
                    iErr = St7.St7SetBeamMaterialData(1, nProps2 + i + 1, Doubles);
                    if (Optimisation.CheckiErr(iErr)) { return; }
                    iErr = St7.St7SetElementProperty(1, St7.tyBEAM, (i + 1), nProps2 + i + 1);
                    if (Optimisation.CheckiErr(iErr)) { return; }
                }
            }
            string sBaseFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(sFile), System.IO.Path.GetFileNameWithoutExtension(sFile));
            string sExplodedFile = sBaseFile + " - exploded.st7";

            status = "";
            status2 = "";
            status3 = "Beam properties 'exploded' and saved to: " + Environment.NewLine + sExplodedFile + Environment.NewLine;
            updatetext();

            iErr = St7.St7SaveFileTo(1, sExplodedFile);
            if (Optimisation.CheckiErr(iErr)) { return; }
            iErr = St7.St7CloseFile(1);
            if (Optimisation.CheckiErr(iErr)) { return; }
            //iErr = St7.St7Release();
            //if (Optimisation.CheckiErr(iErr)) { return; }
        }
        private void ClusterButton_Click(object sender, EventArgs e)
        {
            string sFile = fileBox.Text;

            if (fileBox.Text == "")
            {
                MessageBox.Show(@"Please provide Strand7 file to operate on using the ""Browse"" button.");
                return;
            }

            //Strand7 model properties
            int iErr;
            //iErr = St7.St7Init();
            //if (Optimisation.CheckiErr(iErr)) { return; }
            iErr = St7.St7OpenFile(1, sFile, System.IO.Path.GetTempPath());
            if (Optimisation.CheckiErr(iErr)) { return; }

            int[] units = new int[] { St7.luMETRE, St7.fuNEWTON, St7.suMEGAPASCAL, St7.muKILOGRAM, St7.tuCELSIUS, St7.euJOULE };
            iErr = St7.St7ConvertUnits(1, units);
            if (Optimisation.CheckiErr(iErr)) { return; }

            int[] NumProperties = new int[St7.kMaxEntityTotals];
            int[] LastProperty = new int[St7.kMaxEntityTotals];
            iErr = St7.St7GetTotalProperties(1, NumProperties, LastProperty);
            if (Optimisation.CheckiErr(iErr)) { return; }
            int nProps = NumProperties[St7.ipBeamPropTotal]; //EDIT
            int nProps2 = LastProperty[St7.ipBeamPropTotal]; //EDIT
            
            int nBeams = new int();
            iErr = St7.St7GetTotal(1, St7.tyBEAM, ref nBeams);
            if (Optimisation.CheckiErr(iErr)) { return; }

            List<int> idList = new List<int>();
            int numIds = 0;
            for (int i = 0; i < nBeams; i++)
            {
                int beamId = 0;
                iErr = St7.St7GetBeamID(1, iErr, ref beamId);
                if (!idList.Contains(beamId)) idList.Add(beamId);
            }
            //int numGroups = 0;
            //iErr = St7.St7GetNumGroups(1, ref numGroups);
            //Optimisation.CollectCSVSections(System.IO.Path.GetDirectoryName(sFile), numGroups);
            Optimisation.CollectCSVSections(System.IO.Path.GetDirectoryName(sFile), idList);

            BindingSource bs = new BindingSource();
            List<Section> sections = new List<Section>();
            for (int i=0;i<Optimisation.SecLib.nGroups;i++)
            {
                sections.AddRange(Optimisation.SecLib.GetGroup(i));
            }
            bs.DataSource = sections;
            sectionDataGrid.DataSource = bs;

            Beam[] beams = new Beam[nBeams];
            Optimisation.beamProperties = new BeamProperty[nProps2];
            Optimisation.SetupBeamsAndProperties(false, nBeams, beams);

            /// ######################
            /// ##### Clustering #####
            /// ######################
            string s_cluster="";
            string sBaseFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(sFile), System.IO.Path.GetFileNameWithoutExtension(sFile));
            Optimisation.ClusterProperties(true, true, ref s_cluster, sBaseFile);
            status = "";
            status2 = "";
            status3 = s_cluster;
            updatetext();

            iErr = St7.St7CloseFile(1);
            if (Optimisation.CheckiErr(iErr)) { return; }
            //iErr = St7.St7Release();
            //if (Optimisation.CheckiErr(iErr)) { return; }
            
        }
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Strand7 file for beam section sizing";
            fdlg.Filter = "Strand7 files (*.st7)|*.st7";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                List<object> args = new List<object>();

                string sFile = fdlg.FileName;
                fileBox.Text = sFile;
            }
        }
    }
}
