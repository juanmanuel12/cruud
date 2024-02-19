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
    public partial class Consulta : Form
    {

        List<Datos> LA;
        public Consulta(List<Datos> lista)
        {
            InitializeComponent();
            LA = lista;
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            foreach(Datos dat in LA )
            {
                dataGridView1.Rows.Add(dat.Nombre, dat.ApePat, dat.ApeMat, dat.Edad, dat.Ciudad);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Datos datelim in LA)
            {

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

            }
        }
    }
}
