using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEnergiaital
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Program.cmd.CommandText = "SELECT `id`, `nev`, `egysegar`, `mennyiseg` FROM `energiaital` WHERE 1";
            Program.conn.Open();
            using (MySqlDataReader dr = Program.cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Energiaital energiaitalok = new Energiaital(dr.GetInt32("id"), dr.GetString("nev"), dr.GetInt32("egysegar"), dr.GetInt32("mennyiseg"));
                    listBox1.Items.Add(energiaitalok);
                }
            }
            Program.conn.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Program.EiNew.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Program.EiUpdate.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Program.EiDelete.ShowDialog();

        }
    }
}
