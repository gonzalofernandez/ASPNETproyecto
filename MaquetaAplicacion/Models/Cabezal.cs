using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaquetaAplicacion.Models
{
    public class Cabezal
    {
        //Campos
        private string ubicacion;
        private string modControl;
        private string detectores;
        private string modInter;
        private string elecVal;
        private string conex;

        //Constructor
        public Cabezal(
            string Ubicacion, 
            string ModControl, 
            string Detectores, 
            string ModInter, 
            string ElecVal, 
            string Conex)
        {
            this.Ubicacion = Ubicacion;
            this.ModControl = ModControl;
            this.Detectores = Detectores;
            this.ModInter = ModInter;
            this.ElecVal = ElecVal;
            this.Conex = Conex;
        }

        //Propiedades
        public string Ubicacion
        {
            get => ubicacion;
            set => ubicacion = value;
        }
        public string ModControl
        {
            get => modControl;
            set => modControl = value;
        }
        public string Detectores
        {
            get => detectores;
            set => detectores = value;
        }
        public string ModInter
        {
            get => modInter;
            set => modInter = value;
        }
        public string ElecVal
        {
            get => elecVal;
            set => elecVal = value;
        }
        public string Conex
        {
            get => conex;
            set => conex = value;
        }

    }
}