using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ezclip.Classes {
    //von LUCKYONE
    public class GlobalHotkey {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Konstanten für Modifier-Keys
        public const int MOD_ALT = 0x1;
        public const int MOD_CTRL = 0x2;
        public const int MOD_SHIFT = 0x4;
        public const int MOD_WIN = 0x8;

        // Handle
        private IntPtr hWnd;
        private int id;

        public GlobalHotkey(IntPtr hWnd, int id) {
            this.hWnd = hWnd;
            this.id = id;
        }

        public bool RegisterHotKey(Keys key, int modifiers) {
            // Keys-Enumeration to Virtual-Key-Code
            int vlc = (int)key;

            // Register Hotkey
            return RegisterHotKey(this.hWnd, this.id, modifiers, vlc);
        }

        public bool UnregisterHotKey() {
            // De-Registriere den Hotkey
            return UnregisterHotKey(this.hWnd, this.id);
        }
    }
}