using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsAppEnergiaital
{
    internal static class Program
    {
        static public View EiView = null;
        static public New EiNew = null;
        static public Update EiUpdate = null;
        static public Delete EiDelete = null;
        static public Form1 Ei = null;
        static public MySqlConnection conn = new MySqlConnection();
        static public MySqlCommand cmd = new MySqlCommand();
        [STAThread]
        static void Main()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "energiaital";
            conn = new MySqlConnection(builder.ConnectionString);
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "A program leáll!");
                Environment.Exit(0);
                throw;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EiView = new View();
            EiNew = new New();
            EiUpdate = new Update();
            EiDelete = new Delete();
            Ei = new Form1();
            Application.Run(Ei);
        }
    }
}
