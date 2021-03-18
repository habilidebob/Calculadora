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
        bool ultimoOp = true;
        int contOp = 0;
        string[] ops = { "+", "-", "*", "/" };
        private bool ultimoEhOperador()
        {
            string ultimo = txbTela.Text;
            ultimo = ultimo.Substring(ultimo.Length - 1);
            if (ops.Contains(ultimo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void numero_Click(object sender, EventArgs e)
        {
            // Identificar o elemento da interface que invocou o método:
            Button botao = (Button)sender;
            txbTela.Text += botao.Text;
            ultimoOp = false;
        }
        private void operador_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (ultimoEhOperador())
            {
                txbTela.Text = txbTela.Text.Remove(txbTela.Text.Length - 1);
                ultimoOp = false;
            }
            if (contOp == 1 && ultimoOp == false)
            {
                contOp = 0;
                btnIgual.PerformClick();
            }
            if (ultimoOp == false)
            {
                txbTela.Text += botao.Text;
                ultimoOp = true;
                contOp++;
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (ultimoEhOperador())
            {
                txbTela.Text = txbTela.Text.Remove(txbTela.Text.Length - 1);
                ultimoOp = false;
            }
            DataTable dt = new DataTable();
            string tela = txbTela.Text;
            txbAux.Text = tela;
            var v = dt.Compute(tela, "");
            txbTela.Text = v.ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Text = "";
            txbAux.Text = "";
            ultimoOp = false;
        }
    }
}
