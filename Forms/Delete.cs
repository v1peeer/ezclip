using System;
using System.Collections.Generic;
namespace ezclip.Forms {
    public partial class Delete : Form {
        Main mainForm;
        string filePath;

        public Delete(Main mainForm, string filePath) {
            InitializeComponent();
            this.mainForm = mainForm;
            this.filePath = filePath;
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                File.Delete(filePath);
            } catch(Exception ex) {
                Main.logger.Error("Couldn't delete the clip!", ex.Message);
            }
            mainForm.UpdateClips(null, null);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
