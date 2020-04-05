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
        #region Public Methods
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var context = new WindowsFormsSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);

            var program = new Program();
            Task programStart = program.StartAsync();
            
            // Handle any exception thrown in mainForm.InitializeAsync()
            HandleExceptions(programStart);

            Application.Run();
        }
        #endregion

        #region Private Methods
        private async Task StartAsync()
        {
            using var splashForm = new SplashForm();
            splashForm.Show();

            var mainForm = new MainForm(DIContainer.ComputerRepository);
            mainForm.FormClosed += (s, e) => Application.ExitThread();
            mainForm.Shown += (s, e) => splashForm.Close();
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
                message += Environment.NewLine;
                message += ex.Message;
                message += Environment.NewLine;
                message += Environment.NewLine;
                message += ex.StackTrace;

                MessageBox.Show(message, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        #endregion
    }
}
