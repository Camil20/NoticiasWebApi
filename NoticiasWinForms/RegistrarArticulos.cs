using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticiasWinForms
{
    public partial class RegistrarArticulos : Form
    {
        public RegistrarArticulos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionArticulos ga = new GestionArticulos();
            ga.ShowDialog();
        }
    }
}
