namespace Strand7_Steel_Section_Sizing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Button_LSA = new System.Windows.Forms.RadioButton();
            this.Button_NLA = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StressQM = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StressLimitBox = new System.Windows.Forms.TextBox();
            this.Stress_checkbox = new System.Windows.Forms.CheckBox();
            this.StressCaseBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeflectionQM = new System.Windows.Forms.PictureBox();
            this.Def_checkbox = new System.Windows.Forms.CheckBox();
            this.DefCaseBox = new System.Windows.Forms.TextBox();
            this.DefLimitBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PropertiesQM = new System.Windows.Forms.PictureBox();
            this.SecListBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StressQM)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeflectionQM)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesQM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 280);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "       ";
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.Location = new System.Drawing.Point(226, 329);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(61, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.AutoSize = true;
            this.BrowseButton.Location = new System.Drawing.Point(95, 329);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(127, 23);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Select file and optimise";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.Browse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Properties to optimise:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Result cases to include:";
            // 
            // Button_LSA
            // 
            this.Button_LSA.AutoSize = true;
            this.Button_LSA.Checked = true;
            this.Button_LSA.Location = new System.Drawing.Point(6, 18);
            this.Button_LSA.Margin = new System.Windows.Forms.Padding(2);
            this.Button_LSA.Name = "Button_LSA";
            this.Button_LSA.Size = new System.Drawing.Size(82, 17);
            this.Button_LSA.TabIndex = 1;
            this.Button_LSA.TabStop = true;
            this.Button_LSA.Text = "Linear static";
            this.Button_LSA.UseVisualStyleBackColor = true;
            // 
            // Button_NLA
            // 
            this.Button_NLA.AutoSize = true;
            this.Button_NLA.Location = new System.Drawing.Point(92, 18);
            this.Button_NLA.Margin = new System.Windows.Forms.Padding(2);
            this.Button_NLA.Name = "Button_NLA";
            this.Button_NLA.Size = new System.Drawing.Size(101, 17);
            this.Button_NLA.TabIndex = 1;
            this.Button_NLA.TabStop = true;
            this.Button_NLA.Text = "Non-linear static";
            this.Button_NLA.UseVisualStyleBackColor = true;
            this.Button_NLA.CheckedChanged += new System.EventHandler(this.Button_NLA_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Deflection cases to include:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "mm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StressQM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.StressLimitBox);
            this.groupBox1.Controls.Add(this.Stress_checkbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StressCaseBox);
            this.groupBox1.Location = new System.Drawing.Point(11, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 76);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // StressQM
            // 
            this.StressQM.Image = ((System.Drawing.Image)(resources.GetObject("StressQM.Image")));
            this.StressQM.Location = new System.Drawing.Point(255, 14);
            this.StressQM.Name = "StressQM";
            this.StressQM.Size = new System.Drawing.Size(12, 12);
            this.StressQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StressQM.TabIndex = 21;
            this.StressQM.TabStop = false;
            this.toolTip1.SetToolTip(this.StressQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.stress_Tooltip);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "MPa";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // StressLimitBox
            // 
            this.StressLimitBox.Location = new System.Drawing.Point(128, 10);
            this.StressLimitBox.Name = "StressLimitBox";
            this.StressLimitBox.Size = new System.Drawing.Size(59, 20);
            this.StressLimitBox.TabIndex = 5;
            this.StressLimitBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.stress_lim;
            this.StressLimitBox.TextChanged += new System.EventHandler(this.StressLimitBox_TextChanged);
            // 
            // Stress_checkbox
            // 
            this.Stress_checkbox.AutoSize = true;
            this.Stress_checkbox.Checked = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.opt_stress;
            this.Stress_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Stress_checkbox.Location = new System.Drawing.Point(6, 12);
            this.Stress_checkbox.Name = "Stress_checkbox";
            this.Stress_checkbox.Size = new System.Drawing.Size(96, 17);
            this.Stress_checkbox.TabIndex = 4;
            this.Stress_checkbox.Text = "Optimise stress";
            this.Stress_checkbox.UseVisualStyleBackColor = true;
            // 
            // StressCaseBox
            // 
            this.StressCaseBox.Location = new System.Drawing.Point(6, 48);
            this.StressCaseBox.Margin = new System.Windows.Forms.Padding(2);
            this.StressCaseBox.Name = "StressCaseBox";
            this.StressCaseBox.Size = new System.Drawing.Size(264, 20);
            this.StressCaseBox.TabIndex = 6;
            this.StressCaseBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.stress_cases;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeflectionQM);
            this.groupBox2.Controls.Add(this.Def_checkbox);
            this.groupBox2.Controls.Add(this.DefCaseBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.DefLimitBox);
            this.groupBox2.Location = new System.Drawing.Point(11, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 86);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // DeflectionQM
            // 
            this.DeflectionQM.Image = ((System.Drawing.Image)(resources.GetObject("DeflectionQM.Image")));
            this.DeflectionQM.Location = new System.Drawing.Point(255, 19);
            this.DeflectionQM.Name = "DeflectionQM";
            this.DeflectionQM.Size = new System.Drawing.Size(12, 12);
            this.DeflectionQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeflectionQM.TabIndex = 22;
            this.DeflectionQM.TabStop = false;
            this.toolTip1.SetToolTip(this.DeflectionQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.def_Tooltip);
            // 
            // Def_checkbox
            // 
            this.Def_checkbox.AutoSize = true;
            this.Def_checkbox.Checked = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.opt_def;
            this.Def_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Def_checkbox.Location = new System.Drawing.Point(6, 17);
            this.Def_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Def_checkbox.Name = "Def_checkbox";
            this.Def_checkbox.Size = new System.Drawing.Size(120, 17);
            this.Def_checkbox.TabIndex = 7;
            this.Def_checkbox.Text = "Optimise deflections";
            this.Def_checkbox.UseVisualStyleBackColor = true;
            // 
            // DefCaseBox
            // 
            this.DefCaseBox.Location = new System.Drawing.Point(6, 57);
            this.DefCaseBox.Margin = new System.Windows.Forms.Padding(2);
            this.DefCaseBox.Name = "DefCaseBox";
            this.DefCaseBox.Size = new System.Drawing.Size(264, 20);
            this.DefCaseBox.TabIndex = 9;
            this.DefCaseBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.def_cases;
            // 
            // DefLimitBox
            // 
            this.DefLimitBox.Location = new System.Drawing.Point(130, 15);
            this.DefLimitBox.Margin = new System.Windows.Forms.Padding(2);
            this.DefLimitBox.Name = "DefLimitBox";
            this.DefLimitBox.Size = new System.Drawing.Size(59, 20);
            this.DefLimitBox.TabIndex = 8;
            this.DefLimitBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.def_lim;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PropertiesQM);
            this.groupBox3.Controls.Add(this.Button_LSA);
            this.groupBox3.Controls.Add(this.SecListBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Button_NLA);
            this.groupBox3.Location = new System.Drawing.Point(11, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 98);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // PropertiesQM
            // 
            this.PropertiesQM.Image = ((System.Drawing.Image)(resources.GetObject("PropertiesQM.Image")));
            this.PropertiesQM.Location = new System.Drawing.Point(255, 21);
            this.PropertiesQM.Name = "PropertiesQM";
            this.PropertiesQM.Size = new System.Drawing.Size(12, 12);
            this.PropertiesQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PropertiesQM.TabIndex = 20;
            this.PropertiesQM.TabStop = false;
            this.toolTip1.SetToolTip(this.PropertiesQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.prop_Tooltip);
            // 
            // SecListBox
            // 
            this.SecListBox.Location = new System.Drawing.Point(6, 62);
            this.SecListBox.Margin = new System.Windows.Forms.Padding(2);
            this.SecListBox.Name = "SecListBox";
            this.SecListBox.Size = new System.Drawing.Size(264, 20);
            this.SecListBox.TabIndex = 3;
            this.SecListBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.sections_list;
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputBox.Location = new System.Drawing.Point(300, 13);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(473, 339);
            this.outputBox.TabIndex = 12;
            this.outputBox.TabStop = false;
            this.outputBox.WordWrap = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form1
            // 
            this.AcceptButton = this.BrowseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 358);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Strand7 Section Sizing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StressQM)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeflectionQM)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesQM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox SecListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StressCaseBox;
        private System.Windows.Forms.RadioButton Button_LSA;
        private System.Windows.Forms.RadioButton Button_NLA;
        private System.Windows.Forms.CheckBox Def_checkbox;
        private System.Windows.Forms.TextBox DefCaseBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DefLimitBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Stress_checkbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox StressLimitBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox StressQM;
        private System.Windows.Forms.PictureBox DeflectionQM;
        private System.Windows.Forms.PictureBox PropertiesQM;
    }
}

