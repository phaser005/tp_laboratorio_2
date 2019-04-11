using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class MiCalculadora : Form
    {





        public MiCalculadora()
        {
            InitializeComponent();

            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static double Operar (string numero1, string numero2, string operador)
        {
            double result = 0;

            Numero numeroAux1 = new Numero(numero1);
            Numero numeroAux2 = new Numero(numero2);
            result = Calculadora.Operar(numeroAux1, numeroAux2, operador);


            return result;
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Convert.ToString( Operar(txtNumero1.Text, txtNumero2.Text, (string)cmbOperador.SelectedItem));   
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numeroaux = new Numero();
            lblResultado.Text = numeroaux.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numeroaux = new Numero();
            lblResultado.Text = numeroaux.BinarioDecimal(lblResultado.Text);
        }
    }
}
