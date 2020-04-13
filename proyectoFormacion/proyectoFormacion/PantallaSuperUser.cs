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
    public partial class PantallaSuperUser : Form
    {
        private IEnumerable<User> usuarios;
        private UserController usuarioControl;

        public PantallaSuperUser()
        {
            InitializeComponent();
            this.usuarioControl = new UserController();
            
            //Obtenemos lista de usuarios de base de datos 
            this.usuarios = usuarioControl.ObtenerUsuarios();
            
            muestraUsuarios();
        }
        
        private bool hayAdmin()
        {
            bool hayAdmin = false;

            if(usuarios != null)
            {
                foreach (var usuario in usuarios)
                {
                    if(usuario.EsAdmin == true)
                    {
                        hayAdmin = true;
                    }
                }
            }

            return hayAdmin;
        }
        private void muestraUsuarios()
        {
            while (usuarios == null || usuarios.Count() < 3)
            {
                MessageBox.Show("Debe de haber un mínimo de 3 usuarios en el sistema siendo, al menos, 1 de ellos admin");
                AgregarUsuarios agregarUsuarios = new AgregarUsuarios();
                agregarUsuarios.ShowDialog();
            }
            while(!hayAdmin())
            {
                MessageBox.Show("Debe de haber al menos 1 admin");
                AgregarUsuarios agregarUsuarios = new AgregarUsuarios();
                agregarUsuarios.ShowDialog();
            }

            foreach(var usuario in usuarios)
            {
                listaUsuarios.Items.Add(usuario.Nombre);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarUsuarios agregarUsuarios = new AgregarUsuarios();
            agregarUsuarios.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Eliminar usuario: 
            for (int i = 0; i < listaUsuarios.CheckedItems.Count; i++) 
            {
                usuarioControl.BorrarUsuarioPorNombre(listaUsuarios.Items[i].ToString());
            }

            this.muestraUsuarios();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AgregarUsuarios agregarUsuarios = new AgregarUsuarios();
            agregarUsuarios.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
    }
}
