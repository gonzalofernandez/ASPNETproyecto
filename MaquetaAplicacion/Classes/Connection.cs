using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MaquetaAplicacion.Classes
{
    public class Connection
    {
        //Propiedades
        private static SqlConnection sqlConnection;
        private static string serverName = "";
        private static string databaseName = "ITDEV";
        private SqlCommand storedProcedure;
        private DataSet ReturnDataSet;

        //Constructor
        public Connection()
        {
        }

        //Método que crea la conexión
        private static void CreateDefaultConnection()
        {
            //Comprobamos si hay conexión
            if (sqlConnection == null)
            {
                //
                RegistryKey SubKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\TESDB");
                //
                if (SubKey != null)
                {
                    //Identificamos el nombre del servidor y de la BBDD
                    serverName = SubKey.GetValue("Servidor").ToString();
                    databaseName = SubKey.GetValue("BaseDeDatos").ToString();
                }
                try
                {
                    //Obtenemos los datos del usuario conectado
                    string domainName = Environment.UserDomainName;
                    //Inicializamos la variable de los datos de la conexión
                    string sConnectionString = "";
                    //Asignamos los datos de la conexión
                    sConnectionString = "Data Source =" + serverName + "; Initial Catalog =" + databaseName + "; Integrated Security=SSPI;  Application Name=" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + ";";
                    //Creamos el objeto conexión
                    sqlConnection = new SqlConnection(sConnectionString);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Método que abre la conexión
        public static void OpenConnection()
        {
            //Comprobamos si hay conexión
            if (sqlConnection == null)
            {
                //Creamos la conexión
                CreateDefaultConnection();
            }
            try
            {
                //Comprobamos si la conexión ya está cerrada
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    //Abrimos la conexión
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Método que cierra la conexión
        public static void CloseConnection()
        {
            //Comprobamos que no esté cerrada la conexión
            if (sqlConnection != null)
            {
                //Cerramos la conexión
                sqlConnection.Close();
            }
        }

        //Para ejecutar consultas contra la BBDD
        public void ExecuteQueryString(string QueryString)
        {
            try
            {
                //Es para generar Logs
                //TesClasses.TesLogHandler.AddLog("dbConnector: " + QueryString, "SQL query", "TesConnector", 5);
                //Abrimos la conexión
                OpenConnection();
                //Guardamos en variable
                storedProcedure = new SqlCommand(QueryString);
                //Definimos la conexión
                storedProcedure.Connection = sqlConnection;
                //Definimos el tipo de cadena a interpretar
                storedProcedure.CommandType = CommandType.Text;
                //Creamos un objeto DataSet que recoge los valores devueltos por el procedimeiento
                ReturnDataSet = new DataSet("ReturnDataSet");
                //Asociamos los comandos a interpretar y la conexión
                SqlDataAdapter TesSqlDataAdapter = new SqlDataAdapter((storedProcedure));
                //Rellenamos la tabla con los datos recogidos con la ejecución del procedimeinto
                TesSqlDataAdapter.Fill(ReturnDataSet, "ReturnDataSet");
                //Liberamos el acceso a las consultas
                storedProcedure.Dispose();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //Para ejecutar stored procedures de la BBDD
        public void ExecuteCommand(SqlCommand StoredProcedure)
        {
            try
            {
                //Es para generar Logs
                //TesClasses.TesLogHandler.AddLog("dbConnector: " + StoredProcedure.CommandText, "SQL Command", "TesConnector", 0);
                //Abrimos la conexión
                OpenConnection();
                //Guardamos el procedimiento almacenado en una variable local
                storedProcedure = StoredProcedure;
                //Definimos la propiedad conexión para el procedimiento almacenado
                storedProcedure.Connection = sqlConnection;
                //Definimos el tipo de cadena a interpretar
                storedProcedure.CommandType = CommandType.StoredProcedure;
                //Creamos un objeto DataSet que recoge los valores devueltos por el procedimeiento
                ReturnDataSet = new DataSet("ReturnDataSet");
                //Asociamos los comandos a interpretar y la conexión
                SqlDataAdapter TesSqlDataAdapter = new SqlDataAdapter((storedProcedure));
                //Rellenamos la tabla con los datos recogidos con la ejecución del procedimeinto
                TesSqlDataAdapter.Fill(ReturnDataSet, "ReturnDataSet");
                //Liberamos el acceso al procedimiento tras las consultas
                storedProcedure.Dispose();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //
        public static object GetColumnValueFromDataRow(DataRow dr, String ColumnName)
        {
            DataTable dtt = dr.Table;
            Int32 RowInd = dtt.Rows.IndexOf(dr);
            return GetColumnValueFromDataRow(dtt, RowInd, ColumnName);
        }

        //
        public static object GetColumnValueFromDataRow(DataTable dtt, Int32 RowInd, String ColumnName)
        {
            Int32 ind = dtt.Columns.IndexOf(ColumnName);
            return (ind > -1) ? dtt.Rows[RowInd].ItemArray.GetValue(ind) : null;
        }

        //Método para recuperar la tabla que contiene las filas recuperadas tras el acceso a la BBDD
        public DataTable GetResultados()
        {
            return ReturnDataSet.Tables[0];
        }
    }
}
