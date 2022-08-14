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
    public partial class frmExercicio1 : Form
    {
        List<int> listaInteiros = new();
        int totalPositivos;
        int somaNegativos;
        int numero;
        int contaZeros = 0;

        public frmExercicio1()
        {
            InitializeComponent();
        }

        private void Exercicio1_Load(object sender, EventArgs e)
        {

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

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FrmMenu();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            foreach (int i in listaInteiros)
            {
                ltbLista.Items.Add(i);
                if (i > 0)
                    totalPositivos++;
                if (i < 0)
                    somaNegativos += i;
                if (i == 0)
                    contaZeros++;
            }
            if (listaInteiros.Count != 0 && listaInteiros.Count != contaZeros)
            {
            lblQtd.Text = $"Quantidade de números positivos: {totalPositivos}";
            lblSoma.Text = $"Soma dos números negativos: {somaNegativos}";
            }
            else if (listaInteiros.Count == contaZeros)
            {
                lblQtd.Text = "A lista é nula.";
            }
            else
            {
                lblQtd.Text = "Não há números para cálculo.";
            }
            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                lblRegistro.Text = "";
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
                this.Hide();
                var form = new frmExercicio1();
                form.Closed += (s, args) => this.Close();
                form.Show();
        }
    }
}
