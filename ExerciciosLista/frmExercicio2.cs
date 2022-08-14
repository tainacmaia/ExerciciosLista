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
    public partial class frmExercicio2 : Form
    {
        List<int> listaInteiros = new();
        int numero;
        int maiorValor;
        int menorValor;

        public frmExercicio2()
        {
            InitializeComponent();
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
            if (listaInteiros.Count != 0)
            {
                maiorValor = listaInteiros.Max();
                menorValor = listaInteiros.Min();
                lblResultado.Text = $"Diferença entre o maior e o menor valor: {CalculaDiferenca(maiorValor, menorValor)}";
            }
            else
            {
                lblResultado.Text = "Diferença entre o maior e o menor valor: 0";
            }
            textBox1.Enabled = false;
        }

        private int CalculaDiferenca(int maior, int menor)
        {
            return maior - menor;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new frmExercicio2();
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
