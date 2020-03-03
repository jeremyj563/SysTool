// Adapted from:
// Asynchronous Programming - Async from the Start
// https://msdn.microsoft.com/en-us/magazine/mt620013.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTool.Forms;

namespace SysTool
{
    public class Program
    {
        #region Public Events

        public event EventHandler<EventArgs> ExitRequested;

        #endregion

        #region Private Properties

        private MainForm LaunchForm { get; }

        #endregion

        private Program()
        {
            //UserSettings.Settings.Seed();

            this.LaunchForm = new MainForm();
            this.LaunchForm.FormClosed += MainForm_FormClosed;
        }

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
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

            var program = new Program();
            program.ExitRequested += Program_ExitRequested;
            Task programStart = program.StartAsync();

            HandleExceptions(programStart);

            Application.Run();
        }

        public async Task StartAsync()
        {
            await this.LaunchForm.InitializeAsync();
            this.LaunchForm.StartPosition = FormStartPosition.CenterScreen;

            if (this.LaunchForm.ShowDialog() != DialogResult.Abort)
            {
                await ShowMainForm(new MainForm());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the main form of type <see cref="MainFormBase{TSheetRecord, TDBRecord}"/>
        /// </summary>
        /// <param name="mainForm">The main form to show.</param>
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
