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
                outputBox.Text += status3 + Environment.NewLine;
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
        private void Browse_Click(object sender, EventArgs e)
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
                    if (!double.TryParse(DefLimitBox.Text, out def_limit) || def_limit <= 0)
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
                    if (Button_LSA.Checked && !Button_NLA.Checked) { args.Add(Optimisation.Solver.linear); }
                    else if (!Button_LSA.Checked && Button_NLA.Checked) { args.Add(Optimisation.Solver.nonlin); }
                    args.Add(Def_checkbox.Checked);
                    args.Add(ResList_def);
                    args.Add(def_limit);
                    args.Add(Stress_checkbox.Checked);
                    try { worker.RunWorkerAsync(args); }
                    catch { }
                }
                else
                {
                    //this.Close();
                }
            }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.sections_list = this.SecListBox.Text;
            Properties.Settings.Default.def_cases = this.DefCaseBox.Text;
            Properties.Settings.Default.stress_cases = this.StressCaseBox.Text;
            Properties.Settings.Default.opt_stress = this.Stress_checkbox.Checked;
            Properties.Settings.Default.opt_def = this.Def_checkbox.Checked;
            Properties.Settings.Default.def_lim = this.DefLimitBox.Text;

            Properties.Settings.Default.Save();
        }
    }
}
