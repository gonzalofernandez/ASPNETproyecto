using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaAplicacion.Models
{
    public class Elemento
    {
        //Campos
        private string id;
        private string nombre;
        private string tipo;
        private string dnSup;
        private string dnInf;
        private string tipoActuador;
        private string posicion;
        private string actuador;
        private string opciones;
        private string matJunt;
        private string acabado;
        private string conHous;
        private string balCle;
        private string conHousFon;
        private string opEsp;

        //Constructor
        public Elemento(
            string Id,
            string Nombre,
            string Tipo, 
            string DnSup, 
            string DnInf, 
            string TipoActuador, 
            string Posicion, 
            string Actuador, 
            string Opciones, 
            string MatJunt, 
            string Acabado, 
            string ConHous, 
            string BalCle, 
            string ConHousFon, 
            string OpEsp)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.DnSup = DnSup;
            this.DnInf = DnInf;
            this.TipoActuador = TipoActuador;
            this.Posicion = Posicion;
            this.Actuador = Actuador;
            this.Opciones = Opciones;
            this.MatJunt = MatJunt;
            this.Acabado = Acabado;
            this.ConHous = ConHous;
            this.BalCle = BalCle;
            this.ConHousFon = ConHousFon;
            this.OpEsp = OpEsp;
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
        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }
        public string DnSup
        {
            get => dnSup;
            set => dnSup = value;
        }
        public string DnInf
        {
            get => dnInf;
            set => dnInf = value;
        }
        public string TipoActuador
        {
            get => tipoActuador;
            set => tipoActuador = value;
        }
        public string Posicion
        {
            get => posicion;
            set => posicion = value;
        }
        public string Actuador
        {
            get => actuador;
            set => actuador = value;
        }
        public string Opciones
        {
            get => opciones;
            set => opciones = value;
        }
        public string MatJunt
        {
            get => matJunt;
            set => matJunt = value;
        }
        public string Acabado
        {
            get => acabado;
            set => acabado = value;
        }
        public string ConHous
        {
            get => conHous;
            set => conHous = value;
        }
        public string BalCle
        {
            get => balCle;
            set => balCle = value;
        }
        public string ConHousFon
        {
            get => conHousFon;
            set => conHousFon = value;
        }
        public string OpEsp
        {
            get => opEsp;
            set => opEsp = value;
        }
        
    }
}
