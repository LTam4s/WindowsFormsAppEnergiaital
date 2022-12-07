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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            update_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kijelölve Energiaital!");
                return;
            }
            Program.cmd.Parameters.Clear();
            Program.cmd.CommandText = "UPDATE `energiaital` SET `nev`= @name,`mennyiseg`= @mennyiseg,`egysegar`= @egysegar WHERE id = @id;";
            Program.cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            Program.cmd.Parameters.AddWithValue("@name", textBoxNev.Text);
            Program.cmd.Parameters.AddWithValue("@mennyiseg", numericUpDownMennyiseg.Value);
            Program.cmd.Parameters.AddWithValue("@egysegar", numericUpDownEgysegar.Value);
            Program.conn.Open();
            if (Program.cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Módosítás sikeres volt!");
                textBoxId.Text = "";
                textBoxNev.Text = "";
                numericUpDownMennyiseg.Value = numericUpDownMennyiseg.Minimum;
                numericUpDownEgysegar.Value = numericUpDownEgysegar.Minimum;
            }
            else
            {
                MessageBox.Show("Az adatok módosítása sikertelen!");
            }
            Program.conn.Close();
            update_list();

        }

        private void update_list()
        {
            numericUpDownEgysegar.Maximum = int.MaxValue;
            numericUpDownMennyiseg.Maximum = int.MaxValue;
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
            textBoxNev.Text = kivalasztott_ei.Name;
            numericUpDownMennyiseg.Value = kivalasztott_ei.Mennyiseg;
            numericUpDownEgysegar.Value = kivalasztott_ei.Egysegar;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Program.EiNew.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Program.EiDelete.ShowDialog();
        }
    }
}
