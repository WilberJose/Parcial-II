using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class Principal : Form
    {
        private object txtNombre;

        public Principal()
        {
            InitializeComponent();

            txtNombre = Sesion.nombre;
        }
    }
}
