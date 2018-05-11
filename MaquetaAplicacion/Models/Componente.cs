using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaAplicacion.Models
{
    public class Componente
    {
        //Campos
        private string id;
        private string nombre;
        private List<Elemento> elementos;

        //Constructor
        public Componente(string Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Elementos = new List<Elemento>();
        }

        //Propiedades
        public string Id
        {
            get => id;
            set => id = value;
        }
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public List<Elemento> Elementos
        {
            get => elementos;  
            set => elementos = value; 
        }
    }
}
