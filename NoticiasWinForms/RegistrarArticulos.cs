using NoticiasWebApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticiasWinForms
{
    public partial class RegistrarArticulos : Form
    {
        static readonly HttpClient httpClient = new HttpClient();

        ArticulosDto objArticulo = null;
        public RegistrarArticulos()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("https://localhost:44340/");
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionArticulos ga = new GestionArticulos();
            ga.ShowDialog();
        }

        private void GetCategorias()
        {
            var response = httpClient.GetAsync("/api/Categorias").Result;
            var responseTest = response.Content.ReadAsStringAsync().Result;

          
        }


        private void RegistrarArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
