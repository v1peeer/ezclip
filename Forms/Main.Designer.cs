using ezclip.Classes;

namespace ezclip {
    partial class Main {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            listBox1 = new ListBox();
            notifyIcon = new NotifyIcon(components);
            renameBtn = new BetterBtn();
            infoBtn = new BetterBtn();
            refreshBtn = new BetterBtn();
            deleteBtn = new BetterBtn();
            openBtn = new BetterBtn();
            uploadBtn = new BetterBtn();
            previewPicture = new PictureBox();
            stopBtn = new Button();
            startBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)renameBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)infoBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)refreshBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deleteBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)openBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uploadBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)previewPicture).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 16;
            listBox1.Items.AddRange(new object[] { "You don't have any clips!" });
            listBox1.Location = new Point(8, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(510, 196);
            listBox1.TabIndex = 11;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "ezclip";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += trayIcon_MouseClick;
            // 
            // renameBtn
            // 
            renameBtn.Image = ezclip_fix.Properties.Resources.rename_white;
            renameBtn.Location = new Point(302, 234);
            renameBtn.Name = "renameBtn";
            renameBtn.Size = new Size(34, 34);
            renameBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            renameBtn.TabIndex = 23;
            renameBtn.TabStop = false;
            renameBtn.Click += renameBtn_Click;
            // 
            // infoBtn
            // 
            infoBtn.Image = ezclip_fix.Properties.Resources.info_white;
            infoBtn.Location = new Point(462, 234);
            infoBtn.Name = "infoBtn";
            infoBtn.Size = new Size(34, 34);
            infoBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            infoBtn.TabIndex = 22;
            infoBtn.TabStop = false;
            infoBtn.Click += infoBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.Image = ezclip_fix.Properties.Resources.refresh_white;
            refreshBtn.Location = new Point(422, 234);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(34, 34);
            refreshBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            refreshBtn.TabIndex = 21;
            refreshBtn.TabStop = false;
            refreshBtn.Click += UpdateClips;
            // 
            // deleteBtn
            // 
            deleteBtn.Image = ezclip_fix.Properties.Resources.delete_white;
            deleteBtn.Location = new Point(382, 234);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(34, 34);
            deleteBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            deleteBtn.TabIndex = 20;
            deleteBtn.TabStop = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // openBtn
            // 
            openBtn.Image = ezclip_fix.Properties.Resources.open_white;
            openBtn.Location = new Point(262, 234);
            openBtn.Name = "openBtn";
            openBtn.Size = new Size(34, 34);
            openBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            openBtn.TabIndex = 19;
            openBtn.TabStop = false;
            openBtn.Click += openBtn_Click;
            // 
            // uploadBtn
            // 
            uploadBtn.Image = ezclip_fix.Properties.Resources.upload_white;
            uploadBtn.Location = new Point(342, 234);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(34, 34);
            uploadBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            uploadBtn.TabIndex = 18;
            uploadBtn.TabStop = false;
            uploadBtn.Click += uploadBtn_Click;
            // 
            // previewPicture
            // 
            previewPicture.BackColor = SystemColors.ControlDark;
            previewPicture.Location = new Point(8, 216);
            previewPicture.Name = "previewPicture";
            previewPicture.Size = new Size(219, 123);
            previewPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            previewPicture.TabIndex = 16;
            previewPicture.TabStop = false;
            // 
            // stopBtn
            // 
            stopBtn.BackgroundImage = ezclip_fix.Properties.Resources.stop_white;
            stopBtn.BackgroundImageLayout = ImageLayout.Stretch;
            stopBtn.Location = new Point(380, 294);
            stopBtn.Margin = new Padding(4);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(138, 45);
            stopBtn.TabIndex = 1;
            stopBtn.Text = "                   Stop";
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click;
            // 
            // startBtn
            // 
            startBtn.BackgroundImage = ezclip_fix.Properties.Resources.start_white;
            startBtn.BackgroundImageLayout = ImageLayout.Stretch;
            startBtn.Location = new Point(234, 294);
            startBtn.Margin = new Padding(4);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(138, 45);
            startBtn.TabIndex = 0;
            startBtn.Text = "                    Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 348);
            Controls.Add(renameBtn);
            Controls.Add(infoBtn);
            Controls.Add(refreshBtn);
            Controls.Add(deleteBtn);
            Controls.Add(openBtn);
            Controls.Add(uploadBtn);
            Controls.Add(previewPicture);
            Controls.Add(listBox1);
            Controls.Add(stopBtn);
            Controls.Add(startBtn);
            Font = new Font("SF Pro Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ezclip ~ v?";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)renameBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)infoBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)refreshBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)deleteBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)openBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)uploadBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)previewPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button startBtn;
        private Button stopBtn;
        private ListBox listBox1;
        private PictureBox previewPicture;
        private NotifyIcon notifyIcon;
        private BetterBtn uploadBtn;
        private BetterBtn openBtn;
        private BetterBtn deleteBtn;
        private BetterBtn refreshBtn;
        private BetterBtn infoBtn;
        private BetterBtn renameBtn;
    }
}

