using System;
using System.Drawing;
using System.Windows.Forms;

namespace ezclip.Classes {
    public class BetterBtn : PictureBox {
        public BetterBtn() {
            Size = new Size(34, 34);
            SizeMode = PictureBoxSizeMode.StretchImage;
            TabStop = false;

            MouseEnter += new EventHandler(this.CustomPictureBox_MouseEnter);
            MouseLeave += new EventHandler(this.CustomPictureBox_MouseLeave);
        }

        private void CustomPictureBox_MouseEnter(object sender, EventArgs e) {
            Image = ApplyTransparency(this, 100);
        }

        private void CustomPictureBox_MouseLeave(object sender, EventArgs e) {
            Image = ApplyTransparency(this, 255);
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
    }
}