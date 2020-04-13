using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFormacion
{
    public interface IXml
    {
        /// <summary>
        /// Si no existe xml, lo crea; 
        /// de lo contrario, actualiza 
        /// los campos modificados.
        /// </summary>
        /// <returns></returns>
        /// <param name="usuario"></param>
        void CrearXml(User usuario, string path);

        /// <summary>
		/// Consulta si para un usuario 
        /// tiene el archivo xml de 
        /// configuración creado
		/// </summary>
		/// <returns></returns>
        /// <param name="nombre"></param>
        bool TieneXml(User nombre);
        
        /// <summary>
        /// Muestra el xml del usuario
        /// con el formato propio "xml"
        /// </summary>
        /// <returns></returns>
        /// <param name="nombre"></param>
        void VisualizaXml(string nombre);
    }
}
