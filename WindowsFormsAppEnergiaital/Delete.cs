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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            Program.cmd.CommandText = "DELETE FROM `energiaital` WHERE `id` = @id";
            Program.cmd.Parameters.Clear();
            Program.cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            Program.conn.Open();
            if (Program.cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Törlés sikeres");
                Program.conn.Close();
                textBoxId.Text = "";
            }
            else
            {
                MessageBox.Show("Törlés sikertelen");
            }
            update_list();
        }
        private void update_list()
        {
            listBox1.Items.Clear();
            Program.cmd.CommandText = "SELECT * FROM `energiaital`";
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            Energiaital kivalasztott_ei = (Energiaital)listBox1.SelectedItem;
            textBoxId.Text = kivalasztott_ei.Id.ToString();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            update_list();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Program.EiNew.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Program.EiUpdate.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
