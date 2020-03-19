using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Models.WMI;
using SysTool.Repositories;

namespace SysTool.Forms
{
    public partial class LoadForm : Form
    {
        #region Public Properties
        public BindingList<IDataUnit> WMIData { get; } = new BindingList<IDataUnit>();
        #endregion

        #region Private Properties
        private WMIRepository WMI { get; }
        private bool MouseDrag { get; set; }
        private int MouseX { get; set; }
        private int MouseY { get; set; }
        #endregion

        #region Constructors
        public LoadForm(WMIRepository wmi)
        {
            InitializeComponent();
            this.WMI = wmi;
        }
        #endregion

        #region Event Handlers
        private async void LoadForm_Load(object sender, EventArgs e)
        {
            await GetLDAPComputers()
                 .ConfigureAwait(true);
            this.Close();
        }
        private void LoadForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDrag = true;
            this.MouseX = Cursor.Position.X - this.Left;
            this.MouseY = Cursor.Position.Y - this.Right;
        }

        private void LoadForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseDrag = false;
        }

        private void LoadForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseDrag)
            {
                this.Top = Cursor.Position.Y - this.MouseY;
                this.Left = Cursor.Position.X - this.MouseX;
            }
        }
        #endregion

        #region Private Methods
        private async Task GetLDAPComputers()
        {
            var computers = await Task
                .Run(() => this.WMI.Get<ds_computer>(nameof(ds_computer)))
                .ConfigureAwait(true);

            this.WMIData.AddRange(computers);
        }

        private void FadeOutForm()
        {
            for (int opacity = 100; opacity == 0; opacity -= 2)
            {
                this.Opacity = opacity;
                Thread.Sleep(10);
            }
        }
        #endregion

    }
}
