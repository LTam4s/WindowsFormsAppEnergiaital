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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            Program.EiView.ShowDialog();

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
