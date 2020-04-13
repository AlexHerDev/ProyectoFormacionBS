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
    public partial class AgregarUsuarios : Form
    {
        private UserController usuarioControl;
        private Encriptador encp;
        public AgregarUsuarios()
        {
            InitializeComponent();
            this.usuarioControl = new UserController();
            this.encp = new Encriptador();
        }
        public void limpiaEntradas()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Es obligatorio rellenar todos los campos");
                limpiaEntradas();
                textBox1.Focus();
            }
            else
            {
                string nombre = textBox1.Text;
                string pass = encp.encripta(textBox2.Text);
                bool admin = checkBox1.Checked;

                //Se crea el usuario 
                User usuario = new User(nombre, pass, admin);
                
                //Se persiste el usuario en base de datos 
                usuarioControl.Crear(usuario);

                PantallaSuperUser pantallaSuperUser = new PantallaSuperUser();
                pantallaSuperUser.ShowDialog();
            }
        }
    }
}
