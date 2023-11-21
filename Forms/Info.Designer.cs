namespace ezclip {
    partial class Info {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            checkBox1 = new CheckBox();
            htkCombo = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            resCombo = new ComboBox();
            label4 = new Label();
            fpsCombo = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 64);
            label1.TabIndex = 2;
            label1.Text = "License: BSD 3\r\nCoded by: v1per_xd\r\nCurrent version: v?\r\nMade with <3";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(9, 88);
            checkBox1.Margin = new Padding(4, 4, 4, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(139, 20);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Hide Discord Activity";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // htkCombo
            // 
            htkCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            htkCombo.FormattingEnabled = true;
            htkCombo.Items.AddRange(new object[] { "CTRL SHIFT A", "CTRL SHIFT C", "CTRL SHIFT X", "CTRL ALT A", "CTRL ALT C", "CTRL ALT X" });
            htkCombo.Location = new Point(193, 17);
            htkCombo.Margin = new Padding(4, 4, 4, 4);
            htkCombo.Name = "htkCombo";
            htkCombo.Size = new Size(140, 24);
            htkCombo.TabIndex = 4;
            htkCombo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 20);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 16);
            label2.TabIndex = 5;
            label2.Text = "Htk:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(153, 54);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(29, 16);
            label3.TabIndex = 7;
            label3.Text = "Res:";
            // 
            // resCombo
            // 
            resCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            resCombo.FormattingEnabled = true;
            resCombo.Items.AddRange(new object[] { "480", "720", "1080" });
            resCombo.Location = new Point(193, 50);
            resCombo.Margin = new Padding(4, 4, 4, 4);
            resCombo.Name = "resCombo";
            resCombo.Size = new Size(140, 24);
            resCombo.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(153, 87);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(28, 16);
            label4.TabIndex = 9;
            label4.Text = "Fps:";
            // 
            // fpsCombo
            // 
            fpsCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            fpsCombo.FormattingEnabled = true;
            fpsCombo.Items.AddRange(new object[] { "30", "60" });
            fpsCombo.Location = new Point(193, 83);
            fpsCombo.Margin = new Padding(4, 4, 4, 4);
            fpsCombo.Name = "fpsCombo";
            fpsCombo.Size = new Size(140, 24);
            fpsCombo.TabIndex = 8;
            // 
            // Info
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 122);
            Controls.Add(label4);
            Controls.Add(fpsCombo);
            Controls.Add(label3);
            Controls.Add(resCombo);
            Controls.Add(label2);
            Controls.Add(htkCombo);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Info";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Info";
            FormClosing += Info_FormClosing;
            Load += Info_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private CheckBox checkBox1;
        private ComboBox htkCombo;
        private Label label2;
        private Label label3;
        private ComboBox resCombo;
        private Label label4;
        private ComboBox fpsCombo;
    }
}