using System;
using System.Windows.Forms;

namespace system_university
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login loginForm = new Login();
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.IsAuthenticated)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
