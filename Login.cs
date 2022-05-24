using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciónform
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtcontraseña.Clear();
            txtconfirmarcontra.Clear();
            txtUsernew.Clear();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == txtconfirmarcontra.Text)
            {
                if (UsuarioReg.CrearCuentas(txtUsernew.Text, txtcontraseña.Text) > 0)
                {
                    MessageBox.Show("Cuenta creada correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la cuenta");
                }
            }
            Limpiar();
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            if (UsuarioReg.Autentificacion(txtUsuario.Text, txtPass.Text) > 0)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error, Usuario o contraseña incorrectos.");
            }
        }
    }
}
