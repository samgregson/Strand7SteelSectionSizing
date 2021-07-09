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
            this.label4 = new System.Windows.Forms.Label();
            this.Button_LSA = new System.Windows.Forms.RadioButton();
            this.Button_NLA = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StressQM = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StressLimitBox = new System.Windows.Forms.TextBox();
            this.Stress_checkbox = new System.Windows.Forms.CheckBox();
            this.StressCaseBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deflectionGrid = new System.Windows.Forms.DataGridView();
            this.deflectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeflectionNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadCases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceNodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.deflectionLimitBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DeflectionQM = new System.Windows.Forms.PictureBox();
            this.Def_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PropertiesQM = new System.Windows.Forms.PictureBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FrequencyQM = new System.Windows.Forms.PictureBox();
            this.ExplodeQM = new System.Windows.Forms.PictureBox();
            this.CombineQM = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.FreqCaseBox = new System.Windows.Forms.TextBox();
            this.Freq_checkbox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.FreqLimitBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Combine_checkbox = new System.Windows.Forms.CheckBox();
            this.ExplodeButton = new System.Windows.Forms.Button();
            this.ClusterButton = new System.Windows.Forms.Button();
            this.deflectionLimitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.useExisting = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StressQM)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deflectionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deflectionLimitBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeflectionQM)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesQM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyQM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodeQM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CombineQM)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deflectionLimitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 502);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "L1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 523);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "L2";
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.Location = new System.Drawing.Point(758, 523);
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
            this.BrowseButton.Location = new System.Drawing.Point(627, 523);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(127, 23);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Select file and optimise";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.Browse_Click);
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StressQM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.StressLimitBox);
            this.groupBox1.Controls.Add(this.Stress_checkbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StressCaseBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 76);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // StressQM
            // 
            this.StressQM.Image = ((System.Drawing.Image)(resources.GetObject("StressQM.Image")));
            this.StressQM.Location = new System.Drawing.Point(327, 14);
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
            // 
            // StressLimitBox
            // 
            this.StressLimitBox.Location = new System.Drawing.Point(128, 10);
            this.StressLimitBox.Name = "StressLimitBox";
            this.StressLimitBox.Size = new System.Drawing.Size(59, 20);
            this.StressLimitBox.TabIndex = 5;
            this.StressLimitBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.stress_lim;
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
            this.groupBox2.Controls.Add(this.deflectionGrid);
            this.groupBox2.Controls.Add(this.DeflectionQM);
            this.groupBox2.Controls.Add(this.Def_checkbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 226);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // deflectionGrid
            // 
            this.deflectionGrid.AllowUserToResizeColumns = false;
            this.deflectionGrid.AutoGenerateColumns = false;
            this.deflectionGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.deflectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deflectionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deflectionDataGridViewTextBoxColumn,
            this.DeflectionNode,
            this.LoadCases,
            this.referenceNodeDataGridViewTextBoxColumn,
            this.xDataGridViewCheckBoxColumn,
            this.yDataGridViewCheckBoxColumn,
            this.zDataGridViewCheckBoxColumn});
            this.deflectionGrid.DataSource = this.deflectionLimitBindingSource1;
            this.deflectionGrid.Location = new System.Drawing.Point(6, 39);
            this.deflectionGrid.Name = "deflectionGrid";
            this.deflectionGrid.RowHeadersVisible = false;
            this.deflectionGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.deflectionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deflectionGrid.Size = new System.Drawing.Size(333, 181);
            this.deflectionGrid.TabIndex = 29;
            // 
            // deflectionDataGridViewTextBoxColumn
            // 
            this.deflectionDataGridViewTextBoxColumn.DataPropertyName = "Deflection";
            this.deflectionDataGridViewTextBoxColumn.FillWeight = 144.9814F;
            this.deflectionDataGridViewTextBoxColumn.HeaderText = "Deflection [mm]";
            this.deflectionDataGridViewTextBoxColumn.Name = "deflectionDataGridViewTextBoxColumn";
            this.deflectionDataGridViewTextBoxColumn.Width = 60;
            // 
            // DeflectionNode
            // 
            this.DeflectionNode.DataPropertyName = "DeflectionNodesInput";
            this.DeflectionNode.HeaderText = "Deflection Node";
            this.DeflectionNode.Name = "DeflectionNode";
            this.DeflectionNode.Width = 60;
            // 
            // LoadCases
            // 
            this.LoadCases.DataPropertyName = "LoadCasesInput";
            this.LoadCases.HeaderText = "Load Case(s)";
            this.LoadCases.Name = "LoadCases";
            this.LoadCases.Width = 60;
            // 
            // referenceNodeDataGridViewTextBoxColumn
            // 
            this.referenceNodeDataGridViewTextBoxColumn.DataPropertyName = "ReferenceNode";
            this.referenceNodeDataGridViewTextBoxColumn.FillWeight = 138.5273F;
            this.referenceNodeDataGridViewTextBoxColumn.HeaderText = "Reference Node";
            this.referenceNodeDataGridViewTextBoxColumn.Name = "referenceNodeDataGridViewTextBoxColumn";
            this.referenceNodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // xDataGridViewCheckBoxColumn
            // 
            this.xDataGridViewCheckBoxColumn.DataPropertyName = "X";
            this.xDataGridViewCheckBoxColumn.FillWeight = 52.35317F;
            this.xDataGridViewCheckBoxColumn.HeaderText = "X";
            this.xDataGridViewCheckBoxColumn.Name = "xDataGridViewCheckBoxColumn";
            this.xDataGridViewCheckBoxColumn.Width = 23;
            // 
            // yDataGridViewCheckBoxColumn
            // 
            this.yDataGridViewCheckBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewCheckBoxColumn.FillWeight = 59.43535F;
            this.yDataGridViewCheckBoxColumn.HeaderText = "Y";
            this.yDataGridViewCheckBoxColumn.Name = "yDataGridViewCheckBoxColumn";
            this.yDataGridViewCheckBoxColumn.Width = 23;
            // 
            // zDataGridViewCheckBoxColumn
            // 
            this.zDataGridViewCheckBoxColumn.DataPropertyName = "Z";
            this.zDataGridViewCheckBoxColumn.FillWeight = 65.85933F;
            this.zDataGridViewCheckBoxColumn.HeaderText = "Z";
            this.zDataGridViewCheckBoxColumn.Name = "zDataGridViewCheckBoxColumn";
            this.zDataGridViewCheckBoxColumn.Width = 23;
            // 
            // deflectionLimitBindingSource1
            // 
            this.deflectionLimitBindingSource1.DataSource = typeof(Strand7_Steel_Section_Sizing.DeflectionLimit);
            // 
            // DeflectionQM
            // 
            this.DeflectionQM.Image = ((System.Drawing.Image)(resources.GetObject("DeflectionQM.Image")));
            this.DeflectionQM.Location = new System.Drawing.Point(327, 19);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PropertiesQM);
            this.groupBox3.Controls.Add(this.Button_LSA);
            this.groupBox3.Controls.Add(this.Button_NLA);
            this.groupBox3.Location = new System.Drawing.Point(11, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 51);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // PropertiesQM
            // 
            this.PropertiesQM.Image = ((System.Drawing.Image)(resources.GetObject("PropertiesQM.Image")));
            this.PropertiesQM.Location = new System.Drawing.Point(328, 18);
            this.PropertiesQM.Name = "PropertiesQM";
            this.PropertiesQM.Size = new System.Drawing.Size(12, 12);
            this.PropertiesQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PropertiesQM.TabIndex = 20;
            this.PropertiesQM.TabStop = false;
            this.toolTip1.SetToolTip(this.PropertiesQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.prop_Tooltip);
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputBox.Location = new System.Drawing.Point(363, 12);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(456, 483);
            this.outputBox.TabIndex = 12;
            this.outputBox.TabStop = false;
            this.outputBox.WordWrap = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // FrequencyQM
            // 
            this.FrequencyQM.Image = ((System.Drawing.Image)(resources.GetObject("FrequencyQM.Image")));
            this.FrequencyQM.Location = new System.Drawing.Point(328, 15);
            this.FrequencyQM.Name = "FrequencyQM";
            this.FrequencyQM.Size = new System.Drawing.Size(12, 12);
            this.FrequencyQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FrequencyQM.TabIndex = 22;
            this.FrequencyQM.TabStop = false;
            this.toolTip1.SetToolTip(this.FrequencyQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.freq_Tooltip);
            // 
            // ExplodeQM
            // 
            this.ExplodeQM.Image = ((System.Drawing.Image)(resources.GetObject("ExplodeQM.Image")));
            this.ExplodeQM.Location = new System.Drawing.Point(134, 16);
            this.ExplodeQM.Name = "ExplodeQM";
            this.ExplodeQM.Size = new System.Drawing.Size(12, 12);
            this.ExplodeQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExplodeQM.TabIndex = 21;
            this.ExplodeQM.TabStop = false;
            this.toolTip1.SetToolTip(this.ExplodeQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.explode_Tooltip);
            // 
            // CombineQM
            // 
            this.CombineQM.Image = ((System.Drawing.Image)(resources.GetObject("CombineQM.Image")));
            this.CombineQM.Location = new System.Drawing.Point(782, 503);
            this.CombineQM.Name = "CombineQM";
            this.CombineQM.Size = new System.Drawing.Size(12, 12);
            this.CombineQM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CombineQM.TabIndex = 27;
            this.CombineQM.TabStop = false;
            this.toolTip1.SetToolTip(this.CombineQM, global::Strand7_Steel_Section_Sizing.Properties.Resources.combine_Tooltip);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.FreqCaseBox);
            this.groupBox4.Controls.Add(this.FrequencyQM);
            this.groupBox4.Controls.Add(this.Freq_checkbox);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.FreqLimitBox);
            this.groupBox4.Location = new System.Drawing.Point(11, 416);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(346, 79);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Load case containing masses:";
            this.label8.Visible = false;
            // 
            // FreqCaseBox
            // 
            this.FreqCaseBox.Enabled = false;
            this.FreqCaseBox.Location = new System.Drawing.Point(5, 54);
            this.FreqCaseBox.Margin = new System.Windows.Forms.Padding(2);
            this.FreqCaseBox.Name = "FreqCaseBox";
            this.FreqCaseBox.Size = new System.Drawing.Size(264, 20);
            this.FreqCaseBox.TabIndex = 23;
            this.FreqCaseBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.freq_case;
            this.FreqCaseBox.Visible = false;
            // 
            // Freq_checkbox
            // 
            this.Freq_checkbox.AutoSize = true;
            this.Freq_checkbox.Checked = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.opt_freq;
            this.Freq_checkbox.Location = new System.Drawing.Point(6, 17);
            this.Freq_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Freq_checkbox.Name = "Freq_checkbox";
            this.Freq_checkbox.Size = new System.Drawing.Size(116, 17);
            this.Freq_checkbox.TabIndex = 7;
            this.Freq_checkbox.Text = "Optimise frequency";
            this.Freq_checkbox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Hz";
            // 
            // FreqLimitBox
            // 
            this.FreqLimitBox.Location = new System.Drawing.Point(130, 15);
            this.FreqLimitBox.Margin = new System.Windows.Forms.Padding(2);
            this.FreqLimitBox.Name = "FreqLimitBox";
            this.FreqLimitBox.Size = new System.Drawing.Size(59, 20);
            this.FreqLimitBox.TabIndex = 8;
            this.FreqLimitBox.Text = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.freq_lim;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 372);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 23;
            // 
            // Combine_checkbox
            // 
            this.Combine_checkbox.AutoSize = true;
            this.Combine_checkbox.Checked = global::Strand7_Steel_Section_Sizing.Properties.Settings.Default.combine;
            this.Combine_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Combine_checkbox.Location = new System.Drawing.Point(627, 501);
            this.Combine_checkbox.Name = "Combine_checkbox";
            this.Combine_checkbox.Size = new System.Drawing.Size(149, 17);
            this.Combine_checkbox.TabIndex = 25;
            this.Combine_checkbox.Text = "Combine properties at end";
            this.Combine_checkbox.UseVisualStyleBackColor = true;
            // 
            // ExplodeButton
            // 
            this.ExplodeButton.Location = new System.Drawing.Point(12, 16);
            this.ExplodeButton.Name = "ExplodeButton";
            this.ExplodeButton.Size = new System.Drawing.Size(116, 23);
            this.ExplodeButton.TabIndex = 26;
            this.ExplodeButton.Text = "Explode Properties";
            this.ExplodeButton.UseVisualStyleBackColor = true;
            this.ExplodeButton.Click += new System.EventHandler(this.ExplodeButton_Click);
            // 
            // ClusterButton
            // 
            this.ClusterButton.Location = new System.Drawing.Point(282, 16);
            this.ClusterButton.Name = "ClusterButton";
            this.ClusterButton.Size = new System.Drawing.Size(75, 23);
            this.ClusterButton.TabIndex = 28;
            this.ClusterButton.Text = "Cluster";
            this.ClusterButton.UseVisualStyleBackColor = true;
            this.ClusterButton.Click += new System.EventHandler(this.ClusterButton_Click);
            // 
            // deflectionLimitBindingSource
            // 
            this.deflectionLimitBindingSource.DataSource = typeof(Strand7_Steel_Section_Sizing.DeflectionLimit);
            // 
            // useExisting
            // 
            this.useExisting.AutoSize = true;
            this.useExisting.Location = new System.Drawing.Point(363, 502);
            this.useExisting.Name = "useExisting";
            this.useExisting.Size = new System.Drawing.Size(160, 17);
            this.useExisting.TabIndex = 29;
            this.useExisting.Text = "Use existing sections at start";
            this.useExisting.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.BrowseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 556);
            this.Controls.Add(this.useExisting);
            this.Controls.Add(this.ClusterButton);
            this.Controls.Add(this.CombineQM);
            this.Controls.Add(this.ExplodeQM);
            this.Controls.Add(this.ExplodeButton);
            this.Controls.Add(this.Combine_checkbox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label10);
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
            ((System.ComponentModel.ISupportInitialize)(this.deflectionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deflectionLimitBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeflectionQM)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesQM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyQM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodeQM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CombineQM)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deflectionLimitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StressCaseBox;
        private System.Windows.Forms.RadioButton Button_LSA;
        private System.Windows.Forms.RadioButton Button_NLA;
        private System.Windows.Forms.CheckBox Def_checkbox;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox FrequencyQM;
        private System.Windows.Forms.CheckBox Freq_checkbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FreqLimitBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox FreqCaseBox;
        private System.Windows.Forms.CheckBox Combine_checkbox;
        private System.Windows.Forms.Button ExplodeButton;
        private System.Windows.Forms.PictureBox ExplodeQM;
        private System.Windows.Forms.PictureBox CombineQM;
        private System.Windows.Forms.Button ClusterButton;
        private System.Windows.Forms.DataGridView deflectionGrid;
        private System.Windows.Forms.BindingSource deflectionLimitBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadCaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource deflectionLimitBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn deflectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeflectionNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadCases;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceNodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn xDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn zDataGridViewCheckBoxColumn;
        private System.Windows.Forms.CheckBox useExisting;
    }
}

