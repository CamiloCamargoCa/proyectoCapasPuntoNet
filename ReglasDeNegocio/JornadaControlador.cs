using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class JornadaControlador
    {
        //Declara y desarrollar los metodos

        public List<JornadaDTO> ListarJornadas(String Conexion)
        {
            //lista fisica
            List<JornadaDTO> lstjornadas = new List<JornadaDTO>();
            string SQLCommand = "sp_jornada";
            DataSet dsJornada = null;

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "listar");

                //consulta del motor para en memoria al programa
                dsJornada = db.ExecuteDataSet(dbCommand);

                //preguntar si tiene datos
                if (dsJornada != null)
                {
                    if (dsJornada.Tables[0].Rows.Count > 0)
                    {
                        //un ciclo para recorrer los eementos sin limite
                        foreach (DataRow oRow in dsJornada.Tables[0].Rows)
                        {
                            JornadaDTO objJornada = new JornadaDTO();
                            objJornada.jor_id = Convert.ToInt32(oRow["jor_id"]);
                            objJornada.jor_nom = oRow["jor_nom"].ToString();

                            //Se añade el objeto dependencia a la lista
                            lstjornadas.Add(objJornada);

                        }
                    }
                    else
                    {
                        lstjornadas = null;
                    }
                }
                else
                {
                    lstjornadas = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsJornada.Dispose();
            }

            return lstjornadas;
        }

        public void InsertarJornada(String NombreJornada, String Conexion)
        {
            string SQLCommand = "sp_jornada";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, NombreJornada);
                db.AddInParameter(dbCommand, "accion", DbType.String, "nuevo");
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public void ELiminarJornada(Int32 jorcodigo, String Conexion)
        {
            string SQLCommand = "sp_jornada";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, jorcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "eliminar");
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public void ActualizarJornada(Int32 jorcodigo, String jornombre, String Conexion)
        {
            string SQLCommand = "sp_jornada";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, jorcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, jornombre);
                db.AddInParameter(dbCommand, "accion", DbType.String, "editar");

                db.ExecuteNonQuery(dbCommand);

            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }


        public JornadaDTO ConsultarJornada(Int32 jorcodigo, String Conexion)
        {
            JornadaDTO objJornada = new JornadaDTO();
            string SQLCommand = "sp_jornada";
            DataSet dsJornada = null;


            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, jorcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "consultar");

                dsJornada = db.ExecuteDataSet(dbCommand);
                //Es que el resultado de la consulta sql en memoria desde el motor, 
                //se almacena directamente en el dataset en el Jornada.

                if (dsJornada != null)
                {
                    if (dsJornada.Tables[0].Rows.Count > 0)
                    {
                        //foreach es un ciclo para recorrer elementos sin un limite definido

                        foreach (DataRow oRow in dsJornada.Tables[0].Rows)
                        {

                            objJornada.jor_id = Convert.ToInt32(oRow["jor_id"]);
                            objJornada.jor_nom = oRow["jor_nom"].ToString();
                            //Se añade el objeto dependencia a la lista
                        }
                    }
                    else
                    {

                        objJornada = null;
                    }
                }
                else
                {

                    objJornada = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsJornada.Dispose();
            }
            return objJornada;

        }
    
    }
}
