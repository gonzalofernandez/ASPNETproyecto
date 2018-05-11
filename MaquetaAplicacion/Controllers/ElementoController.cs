using MaquetaAplicacion.Classes;
using MaquetaAplicacion.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MaquetaAplicacion.Controllers
{
    public class ElementoController : Controller
    {
        //Declaramos la colección que representa las filas de la consulta/procedimiento de la BBDD
        private List<DataRow> filas = new List<DataRow>();

        // GET: /COMPONENTE/{compId}/ELEMENTO/{elemId}

        public PartialViewResult Show(string compName, string elemId)
        {
            //Leemos datos de la sesión
            List<Componente> componentes = (List<Componente>)(Session["componentes"]);
            List<Elemento> elementos = (List<Elemento>)(Session["elementos"]);
            
            //Identificamos el componente seleccionado
            //Componente componente = componentes.Find(x => x.Id.Equals(compName.ToLower().Substring(0, 3)));

            //Creamos un objeto de la clase Connection
            //El objeto almacena los resultados de la ejecución del procedimiento
            Connection con = new Connection();
            
            //Creamos el objeto con la cadena de la consulta/procedimiento almacenado
            string consulta = "SELECT [FamiliaID], [NombreFamilia], [FamiliaSuperiorID]" + 
                "FROM[ITDEV].[dbo].[LGE_Familias]" + 
                "WHERE DepartamentoPropietario = 'ofe' AND FamiliaID > 1255";
            //SqlCommand procedimiento = new SqlCommand("[ADM].[SP_APCs_Select]");
            //Definimos los parámetros necesarios para el procedimiento
            //procedimiento.Parameters.AddWithValue("@APCID", 2);
            //procedimiento.Parameters.AddWithValue("@APC", "'%'");
            
            //Ejecuta la consulta/procedimiento
            con.ExecuteQueryString(consulta);
            //con.ExecuteCommand(procedimiento);

            //Guardamos el resultado de la consulta 
            DataTable resultados = con.GetResultados();
            //Asocionamos un objeto DataTable a una colección para la vista
            foreach (DataRow fila in resultados.Rows)
            {
                filas.Add(fila);
            }

            //Connection.GetColumnValueFromDataRow(resultados, 2, "");

            //Identificamos la familia seleccionada 
            //Hay que tener en cuenta la propiedad que enlaza el componente con sus elementos(x.Id/x.App) 
            Elemento elemento = elementos.Find(x => x.Id.Equals(elemId));
            //Datos para la vista
            ViewBag.Elementos = elementos;
            ViewBag.Componentes = componentes;
            ViewBag.Elemento = elemento;
            ViewBag.Resultados = filas;
            //Devolvemos la vista parcial correspondiente
            return PartialView("_Form", elemento);
        }   
    }
}
