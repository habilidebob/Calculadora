using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        // Atributos / variáveis globais: 

        public Form1()
        {
            InitializeComponent();
        }
        private void numero_Click(object sender, EventArgs e)
        {
            // Identificar o elemento da interface que invocou o método:
            Button botao = (Button)sender;
            txbTela.Text += botao.Text;
        }
        private void operador_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            txbTela.Text += botao.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string tela = txbTela.Text;
            var v = dt.Compute(tela, "");
            txbTela.Text = v.ToString();
        }
    }
}
