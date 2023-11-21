using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ezclip.Classes {
    public class RoundCorners {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public static void ApplyRoundCorners(Control element, int radius) {
            element.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, element.Width, element.Height, radius, radius));
        }
    }
}