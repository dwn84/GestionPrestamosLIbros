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
    public partial class frmPrestar : Form
    {
        public string nombreUsuario;

        public frmPrestar()
        {
            InitializeComponent();
            nombreUsuario = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            nombreUsuario = txtUsuario.Text;
            this.Close();
        }
    }
}
