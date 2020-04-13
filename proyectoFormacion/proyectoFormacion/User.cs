using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFormacion
{
    [Table("user")]
    public class User
    {
        private Guid uuid;
        private string nombre = null;
        private int fondoColor = 0; 
        private float altoPantalla = 0; 
        private float anchoPantalla = 0;
        private int letraColor = 0;  
        private double espacioLibreDisco = -1;
        private string pass = null; 
        private bool esAdmin = false;
        private DateTime fecha;
        private bool xmlGenerado = false;

        public User(string nombre, string pass, bool esAdmin) 
        {
            this.nombre = nombre;
            this.pass = pass;
            this.esAdmin = esAdmin;
            this.uuid = Guid.NewGuid();
            this.fecha = DateTime.Today; 
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int FondoColor { get => fondoColor; set => fondoColor = value; }
        public float AltoPantalla { get => altoPantalla; set => altoPantalla = value; }
        public float AnchoPantalla { get => anchoPantalla; set => anchoPantalla = value; }
        public int LetraColor { get => letraColor; set => letraColor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double EspacioLibreDisco { get => espacioLibreDisco; set => espacioLibreDisco = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool EsAdmin { get => esAdmin; set => esAdmin = value; }
        public bool XmlGenerado { get => xmlGenerado; set => xmlGenerado = value; }

        [Key]
        public Guid Uuid { get => uuid; set => uuid = value; }
        
        public bool haveXml()
        {
            //Llamada a base de datos para saber si tiene xml;
            return false; 
        }
    }
}
