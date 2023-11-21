using ezclip.Classes;
using Timer = System.Windows.Forms.Timer;

namespace ezclip {
    public partial class Notification : Form {
        private Timer closeForm;
        private int second = 5;

        public Notification(string title, string text) {
            InitializeComponent();
            this.titleLabel.Text = title;
            this.textLabel.Text = text;
            closeForm = new Timer();
            closeForm.Interval = 1000;
            closeForm.Start();
            closeForm.Tick += closeForm_Tick;
        }

        public void closeForm_Tick(object sender, EventArgs e) {
            if(second != 1) {
                second--;
                label1.Text = $"(This message will close itself in {second}s)";
            } else {
                closeForm.Stop();
                this.Close();
            }

        }

        private void Message_Load(object sender, EventArgs e) {
            RoundCorners.ApplyRoundCorners(this, 30);
            RoundCorners.ApplyRoundCorners(pictureBox1, 20);
            this.TopMost = true;
            Screen primaryScreen = Screen.PrimaryScreen;
            this.Location = new System.Drawing.Point(primaryScreen.Bounds.Width - this.Width - 120, primaryScreen.Bounds.Height - this.Height - 120);
        }
    }
}