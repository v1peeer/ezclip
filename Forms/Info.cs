using ezclip.Classes;

namespace ezclip {
    public partial class Info : Form {
        Main main;
        public Info(Main main) {
            InitializeComponent();
            this.main = main;
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e) {
            if(checkBox1.Checked)
                Main.hideDiscordRPC = true;
            else
                Main.hideDiscordRPC = false;
        }

        private void Info_Load(object sender, System.EventArgs e) {
            if(Main.hideDiscordRPC)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            label1.Text = label1.Text.Replace("?", $"{Main.version}");
            htkCombo.Text = Main.hotkey;
            resCombo.Text = Main.height.ToString();
            fpsCombo.Text = Main.fps.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e) {
            main.ghk.UnregisterHotKey();
            if(htkCombo.Text == "CTRL SHIFT A") {
                main.key = Keys.A;
                main.modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_SHIFT;
            }
            if(htkCombo.Text == "CTRL SHIFT C") {
                main.key = Keys.C;
                main.modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_SHIFT;
            }
            if(htkCombo.Text == "CTRL SHIFT X") {
                main.key = Keys.X;
                main.modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_SHIFT;
            }
            if(htkCombo.Text == "CTRL ALT A") {
                main.key = Keys.A;
                main.modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_ALT;
            }
            if(htkCombo.Text == "CTRL ALT C") {
                main.key = Keys.C;
                main.modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_ALT;
            }
            if(htkCombo.Text == "CTRL ALT X") {
                main.key = Keys.X;
                main.modifiers = GlobalHotkey.MOD_CTRL | GlobalHotkey.MOD_ALT;
            }
            if(Main.clipService)
                main.ghk.RegisterHotKey(main.key, main.modifiers);

        }

        private void Info_FormClosing(object sender, FormClosingEventArgs e) {
            float aspectRatio = (float)Screen.PrimaryScreen.Bounds.Width / Screen.PrimaryScreen.Bounds.Height;
            Main.hotkey = htkCombo.Text;
            Main.height = Int32.Parse(resCombo.Text);
            Main.width = (int)(Main.height * aspectRatio);
            Main.fps = Int32.Parse(fpsCombo.Text);
        }
    }
}