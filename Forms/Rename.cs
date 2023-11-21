using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ezclip.Forms {
    public partial class Rename : Form {
        public string filePath;
        public Main main;

        public Rename(string filePath, Main main) {
            InitializeComponent();
            this.filePath = filePath;
            this.main = main;
            label1.Text = label1.Text.Replace("%69%", Path.GetFileName(filePath));
            textBox1.Text = Path.GetFileName(filePath).Replace(".mp4", "");
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                if(!textBox1.Text.EndsWith(".mp4"))
                    textBox1.Text = textBox1.Text + ".mp4";
                File.Move(filePath, Path.GetDirectoryName(filePath) + "\\" + textBox1.Text);
                main.UpdateClips(null, null);
                this.Close();
            } catch (Exception ex) {
                Main.logger.Error("Couldn't rename the clip!", ex.Message);
                this.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e) {
            this.Close();
        }
    }
}
