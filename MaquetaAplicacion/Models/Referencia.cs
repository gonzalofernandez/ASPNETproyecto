using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaAplicacion.Models
{
    public class Referencia
    {
        //Campos
        private string nombre;
        private string descripcion;

        //Constructor
        public Referencia(string Nombre, string Descripcion)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }

        //Propiedades
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public string Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }
    }
}