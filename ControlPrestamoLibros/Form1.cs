using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlPrestamoLibros
{
    public partial class Form1 : Form
    {
        //contador de libros
        private int n;
        public Form1()
        {
            InitializeComponent();
            n = 0;

            //configurar el datagridview

            dgvLibros.Columns.Add("ISBN", "ISBN");
            dgvLibros.Columns.Add("Titulo", "Título");
            dgvLibros.Columns.Add("Autor", "Autor");
            dgvLibros.Columns.Add("Paginas", "Número de páginas");
            dgvLibros.Columns.Add("UsuarioInterno", "UsuarioInterno");
            dgvLibros.Columns.Add("EstadoInterno", "EstadoInterno");

            dgvLibros.AutoSize = true;
            dgvLibros.Columns["UsuarioInterno"].Visible = false;
            dgvLibros.Columns["EstadoInterno"].Visible = false;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Estado";
            img.Name = "imgEstado";
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img.Width = 50;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Acciones";
            btn.Name = "btnAcciones";

            dgvLibros.Columns.Add(img);
            dgvLibros.Columns.Add(btn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //crear nuevo libro
            dgvLibros.Rows.Add();
            dgvLibros.Rows[n].Cells["ISBN"].Value = "88220939393";
            dgvLibros.Rows[n].Cells["Titulo"].Value = "Programación Orientad a Objetos";
            dgvLibros.Rows[n].Cells["Autor"].Value = "Jhon Carnak";
            dgvLibros.Rows[n].Cells["Paginas"].Value = "450";
            dgvLibros.Rows[n].Cells["UsuarioInterno"].Value = "";
            dgvLibros.Rows[n].Cells["EstadoInterno"].Value = "D";//D es disponible, P es prestado
            dgvLibros.Rows[n].Cells["imgEstado"].Value = Properties.Resources.disponible;
            dgvLibros.Rows[n].Cells["btnAcciones"].Value = "Prestar";

        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //validar un click sobre la imagen
            if (e.ColumnIndex == dgvLibros.Columns["imgEstado"].Index && dgvLibros.Rows[e.RowIndex].Cells["EstadoInterno"].Value.Equals("P"))
            {
                MessageBox.Show("La última persona que lo prestó fue: " + dgvLibros.Rows[e.RowIndex].Cells["UsuarioInterno"].Value);
            }

            //validar si el indice de la columna a la cual se ha dado click
            //es la la columna del boton acciones...
            if (e.ColumnIndex == dgvLibros.Columns["btnAcciones"].Index)
            {
                if (dgvLibros.Rows[e.RowIndex].Cells["EstadoInterno"].Value.Equals("D"))
                {

                    frmPrestar ventanaPrestamo = new frmPrestar();
                    ventanaPrestamo.ShowDialog();

                    if (!ventanaPrestamo.nombreUsuario.Equals(""))
                    {
                        dgvLibros.Rows[e.RowIndex].Cells["EstadoInterno"].Value = "P";
                        dgvLibros.Rows[e.RowIndex].Cells["btnAcciones"].Value = "Devolver";
                        dgvLibros.Rows[e.RowIndex].Cells["imgEstado"].Value = Properties.Resources.prestado;
                        dgvLibros.Rows[e.RowIndex].Cells["UsuarioInterno"].Value = ventanaPrestamo.nombreUsuario;

                    }
                }
                else
                {

                    dgvLibros.Rows[e.RowIndex].Cells["EstadoInterno"].Value = "D";
                    dgvLibros.Rows[e.RowIndex].Cells["btnAcciones"].Value = "Prestar";
                    dgvLibros.Rows[e.RowIndex].Cells["imgEstado"].Value = Properties.Resources.disponible;
                }
            }
        }

    }
}
