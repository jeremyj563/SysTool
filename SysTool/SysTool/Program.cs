// Adapted from:
// Asynchronous Programming - Async from the Start
// https://msdn.microsoft.com/en-us/magazine/mt620013.aspx

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Forms;
using SysTool.Utilities;

namespace SysTool
{
    public class Program
    {
        #region Public Events
        public event EventHandler<EventArgs> ExitRequested;
        #endregion

        #region Private Properties
        private LoadForm LoadForm { get; } = new LoadForm(DIContainer.LocalWMI);
        #endregion

        #region Constructors
        private Program()
        {
            //UserSettings.Settings.Seed();
            this.LoadForm.FormClosed += MainForm_FormClosed;
        }
        #endregion
  
        #region Event Handlers
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnExitRequested(EventArgs.Empty);
        }

        protected virtual void OnExitRequested(EventArgs e)
        {
            ExitRequested?.Invoke(this, e);
        }

        private static void Program_ExitRequested(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        #endregion

        #region Public Methods
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var context = new WindowsFormsSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);

            var program = new Program();
            program.ExitRequested += Program_ExitRequested;

            Task programStart = program.StartAsync();
            HandleExceptions(programStart);

            Application.Run();
        }
        #endregion

        #region Private Methods
        private async Task StartAsync()
        {
            if (this.LoadForm.ShowDialog() != DialogResult.Abort)
            {
                var form = new MainForm(this.LoadForm.WMIData);
                await ShowMainForm(form);
            }
        }

        private async Task ShowMainForm(MainForm mainForm)
        {
            mainForm.FormClosed += MainForm_FormClosed;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            await mainForm.InitializeAsync();
            mainForm.Show();
        }

        private static async void HandleExceptions(Task task)
        {
            try
            {
                // Force this to yield to the caller, so Application.Run() will be executing
                await Task.Yield();
                await task;
            }
            catch (Exception ex)
            {
                string message = ex.GetType().Name;
                message += Environment.NewLine;
                message += ex.Message;
                message += Environment.NewLine;
                message += ex.StackTrace;

                MessageBox.Show(message, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        #endregion
    }
}
