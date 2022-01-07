namespace Hoi4_Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.list_dlc = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.list_mods = new System.Windows.Forms.CheckedListBox();
            this.list_mods2 = new System.Windows.Forms.CheckedListBox();
            this.label_category = new System.Windows.Forms.Label();
            this.label_mods = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.debugsaves = new System.Windows.Forms.NumericUpDown();
            this.enable_random_log = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.enable_debug = new System.Windows.Forms.CheckBox();
            this.enable_crashdatalog = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label_version = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugsaves)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(434, 40);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 421);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.listBG;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(533, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "News";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.list_dlc);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(533, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DLC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // list_dlc
            // 
            this.list_dlc.CheckOnClick = true;
            this.list_dlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_dlc.FormattingEnabled = true;
            this.list_dlc.Location = new System.Drawing.Point(3, 3);
            this.list_dlc.Name = "list_dlc";
            this.list_dlc.Size = new System.Drawing.Size(527, 389);
            this.list_dlc.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.list_mods);
            this.tabPage3.Controls.Add(this.list_mods2);
            this.tabPage3.Controls.Add(this.label_category);
            this.tabPage3.Controls.Add(this.label_mods);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(533, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mods";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(365, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Refresh Mods";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(53, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(309, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(455, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Unselect All";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.unselect_mods);
            // 
            // list_mods
            // 
            this.list_mods.CheckOnClick = true;
            this.list_mods.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_mods.FormattingEnabled = true;
            this.list_mods.Location = new System.Drawing.Point(0, -303);
            this.list_mods.Name = "list_mods";
            this.list_mods.Size = new System.Drawing.Size(533, 349);
            this.list_mods.Sorted = true;
            this.list_mods.TabIndex = 4;
            this.list_mods.SelectedIndexChanged += new System.EventHandler(this.list_mods_SelectedIndexChanged);
            // 
            // list_mods2
            // 
            this.list_mods2.CheckOnClick = true;
            this.list_mods2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_mods2.FormattingEnabled = true;
            this.list_mods2.Location = new System.Drawing.Point(0, 46);
            this.list_mods2.Name = "list_mods2";
            this.list_mods2.Size = new System.Drawing.Size(533, 349);
            this.list_mods2.Sorted = true;
            this.list_mods2.TabIndex = 4;
            this.list_mods2.Visible = false;
            this.list_mods2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.list_mods2_ItemCheck_1);
            this.list_mods2.SelectedIndexChanged += new System.EventHandler(this.list_mods2_SelectedIndexChanged);
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Location = new System.Drawing.Point(3, 15);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(44, 13);
            this.label_category.TabIndex = 2;
            this.label_category.Text = "Search:";
            // 
            // label_mods
            // 
            this.label_mods.AutoSize = true;
            this.label_mods.Location = new System.Drawing.Point(420, 6);
            this.label_mods.Name = "label_mods";
            this.label_mods.Size = new System.Drawing.Size(36, 13);
            this.label_mods.TabIndex = 1;
            this.label_mods.Text = "Mods:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.debugsaves);
            this.tabPage4.Controls.Add(this.enable_random_log);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.enable_debug);
            this.tabPage4.Controls.Add(this.enable_crashdatalog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(533, 395);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Amount of Autosaves";
            // 
            // debugsaves
            // 
            this.debugsaves.Location = new System.Drawing.Point(118, 79);
            this.debugsaves.Name = "debugsaves";
            this.debugsaves.Size = new System.Drawing.Size(39, 20);
            this.debugsaves.TabIndex = 10;
            this.debugsaves.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // enable_random_log
            // 
            this.enable_random_log.AutoSize = true;
            this.enable_random_log.Location = new System.Drawing.Point(7, 53);
            this.enable_random_log.Name = "enable_random_log";
            this.enable_random_log.Size = new System.Drawing.Size(123, 17);
            this.enable_random_log.TabIndex = 9;
            this.enable_random_log.Text = "Enable Random Log";
            this.enable_random_log.UseVisualStyleBackColor = true;
            this.enable_random_log.CheckedChanged += new System.EventHandler(this.enable_random_log_CheckedChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(3, 132);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Delete missing Mods";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.vanilla);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(3, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Open Save Folder";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.open_save);
            // 
            // enable_debug
            // 
            this.enable_debug.AutoSize = true;
            this.enable_debug.Location = new System.Drawing.Point(7, 7);
            this.enable_debug.Name = "enable_debug";
            this.enable_debug.Size = new System.Drawing.Size(94, 17);
            this.enable_debug.TabIndex = 0;
            this.enable_debug.Text = "Enable Debug";
            this.enable_debug.UseVisualStyleBackColor = true;
            this.enable_debug.CheckedChanged += new System.EventHandler(this.enable_debug_CheckedChanged);
            // 
            // enable_crashdatalog
            // 
            this.enable_crashdatalog.AutoSize = true;
            this.enable_crashdatalog.Location = new System.Drawing.Point(7, 30);
            this.enable_crashdatalog.Name = "enable_crashdatalog";
            this.enable_crashdatalog.Size = new System.Drawing.Size(124, 17);
            this.enable_crashdatalog.TabIndex = 0;
            this.enable_crashdatalog.Text = "Enable Crashdatalog";
            this.enable_crashdatalog.UseVisualStyleBackColor = true;
            this.enable_crashdatalog.CheckedChanged += new System.EventHandler(this.enable_crashdatalog_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(533, 395);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Log";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(527, 389);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(997, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label_version
            // 
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(60, 17);
            this.label_version.Text = "Version:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.play;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(12, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(411, 79);
            this.button1.TabIndex = 6;
            this.button1.Text = "Update all enabled Mods";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.play;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(560, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(411, 79);
            this.button2.TabIndex = 7;
            this.button2.Text = "Play";
            this.button2.UseMnemonic = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(3, 161);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "Launch Vanilla";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.launch_vanilla);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(997, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hearts of Iron IV Launcher";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugsaves)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label_mods;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.CheckedListBox list_mods;
        private System.Windows.Forms.CheckedListBox list_mods2;
        private System.Windows.Forms.CheckedListBox list_dlc;
        private System.Windows.Forms.ToolStripStatusLabel label_version;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox enable_debug;
        private System.Windows.Forms.CheckBox enable_crashdatalog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox enable_random_log;
        private System.Windows.Forms.NumericUpDown debugsaves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

