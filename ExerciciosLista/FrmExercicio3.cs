using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciciosLista
{
    public partial class frmExercicio3 : Form
    {
        List<int> listaInteiros = new();
        int numero;
        int numeroProximo;
        bool empate = false;

        public frmExercicio3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                lblRegistro.Text = "";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && int.TryParse(textBox1.Text, out numero))
            {
                listaInteiros.Add(int.Parse(textBox1.Text));
                textBox1.Clear();
                textBox1.Focus();
                lblRegistro.Text = $"Número {numero} registrado!";
            }
            else
            {
                textBox1.Clear();
                lblRegistro.Text = "Inválido, digite novamente";
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter &&
    textBox1 != null && int.TryParse(textBox1.Text, out numero))
            {
                e.Handled = true;
                listaInteiros.Add(int.Parse(textBox1.Text));
                textBox1.Clear();
                textBox1.Focus();
                lblRegistro.Text = $"Número {numero} registrado!";
                ltbLista.Items.Add(numero);
            }

            else if (e.KeyChar != (char)Keys.Enter)
            {
            }

            else
            {
                textBox1.Clear();
                lblRegistro.Text = "Inválido, digite novamente";
                textBox1.Focus();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaInteiros.Count; i++)
            {
                if (i == 0)
                {
                    numeroProximo = listaInteiros[i];
                }
                if (numeroProximo > listaInteiros[i])
                {
                    numeroProximo = listaInteiros[i];
                }
                if (i == listaInteiros.Count - 1 && 
                    listaInteiros.Any(x => Math.Abs(x-0) == Math.Abs(numeroProximo-0) && x != numeroProximo))
                {
                    lblResultado.Text = "Número mais próximo de zero: Nenhum";
                    empate = true;
                    textBox1.Enabled = false;
                }
            }

            if (!empate && listaInteiros.Count != 0)
            {
                lblResultado.Text = $"Número mais próximo de zero: {numeroProximo}";
                textBox1.Enabled = false;
            }

            if (listaInteiros.Count == 0)
            {
                lblResultado.Text = "Não há números para cálculo.";
                textBox1.Focus();
            }

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new frmExercicio3();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FrmMenu();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
