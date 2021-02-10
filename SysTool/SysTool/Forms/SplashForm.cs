using System.Windows.Forms;

namespace SysTool.Forms {
    public partial class SplashForm : Form {

        #region Private Properties
        private bool MouseDrag { get; set; }
        private int MouseX { get; set; }
        private int MouseY { get; set; }
        #endregion

        #region Constructors
        public SplashForm() {
            this.InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void SplashForm_MouseDown(object sender, MouseEventArgs e) {
            this.MouseDrag = true;
            this.MouseX = Cursor.Position.X - this.Left;
            this.MouseY = Cursor.Position.Y - this.Top;
        }
        private void SplashForm_MouseMove(object sender, MouseEventArgs e) {
            if (this.MouseDrag) {
                this.Top = Cursor.Position.Y - this.MouseY;
                this.Left = Cursor.Position.X - this.MouseX;
            }
        }
        private void SplashForm_MouseUp(object sender, MouseEventArgs e) {
            this.MouseDrag = false;
        }
        #endregion
    }
}
