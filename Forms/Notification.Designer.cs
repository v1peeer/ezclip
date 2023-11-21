namespace ezclip {
    partial class Notification {
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
            titleLabel = new Label();
            textLabel = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("SF Pro Display", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(91, 10);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(213, 35);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Notification Title";
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textLabel.Location = new Point(94, 48);
            textLabel.Margin = new Padding(4, 0, 4, 0);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(115, 19);
            textLabel.TabIndex = 1;
            textLabel.Text = "Notification Text";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ezclip_fix.Properties.Resources.ez1024;
            pictureBox1.Location = new Point(14, 15);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(94, 73);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(206, 16);
            label1.TabIndex = 3;
            label1.Text = "(This message will close itself in 5s)";
            // 
            // Notification
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 108);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(textLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Notification";
            Text = "Notification";
            Load += Message_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label textLabel;
        private PictureBox pictureBox1;
        private Label label1;
    }
}