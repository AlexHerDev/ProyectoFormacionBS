using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFormacion
{
    public partial class PantallaNormalUser : Form
    {
        private User usuario;
        private XmlController xml;
        private string nombreTrack = "bensound-thejazzpiano.wav";
        SoundPlayer sonido;
        private double espacioLibreDisco;
      
        public PantallaNormalUser(User usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.xml = new XmlController();
            this.sonido = new SoundPlayer(ObtenerFullPath(nombreTrack));
            RellenaDatos(); 
        }

        private string ObtenerFullPath(string nombre)
        {
            return Path.GetFullPath(nombre);
        }

        private void CambiaColorLetra(int rgb)
        {
            Color color = Color.FromArgb(rgb);

            this.ForeColor = color;
            guardar.ForeColor = color;
            visualizarXml.ForeColor = color;
            calcular.ForeColor = color;
            button6.ForeColor = color;
            button7.ForeColor = color;
            numericUpDown1.ForeColor = color;
            numericUpDown2.ForeColor = color;
            textBox1.ForeColor = color;
            dateTimePicker1.CalendarTitleForeColor = color;
        }

        private void CambiaColorFondo(int rgb)
        {
            Color color = Color.FromArgb(rgb);

            this.BackColor = color;   
        }

        private void RellenaDatos()
        {
            label2.Text = usuario.Nombre;

            if (!xml.TieneXml(usuario))
            {
                MessageBox.Show("No tiene archivo xml de configuración. Por favor rellene uno con los datos deseados");

                numericUpDown1.Value = this.Width;
                numericUpDown2.Value = this.Height;
                textBox1.Text = "No calculado";

            }
            else
            {
                numericUpDown1.Value = (decimal)(Math.Round(usuario.AnchoPantalla, 2));
                numericUpDown2.Value = (decimal)(Math.Round(usuario.AltoPantalla, 2));
                CambiaColorFondo(usuario.FondoColor);
                CambiaColorLetra(usuario.LetraColor);
                textBox1.Text = Math.Round(usuario.EspacioLibreDisco, 2).ToString() + " GB";
                dateTimePicker1.Value = usuario.Fecha;
            }
        }
     
        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                CambiaColorFondo(colorDlg.Color.ToArgb());    
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                CambiaColorLetra(colorDlg.Color.ToArgb());
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            sonido.Stop();
        }

        private void play_Click(object sender, EventArgs e)
        {
            sonido.Play();
        }

        //Por ahora, lo calcula del disco C por defecto 
        private void calcular_Click(object sender, EventArgs e)
        {
            const double BytesInGB = 1073741824;

            DriveInfo dDrive = new DriveInfo("C");

            if (dDrive.IsReady)
            {
                this.espacioLibreDisco = Math.Round(dDrive.AvailableFreeSpace / BytesInGB, 2);

                textBox1.Text = espacioLibreDisco.ToString() + " GB";
            }
        }

        private void PantallaNormalUser_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void visualizarXml_Click(object sender, EventArgs e)
        {
            if(!usuario.XmlGenerado)
            {
                MessageBox.Show("No tiene archivo xml de configuración.");
            } else
            {
                xml.VisualizaXml(usuario.Nombre);
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        { 
            usuario.XmlGenerado = true;
            usuario.FondoColor = this.BackColor.ToArgb(); 
            usuario.LetraColor = this.ForeColor.ToArgb();
            usuario.AltoPantalla = (float)numericUpDown2.Value;
            usuario.AnchoPantalla = (float)numericUpDown1.Value;
            usuario.EspacioLibreDisco = this.espacioLibreDisco;
            usuario.Fecha = dateTimePicker1.Value;

            //Por si se prefiere crear automáticamente en una ruta
            //preestablecida
            //string pathActual = Environment.CurrentDirectory;

            //Generar xml, el usuario elegirá la ruta 
            xml.CrearXml(usuario);
           
            //Persistir cambios en base de datos
            UserController userControl = new UserController();
            userControl.ActualizarUsuario(usuario);
        }
    }
}
