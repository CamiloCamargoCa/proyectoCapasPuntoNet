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
    public class EstudianteControlador
    {
        //Declara y desarrollar los metodos

        public List<EstudianteDTO> ListarEstudiantes(String Conexion)
        {
            //lista fisica
            List<EstudianteDTO> lstestudiantes = new List<EstudianteDTO>();
            string SQLCommand = "sp_estudiante";
            DataSet dsEstudiante = null;

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "_dir", DbType.String, null);
                db.AddInParameter(dbCommand, "_tel", DbType.String, null);
                db.AddInParameter(dbCommand, "_jor_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_pro_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "consolidar");

                //consulta del motor para en memoria al programa
                dsEstudiante = db.ExecuteDataSet(dbCommand);

                //preguntar si tiene datos
                if (dsEstudiante != null)
                {
                    if (dsEstudiante.Tables[0].Rows.Count > 0)
                    {
                        //un ciclo para recorrer los eementos sin limite
                        foreach (DataRow oRow in dsEstudiante.Tables[0].Rows)
                        {
                            EstudianteDTO objEstudiante = new EstudianteDTO();
                            objEstudiante.est_id = Convert.ToInt32(oRow["est_id"]);
                            objEstudiante.est_nom = oRow["est_nom"].ToString();
                            objEstudiante.est_dir = oRow["est_dir"].ToString();
                            objEstudiante.est_tel = oRow["est_tel"].ToString();
                            objEstudiante.jor_id = Convert.ToInt32(oRow["jor_id"]);
                            objEstudiante.jor_nom = oRow["jor_nom"].ToString();
                            objEstudiante.pro_id = Convert.ToInt32(oRow["pro_id"]);
                            objEstudiante.pro_nom = oRow["pro_nom"].ToString();

                            //Se añade el objeto dependencia a la lista
                            lstestudiantes.Add(objEstudiante);

                        }
                    }
                    else{
                        lstestudiantes = null;
                    }
                }
                else
                {
                    lstestudiantes = null;
                }
            }
            catch(Exception oEx){
                throw oEx;
            }
            finally{
                dsEstudiante.Dispose();
            }

            return lstestudiantes;
        }

        public void InsertarEstudiante(String NombreEstudiante, String DireccionEstudiante, String TelefonoEstudiante, Int32 IdJornada, Int32 IdPrograma, String Conexion)
        {
            string SQLCommand = "sp_estudiante";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_nom", DbType.String, NombreEstudiante);
                db.AddInParameter(dbCommand, "_dir", DbType.String, DireccionEstudiante);
                db.AddInParameter(dbCommand, "_tel", DbType.String, TelefonoEstudiante);
                db.AddInParameter(dbCommand, "_jor_id", DbType.Int32, IdJornada);
                db.AddInParameter(dbCommand, "_pro_id", DbType.Int32, IdPrograma);
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

        public void EliminarEstudiante(Int32 estcodigo, String Conexion)
        {
            string SQLCommand = "sp_estudiante";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, estcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "_dir", DbType.String, null);
                db.AddInParameter(dbCommand, "_tel", DbType.String, null);
                db.AddInParameter(dbCommand, "_jor_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_pro_id", DbType.Int32, null);
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

        public void ActualizarEstudiante(Int32 estcodigo, String NombreEstudiante, String DireccionEstudiante, String TelefonoEstudiante, Int32 IdJornada, Int32 IdPrograma, String Conexion)
        {
            string SQLCommand = "sp_estudiante";

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, estcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, NombreEstudiante);
                db.AddInParameter(dbCommand, "_dir", DbType.String, DireccionEstudiante);
                db.AddInParameter(dbCommand, "_tel", DbType.String, TelefonoEstudiante);
                db.AddInParameter(dbCommand, "_jor_id", DbType.Int32, IdJornada);
                db.AddInParameter(dbCommand, "_pro_id", DbType.Int32, IdPrograma);
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


        public EstudianteDTO ConsultarEstudiante(Int32 estcodigo, String Conexion)
        {
            EstudianteDTO objEstudiante = new EstudianteDTO();
            string SQLCommand = "sp_Estudiante";
            DataSet dsEstudiante = null;


            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "_id", DbType.Int32, estcodigo);
                db.AddInParameter(dbCommand, "_nom", DbType.String, null);
                db.AddInParameter(dbCommand, "_dir", DbType.String, null);
                db.AddInParameter(dbCommand, "_tel", DbType.String, null);
                db.AddInParameter(dbCommand, "_jor_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "_pro_id", DbType.Int32, null);
                db.AddInParameter(dbCommand, "accion", DbType.String, "consultar");

                dsEstudiante = db.ExecuteDataSet(dbCommand);
                //Es que el resultado de la consulta sql en memoria desde el motor, 
                //se almacena directamente en el dataset en el Estudiante.

                if (dsEstudiante != null)
                {
                    if (dsEstudiante.Tables[0].Rows.Count > 0)
                    {
                        //foreach es un ciclo para recorrer elementos sin un limite definido

                        foreach (DataRow oRow in dsEstudiante.Tables[0].Rows)
                        {

                            objEstudiante.est_id = Convert.ToInt32(oRow["est_id"]);
                            objEstudiante.est_nom = oRow["est_nom"].ToString();
                            objEstudiante.est_dir = oRow["est_dir"].ToString();
                            objEstudiante.est_tel = oRow["est_tel"].ToString();
                            objEstudiante.jor_id = Convert.ToInt32(oRow["jor_id"]);
                            objEstudiante.pro_id = Convert.ToInt32(oRow["pro_id"]);

                            //Se añade el objeto dependencia a la lista


                        }
                    }
                    else
                    {

                        objEstudiante = null;
                    }
                }
                else
                {

                    objEstudiante = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsEstudiante.Dispose();
            }
            return objEstudiante;

        }

    }
}
