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
   public class ProgramaControlador
    {
        //Declara y desarrollar los metodos

        public List<ProgramaDTO> ListarProgramas(String Conexion)
        {
            //lista fisica
            List<ProgramaDTO> lstprogramas = new List<ProgramaDTO>();
            string SQLCommand = "sp_programa";
            DataSet dsPrograma = null;

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "_fac_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "listar_full");

                //consulta del motor para en memoria al programa
                dsPrograma = db.ExecuteDataSet(dbCommand);

                //preguntar si tiene datos
                if (dsPrograma != null)
                {
                    if (dsPrograma.Tables[0].Rows.Count > 0)
                    {
                        //un ciclo para recorrer los eementos sin limite
                        foreach (DataRow oRow in dsPrograma.Tables[0].Rows)
                        {
                            ProgramaDTO objPrograma = new ProgramaDTO();
                            objPrograma.pro_id = Convert.ToInt32(oRow["pro_id"]);
                            objPrograma.pro_nom = oRow["pro_nom"].ToString();
                            objPrograma.fac_id = Convert.ToInt32(oRow["fac_id"]);
                            objPrograma.fac_nom = oRow["fac_nom"].ToString();

                            //Se añade el objeto dependencia a la lista
                            lstprogramas.Add(objPrograma);

                        }
                    }
                    else
                    {
                        lstprogramas = null;
                    }
                }
                else
                {
                    lstprogramas = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsPrograma.Dispose();
            }

            return lstprogramas;
        }

        public void InsertarPrograma(String NombrePrograma,Int32 IdFacultad, String Conexion)
        {
            string SQLCommand = "sp_programa";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, NombrePrograma);
                db.AddInParameter(dbCommand, "_fac_id", DbType.Int32, IdFacultad);
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

        public void EliminarPrograma(Int32 procodigo, String Conexion)
        {
            string SQLCommand = "sp_programa";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, procodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "_fac_id", DbType.Int32, null);
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

        public void ActualizarPrograma(Int32 fapcodigo, String fapnombre,Int32 IdFacultad,String Conexion)
        {
            string SQLCommand = "sp_programa";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, fapcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, fapnombre);
                db.AddInParameter(dbCommand, "_fac_id", DbType.Int32, IdFacultad);
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


        public ProgramaDTO ConsultarPrograma(Int32 procodigo, String Conexion)
        {
            ProgramaDTO objPrograma = new ProgramaDTO();
            string SQLCommand = "sp_programa";
            DataSet dsPrograma = null;


            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, procodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "_fac_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "consultar");

                dsPrograma = db.ExecuteDataSet(dbCommand);
                //Es que el resultado de la consulta sql en memoria desde el motor, 
                //se almacena directamente en el dataset en el programa.

                if (dsPrograma != null)
                {
                    if (dsPrograma.Tables[0].Rows.Count > 0)
                    {
                        //foreach es un ciclo para recorrer elementos sin un limite definido

                        foreach (DataRow oRow in dsPrograma.Tables[0].Rows)
                        {

                            objPrograma.pro_id = Convert.ToInt32(oRow["pro_id"]);
                            objPrograma.pro_nom = oRow["pro_nom"].ToString();
                            objPrograma.fac_id = Convert.ToInt32(oRow["fac_id"]);
                            
                            //Se añade el objeto dependencia a la lista


                        }
                    }
                    else
                    {

                        objPrograma = null;
                    }
                }
                else
                {

                    objPrograma = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsPrograma.Dispose();
            }
            return objPrograma;

        }
    }
}
