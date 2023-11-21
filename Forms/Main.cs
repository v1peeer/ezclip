using ezclip.Classes;
using ezclip.Forms;
using Microsoft.Win32;
using Piksel.Graphics;
using System.Diagnostics;
using System.Security.Policy;

namespace ezclip {
    public partial class Main : Form {

        // todo: 
        // - clipping and recording using ffmpeg
        // - uploading
        // - make ui resizablwe

        //Hotkey System
        public GlobalHotkey ghk;
        public const int HOTKEY_ID = 1;
        public Keys key = Keys.X;
        public int modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_SHIFT;

        //Clip System
        public static bool clipService = false;
        public Recorder recorder = new Recorder();
        public Dictionary<string, string> videos = new Dictionary<string, string>();
        public static int width, height, fps;
        public static string hotkey;

        //Tray System
        public ContextMenuStrip contextMenuStrip;
        public bool isExiting = false;

        //Other
        public static string version = "1.1";
        public Discord discord;
        public static bool hideDiscordRPC = false;
        public bool isFontInstalled = false;
        public static Logger logger;
        public static string ffmpegDownload =
            "https://download852.mediafire.com/dcs2ypnvx37g_5aVixlUSx7cGsA6wlbSi_U2BKrRfvPHtLoWUP8gAvBypRVzqQburG3mYCtQl_W-bf0420ofOquoBtx3Zcx94UEQ9Tl6UscF2Aw1S-b61uC4V3ZzEqAC-KOwid7MfXajgsoXhpiMVYgpnsqIKt6CrlEQh7hgnMA7ZQ/q1tdhaxcwolxgnq/ffmpeg.exe";
        public static string fontDownload =
            "https://download1507.mediafire.com/qdur1aokhgzgcUrjd3aPsVh3oa-EkmGQaOFBXmWq7iL53XhabbPlDt88uxw5Oprw7GGlXkFt4bE7ixGkeamJkX_Kgau0uIdPhiSowqboEONdpGhpTJNorpZqsvCljuYGyDJ0aY894Y1og2U0Z-HDNou_rtm8BxqAK-CZb4NZ8ocgpw/n3mjtg6fmuwvk26/sfprodisplay-regular.otf";

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            DateTime now = DateTime.Now;
            if(m.Msg == 0x0312 && m.WParam.ToInt32() == HOTKEY_ID) {
                MessageBox.Show("Clip Pre");
                string invalidFileName = $"{GameGrabber.GetCurrentGame(false)}-{now:dd.MM.yyyy-HH.mm.ss}.mp4";
                string validFileName = new string(invalidFileName.Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)).ToArray()).Replace(" ", "");
                string completeFilePath = $"{Application.StartupPath}\\clips\\{validFileName}";
                recorder.Clip(completeFilePath);
                MessageBox.Show("Clip Post");
            }
        }

        public Main() {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e) {
            //Check if ezclip is already running
            if(Process.GetProcessesByName("ezclip").Any(p =>
                string.Equals(Path.GetFileNameWithoutExtension(p.ProcessName), "ezclip", StringComparison.OrdinalIgnoreCase)
                && p.Id != Process.GetCurrentProcess().Id)) {
                Main.logger.Error("Ezclip is already running! Exiting...", "(No exception)");
                isExiting = true;
                Application.Exit();
            }

            //Check if all folders exist
            if(!Directory.Exists(Application.StartupPath + "\\clips\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\clips\\");
            if(!Directory.Exists(Application.StartupPath + "\\resources\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\resources\\");
            if(!Directory.Exists(Application.StartupPath + "\\temp\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\temp\\");

            //Initialize Logger
            logger = new Logger(Application.StartupPath + "\\resources\\log.txt");

            //Set Title
            Text = Text.Replace("?", $"{version}");

            //Set Default Recording Variables
            float aspectRatio = (float)Screen.PrimaryScreen.Bounds.Width / Screen.PrimaryScreen.Bounds.Height;
            height = 1080;
            width = (int)(height * aspectRatio);
            fps = 60;
            hotkey = "CTRL SHIFT X";

            //Clear Temps
            ClearTemps();

            //Check if all resources exist
            if(!File.Exists(Application.StartupPath + "\\resources\\ffmpeg.exe")) {
                MessageBox.Show("Ezclip couldn't find ffmpeg.\nClick OK to download it!");
                new Downloader("ffmpeg.exe", ffmpegDownload).ShowDialog();
            }
            if(!File.Exists(Application.StartupPath + "\\resources\\sfprodisplay-regular.otf")) {
                MessageBox.Show("Ezclip couldn't find the required font.\nClick OK to download it!");
                new Downloader("sfprodisplay-regular.otf", fontDownload).ShowDialog();
            }

            //Initialize Hotkey System
            ghk = new GlobalHotkey(Handle, HOTKEY_ID);

            //Initialize Lists, Combos and Buttons
            stopBtn.Enabled = false;
            UpdateClips(null, null);

            //Initialize Discord RPC
            discord = new Discord();
            Task.Run(async () => await discord.UpdateDRPC());

            //Enhance Preview PictureBox
            RoundCorners.ApplyRoundCorners(previewPicture, 20);
            previewPicture.BackColor = Colour.FromArgb(255, 15, 15, 15);

            //Check if Font is installed
            using(Font font = new Font("SF Pro Display", 10f, FontStyle.Regular)) {
                StringComparison sc = StringComparison.InvariantCultureIgnoreCase;
                isFontInstalled = string.Compare("SF Pro Display", font.Name, sc) == 0;
            }
            if(!isFontInstalled) {
                MessageBox.Show("The required font isn't installed.\r\nClick OK to install it!");
                try {
                    File.Copy(Application.StartupPath + "\\resources\\sfprodisplay-regular.otf", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Fonts", "sfprodisplay-regular.otf"));
                    RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
                    key.SetValue("ezclip font", "sfprodisplay-regular.otf");
                    key.Close();
                    MessageBox.Show("Font installed!\nPlease restart Ezclip!");
                    Application.Exit();
                } catch(Exception ex) {
                    Console.Write(ex.StackTrace);
                    Main.logger.Error("Couldn't install the font!", ex.Message);
                    Application.Exit();
                }
            }

            //Add Tray Items
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add(this.Text);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(new ToolStripMenuItem("Show Window", null, ShowForm));
            contextMenuStrip.Items.Add(new ToolStripMenuItem("Exit Ezclip", null, ExitApplication));
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Visible = true;
        }

        public void ClearTemps() {
            if(Directory.Exists(Application.StartupPath + "\\temp\\")) {
                string[] files = Directory.GetFiles(Application.StartupPath + "\\temp\\");
                foreach(string file in files)
                    File.Delete(file);
            }
        }

        private void ShowForm(object sender, EventArgs e) {
            Show();
        }

        private void ExitApplication(object sender, EventArgs e) {
            isExiting = true;
            notifyIcon.Visible = false;
            ghk.UnregisterHotKey();
            logger.EndMessage();
            Application.Exit();
        }

        public void UpdateClips(object? sender, EventArgs? e) {
            listBox1.Items.Clear();
            videos.Clear();

            if(!Directory.Exists(Application.StartupPath + "\\clips\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\clips\\");

            string[] videoPaths = Directory.GetFiles(Application.StartupPath + "\\clips\\", "*.mp4", SearchOption.AllDirectories);

            List<string> sortedFileNames = new List<string>();

            foreach(string videoPath in videoPaths) {
                if(!videoPath.Contains("out")) {
                    string fileName = Path.GetFileNameWithoutExtension(videoPath);
                    sortedFileNames.Add(fileName);
                    videos[fileName] = videoPath;
                }
            }

            sortedFileNames.Sort((x, y) => DateTime.Compare(File.GetLastWriteTime(videos[y]), File.GetLastWriteTime(videos[x])));

            foreach(var fileName in sortedFileNames)
                listBox1.Items.Add(fileName);

            if(listBox1.Items.Count < 1)
                listBox1.Items.Add("You don't have any clips!");
        }

        public void startBtn_Click(object sender, EventArgs e) {
            clipService = true;
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            clipService = true;
            ghk.RegisterHotKey(key, modifiers);
            recorder.Start(width, height, fps);
        }
        public void stopBtn_Click(object sender, EventArgs e) {
            clipService = false;
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
            ghk.UnregisterHotKey();
            recorder.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if(!isExiting) {
                new Notification("Still in tray", "Right click the tray icon to exit").Show();
                e.Cancel = true;
                this.Hide();
            } else {
                e.Cancel = false;
                if(clipService)
                    recorder.Stop();
            }
        }

        public bool validClip() {
            if(listBox1.SelectedItem != null)
                if(listBox1.SelectedItem.ToString() != "You don't have any clips!")
                    return true;
            MessageBox.Show("You haven't selected a clip!");
            return false;
        }

        private void deleteBtn_Click(object sender, EventArgs e) {
            if(validClip()) {
                string selectedFileName = listBox1.SelectedItem.ToString();
                if(videos.ContainsKey(selectedFileName)) {
                    string selectedFilePath = videos[selectedFileName];
                    new Delete(this, selectedFilePath).Show();
                }
            }
        }

        private void infoBtn_Click(object sender, EventArgs e) {
            new Info(this).Show();
        }

        private void openBtn_Click(object sender, EventArgs e) {
            if(validClip()) {
                string selectedFileName = listBox1.SelectedItem.ToString();
                if(videos.ContainsKey(selectedFileName)) {
                    string selectedFilePath = videos[selectedFileName];
                    if(File.Exists(selectedFilePath)) {
                        Process.Start(new ProcessStartInfo {
                            FileName = selectedFilePath,
                            UseShellExecute = true
                        });
                    }
                }
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e) {
            if(validClip()) {
                string selectedFileName = listBox1.SelectedItem.ToString();
                if(videos.ContainsKey(selectedFileName)) {
                    string selectedFilePath = videos[selectedFileName];
                    if(File.Exists(selectedFilePath))
                        new Upload(selectedFilePath).Show();
                }
            }
        }
        private Bitmap ApplyTransparency(PictureBox pictureBox, int transparency) {
            Bitmap image = new Bitmap(pictureBox.Image);
            transparency = Math.Max(0, Math.Min(255, transparency));
            for(int y = 0; y < image.Height; y++) {
                for(int x = 0; x < image.Width; x++) {
                    Color pixel = image.GetPixel(x, y);
                    if(pixel.A != 0) {
                        Color updatedPixel = Color.FromArgb(transparency, pixel.R, pixel.G, pixel.B);
                        image.SetPixel(x, y, updatedPixel);
                    }
                }
            }
            return image;
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                this.Show();
        }

        private void renameBtn_Click(object sender, EventArgs e) {
            if(validClip()) {
                string selectedFileName = listBox1.SelectedItem.ToString();
                if(videos.ContainsKey(selectedFileName)) {
                    string selectedFilePath = videos[selectedFileName];
                    if(File.Exists(selectedFilePath))
                        new Rename(selectedFilePath, this).Show();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if(listBox1.SelectedItem != null) {
                if(listBox1.SelectedItem.ToString() != "You don't have any clips!") {
                    string selectedFileName = listBox1.SelectedItem.ToString();
                    if(videos.ContainsKey(selectedFileName)) {
                        string selectedFilePath = videos[selectedFileName];
                        if(File.Exists(selectedFilePath)) {
                            Screen primaryScreen = Screen.PrimaryScreen;
                            try {
                                previewPicture.Image = PreviewGrabber.GetThumbnail(selectedFilePath, primaryScreen.Bounds.Width, primaryScreen.Bounds.Height);
                            } catch(Exception ex) {
                                Main.logger.Error("Couldn't grab the preview!", ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}