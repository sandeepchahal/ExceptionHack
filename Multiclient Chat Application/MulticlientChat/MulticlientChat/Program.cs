using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticlientChat
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLDataAccess sql = new SQLDataAccess();
           
            string Email= sql.GetUserEmailFromLocal();

            if (Email != null)
            {
                ListOfUsersWindow.EmailOfUser = Email;
                Application.Run(new ListOfUsersWindow());
            }
            else
            {
                Application.Run(new StartingWindow());
            }

        }

    }
}
