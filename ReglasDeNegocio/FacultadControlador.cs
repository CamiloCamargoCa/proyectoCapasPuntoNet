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
    public class FacultadControlador
    {
        //Declara y desarrollar los metodos

        public List<FacultadDTO> ListarFacultades(String Conexion)
        {
            //lista fisica
            List<FacultadDTO> lstFacultades = new List<FacultadDTO>();
            string SQLCommand = "sp_Facultad";
            DataSet dsFacultad = null;

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "listar");

                //consulta del motor para en memoria al Facultad
                dsFacultad = db.ExecuteDataSet(dbCommand);

                //preguntar si tiene datos
                if (dsFacultad != null)
                {
                    if (dsFacultad.Tables[0].Rows.Count > 0)
                    {
                        //un ciclo para recorrer los eementos sin limite
                        foreach (DataRow oRow in dsFacultad.Tables[0].Rows)
                        {
                            FacultadDTO objFacultad = new FacultadDTO();
                            objFacultad.fac_id = Convert.ToInt32(oRow["fac_id"]);
                            objFacultad.fac_nom = oRow["fac_nom"].ToString();

                            //Se añade el objeto dependencia a la lista
                            lstFacultades.Add(objFacultad);

                        }
                    }
                    else
                    {
                        lstFacultades = null;
                    }
                }
                else
                {
                    lstFacultades = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsFacultad.Dispose();
            }

            return lstFacultades;
        }

        public void InsertarFacultad(String NombreFacultad, String Conexion)
        {
            string SQLCommand = "sp_Facultad";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, NombreFacultad);
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

        public void EliminarFacultad(Int32 procodigo, String Conexion)
        {
            string SQLCommand = "sp_Facultad";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, procodigo);
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

        public void ActualizarFacultad(Int32 fapcodigo, String fapnombre, String Conexion)
        {
            string SQLCommand = "sp_Facultad";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, fapcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, fapnombre);
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


        public FacultadDTO ConsultarFacultad(Int32 procodigo, String Conexion)
        {
            FacultadDTO objFacultad = new FacultadDTO();
            string SQLCommand = "sp_Facultad";
            DataSet dsFacultad = null;


            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, procodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "consultar");

                dsFacultad = db.ExecuteDataSet(dbCommand);
                //Es que el resultado de la consulta sql en memoria desde el motor, 
                //se almacena directamente en el dataset en el Facultad.

                if (dsFacultad != null)
                {
                    if (dsFacultad.Tables[0].Rows.Count > 0)
                    {
                        //foreach es un ciclo para recorrer elementos sin un limite definido

                        foreach (DataRow oRow in dsFacultad.Tables[0].Rows)
                        {

                            objFacultad.fac_id = Convert.ToInt32(oRow["fac_id"]);
                            objFacultad.fac_nom = oRow["fac_nom"].ToString();

                            //Se añade el objeto dependencia a la lista


                        }
                    }
                    else
                    {

                        objFacultad = null;
                    }
                }
                else
                {

                    objFacultad = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsFacultad.Dispose();
            }
            return objFacultad;

        }
    }
}
