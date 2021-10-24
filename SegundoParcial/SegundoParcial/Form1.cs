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
    public partial class fmrRegistro : Form
    {
        public fmrRegistro()
        {
            InitializeComponent();
        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Firstname = txtfirstname.Text;
            usuario.Lastname = txtlastname.Text;
            usuario.Email = txtemail.Text;
            usuario.Username = txtusername.Text;
            usuario.Password = txtpassword.Text;
            usuario.Confirmpassword = txtconfirmpassword.Text;

            try{


            Control control = new Control();
            string respuesta = control.ControlRegistro(usuario);

            if(respuesta.Length > 0)
            {
                MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else 
            {
                    MessageBox.Show("Usuario registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}