using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cruud
{
    public partial class Form1 : Form
    {
        List<Datos> ListDatos = new List<Datos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar() 
        {
            txtNombre.Text = "";
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtEdad.Text = "";
            cmbCiudad.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text=="")
            {
                errorProvider.SetError(txtNombre, "Debe ingresar Nombre");
                txtNombre.Focus();
                return;
            }

            if(txtApePat.Text=="")
            {
                errorProvider.SetError(txtApePat, "Debe ingresar Apellido Paterno");
                txtApePat.Focus();
                return;
            }
            if (txtApeMat.Text == "")
            {
                errorProvider.SetError(txtApeMat, "Debe ingresar Apellido Materno");
                txtApeMat.Focus();
                return;
            }
            if (txtEdad.Text == "")
            {
                errorProvider.SetError(txtEdad, "Debe ingresar Edad");
                txtEdad.Focus();
                return;
            }

            Datos Registro = new Datos();
            Registro.Nombre = txtNombre.Text;
            Registro.ApePat = txtApePat.Text;
            Registro.ApeMat = txtApeMat.Text;
            Registro.Edad = int.Parse(txtEdad.Text);
            Registro.Ciudad = cmbCiudad.SelectedItem.ToString();
            ListDatos.Add(Registro);

            MessageBox.Show("Se ha registrado correctamente");
            Limpiar();
        }

        public void SoloCaracter(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;

                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo Acepta Caracter", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (FormatException)
            {

            }
        }

        public void SoloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo Acepta Numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (FormatException)
            {

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloCaracter(e);
        }

        private void txtApePat_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloCaracter(e);
        }

        private void txtApeMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloCaracter(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

            //ListDatos
            Consulta K = new Consulta(ListDatos);
            K.ShowDialog();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    
    }
}
