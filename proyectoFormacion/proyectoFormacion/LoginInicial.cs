using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFormacion
{
    public partial class LoginInicial : Form
    { 
        private string superUser = "admin";
        private string pass = "0";
        private Encriptador encp;
     
        public void limpiaEntradas()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private bool esAdmin()
        {
            bool existe = true;

            if (textBox1.Text != superUser)
                existe = false;

            return existe;
        }

        private bool compruebaPass(int rango)
        {
            bool valida = true;

            if (rango == 0)
            {
                if (textBox2.Text != pass)
                    valida = false;
            } else
            {

            }

            return valida;
        }

        public LoginInicial()
        {
            InitializeComponent();
            this.encp = new Encriptador();
        }

        private void muestraMensajeCombinacionIncorrecta()
        {
            MessageBox.Show("Combinación de usuario/contraseña incorrecta");
            limpiaEntradas();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(esAdmin())
            {
                if(compruebaPass(0))
                {
                    limpiaEntradas();
                    PantallaSuperUser pantallaSuperUser = new PantallaSuperUser();
                    pantallaSuperUser.ShowDialog();
                } else
                {
                    muestraMensajeCombinacionIncorrecta();
                }
            } else
            {
                UserController controlUsuario = new UserController();
                User usuario = controlUsuario.ObtenerUsuarioPorNombrePass(textBox1.Text, encp.encripta(textBox2.Text));
                
                if (usuario != null)
                {
                    limpiaEntradas();
                    //Le paso el usuario a la pantalla de usuario 
                    PantallaNormalUser pantallaNormalUser = new PantallaNormalUser(usuario);
                    pantallaNormalUser.ShowDialog();
                } else
                {
                    muestraMensajeCombinacionIncorrecta();
                }           
            } 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
