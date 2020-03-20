using System.ComponentModel;
using System.Windows.Forms;
using SysTool.Models;

namespace SysTool.Forms
{
    public partial class LoadForm : Form
    {
        #region Public Properties
        public BindingList<IDataUnit> WMIData { get; } = new BindingList<IDataUnit>();
        #endregion

        #region Private Properties
        private bool MouseDrag { get; set; }
        private int MouseX { get; set; }
        private int MouseY { get; set; }
        #endregion

        #region Constructors
        public LoadForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void this_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDrag = true;
            this.MouseX = Cursor.Position.X - this.Left;
            this.MouseY = Cursor.Position.Y - this.Top;
        }

        private void this_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseDrag)
            {
                this.Top = Cursor.Position.Y - this.MouseY;
                this.Left = Cursor.Position.X - this.MouseX;
            }
        }

        private void this_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseDrag = false;
        }
        #endregion
    }
}
