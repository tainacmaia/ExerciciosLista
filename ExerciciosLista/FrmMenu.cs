namespace ExerciciosLista
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new frmExercicio1();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new frmExercicio2();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}