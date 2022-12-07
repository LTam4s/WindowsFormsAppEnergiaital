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
    public partial class New : Form
    {
        public New()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            Program.conn.Open();
            if (string.IsNullOrEmpty(textBoxNev.Text))
            {
                MessageBox.Show("Adjon meg nevet!");
                textBoxNev.Focus();
                Program.conn.Close();
                return;
            }
            Program.cmd.CommandText = "INSERT INTO `energiaital`(`nev`, `egysegar`, `mennyiseg`) VALUES (@nev, @ar, @mennyiseg)";
            Program.cmd.Parameters.Clear();
            Program.cmd.Parameters.AddWithValue("@nev", textBoxNev.Text);
            Program.cmd.Parameters.AddWithValue("@ar", numericUpDownEgysegar.Value.ToString());
            Program.cmd.Parameters.AddWithValue("@mennyiseg", numericUpDownMennyiseg.Value.ToString());
            try
            {
                if (Program.cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeresen rögzítve!");
                    textBoxId.Text = "";
                    textBoxNev.Text = "";
                    numericUpDownEgysegar.Value = numericUpDownEgysegar.Minimum;
                    numericUpDownMennyiseg.Value = numericUpDownMennyiseg.Minimum;

                }
                else
                {
                    MessageBox.Show("sikertelen rögzítés!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Program.conn.Close();
            }
            Program.conn.Close();
            update_list();
        }

        private void update_list()
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

        private void New_Load(object sender, EventArgs e)
        {
            numericUpDownEgysegar.Maximum = int.MaxValue;
            numericUpDownMennyiseg.Maximum = int.MaxValue;
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
