namespace FPL2FMS
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_load = new System.Windows.Forms.Button();
            this.textBox_load = new System.Windows.Forms.TextBox();
            this.textBox_fpl = new System.Windows.Forms.TextBox();
            this.textBox_fms = new System.Windows.Forms.TextBox();
            this.textBox_save = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_fpl);
            this.groupBox1.Controls.Add(this.textBox_load);
            this.groupBox1.Controls.Add(this.button_load);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FPL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_fms);
            this.groupBox2.Controls.Add(this.textBox_save);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FMS";
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(12, 211);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox_load
            // 
            this.textBox_load.Location = new System.Drawing.Point(94, 213);
            this.textBox_load.Name = "textBox_load";
            this.textBox_load.Size = new System.Drawing.Size(519, 20);
            this.textBox_load.TabIndex = 1;
            // 
            // textBox_fpl
            // 
            this.textBox_fpl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_fpl.Location = new System.Drawing.Point(3, 16);
            this.textBox_fpl.Multiline = true;
            this.textBox_fpl.Name = "textBox_fpl";
            this.textBox_fpl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_fpl.Size = new System.Drawing.Size(639, 189);
            this.textBox_fpl.TabIndex = 2;
            this.textBox_fpl.Text = "FPL to FMS Converter\r\nJuly 3,2019\r\nGeorge Reimer\r\nPublic Release\r\n\r\nConvert SkyVe" +
    "ctor FPL files to XPlane 11 FMS files.";
            // 
            // textBox_fms
            // 
            this.textBox_fms.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_fms.Location = new System.Drawing.Point(3, 16);
            this.textBox_fms.Multiline = true;
            this.textBox_fms.Name = "textBox_fms";
            this.textBox_fms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_fms.Size = new System.Drawing.Size(639, 180);
            this.textBox_fms.TabIndex = 5;
            // 
            // textBox_save
            // 
            this.textBox_save.Location = new System.Drawing.Point(94, 204);
            this.textBox_save.Name = "textBox_save";
            this.textBox_save.Size = new System.Drawing.Size(519, 20);
            this.textBox_save.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.fpl";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.fpl)|*.fpl|All files (*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "H:\\SteamLibrary\\steamapps\\common\\X-Plane 11\\Output\\FMS plans";
            this.openFileDialog1.Title = "Load FPL File";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.fms";
            this.saveFileDialog1.Filter = "txt files (*.fms)|*.fms|All files (*.*)|*.*";
            this.saveFileDialog1.InitialDirectory = "H:\\SteamLibrary\\steamapps\\common\\X-Plane 11\\Output\\FMS plans";
            this.saveFileDialog1.Title = "Save FMS file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 487);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "FPL to FMS Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_fpl;
        private System.Windows.Forms.TextBox textBox_load;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_fms;
        private System.Windows.Forms.TextBox textBox_save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

