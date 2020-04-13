using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace proyectoFormacion
{
    class XmlController : IXml
    {
        private string PideRuta()
        {
            string nombreCarpeta = null; 
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                nombreCarpeta = folderBrowserDialog1.SelectedPath;
            }

            return nombreCarpeta;  
        }
        
        private string ConstruyeNombreArchivo(string nombre)
        {
            return nombre + "Conf.xml";
        }

        public void CrearXml(User usuario, string path = null)
        {
            string nombreXml = ConstruyeNombreArchivo(usuario.Nombre);

            if(path == null)
            {
                path = PideRuta();
            }
             
            try
            {
                XmlTextWriter textWriter = new XmlTextWriter(path + "/" + nombreXml, null);

                textWriter.Formatting = Formatting.Indented;

                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("Configuracion");

                textWriter.WriteElementString("UUID", usuario.Uuid.ToString());
                textWriter.WriteElementString("Nombre", usuario.Nombre);
                textWriter.WriteElementString("ColorFondo", usuario.FondoColor.ToString());
                textWriter.WriteElementString("ColorLetra", usuario.LetraColor.ToString());

                textWriter.WriteStartElement("DimensionesPantalla");
                textWriter.WriteElementString("Alto", usuario.AltoPantalla.ToString());
                textWriter.WriteElementString("Ancho", usuario.AnchoPantalla.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteElementString("Fecha", usuario.Fecha.ToString());
                textWriter.WriteElementString("EspacioLibreDisco", usuario.EspacioLibreDisco.ToString());

                textWriter.WriteEndElement();
                textWriter.WriteEndDocument();
                textWriter.Close();

            } catch (XmlException e)
            {
                MessageBox.Show(e.ToString());
            }
            
            MessageBox.Show("Archivo XML creado correctamente!");
        }

        public bool TieneXml(User usuario)
        {
            return usuario.XmlGenerado; 
        }

        public void VisualizaXml(string nombre)
        { 
            string path = PideRuta();
            string nombreXml = ConstruyeNombreArchivo(nombre);

            try
            {
                XmlTextReader textReader = new XmlTextReader(path + "/" + nombreXml);
                textReader.Read();

                //Voy a mostrar el contenido por consola para verificar que funciona 
                //correctamente, por eso he llamado al método visualiza.  
                //De igual forma se podría usar para obtener los atributos y crear 
                //un usuario, o la configuración de este, en vez de hacerlo mediante 
                //base de datos.     
                Console.WriteLine("");
                Console.WriteLine("===================");
                Console.WriteLine("Contenido XML: ");
                Console.WriteLine("===================");
                while (textReader.Read())
                {  
                    textReader.MoveToElement();
                   
                    if (textReader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (textReader.Name.ToString())
                        {
                            case "UUID":
                                Console.WriteLine("UUID : " + textReader.ReadString());
                                break;
                            case "Nombre":
                                Console.WriteLine("Nombre : " + textReader.ReadString());
                                break;
                            case "ColorFondo":
                                Console.WriteLine("Color de fondo : " + textReader.ReadString());
                                break;
                            case "ColorLetra":
                                Console.WriteLine("Color de letra : " + textReader.ReadString());
                                break;
                            case "Alto":
                                Console.WriteLine("Alto pantalla : " + textReader.ReadString());
                                break;
                            case "Ancho":
                                Console.WriteLine("Ancho pantalla : " + textReader.ReadString());
                                break;
                            case "Fecha":
                                Console.WriteLine("Fecha : " + textReader.ReadString());
                                break;
                            case "EspacioLibreDisco":
                                Console.WriteLine("Espacio libro en disco duro : " + textReader.ReadString());
                                break;
                        }
                    }
                    Console.WriteLine("");
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
