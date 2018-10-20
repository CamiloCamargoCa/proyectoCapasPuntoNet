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
    public class UsuarioControlador
    {
        public UsuariosDTO ConsultarUsuario(UsuariosDTO usuario, String Conexion)
        {
            UsuariosDTO objUsuario = new UsuariosDTO();
            string SQLCommand = "sp_usuario_Login";
            DataSet dsUsuario = null;


            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "login", DbType.String, usuario.usu_login);
                db.AddInParameter(dbCommand, "password", DbType.String, usuario.usu_pass);


                dsUsuario = db.ExecuteDataSet(dbCommand);
                //Es que el resultado de la consulta sql en memoria desde el motor, 
                //se almacena directamente en el dataset en el Estudiante.

                if (dsUsuario != null)
                {
                    if (dsUsuario.Tables[0].Rows.Count > 0)
                    {
                        //foreach es un ciclo para recorrer elementos sin un limite definido

                        foreach (DataRow oRow in dsUsuario.Tables[0].Rows)
                        {

                            objUsuario.usu_id = Convert.ToInt32(oRow["usu_id"]);
                            objUsuario.usu_login = oRow["usu_login"].ToString();
                            objUsuario.usu_nom = oRow["usu_nom"].ToString();
                            objUsuario.rol_id = Convert.ToInt32(oRow["rol_id"]);
                            

                            //Se añade el objeto dependencia a la lista


                        }
                    }
                    else
                    {

                        objUsuario = null;
                    }
                }
                else
                {

                    objUsuario = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsUsuario.Dispose();
            }
            return objUsuario;

        }

        public List<PrivilegiosRolDTO> ListarPrivilegiosRol(int rol , String Conexion)
        {
            //lista fisica
            List<PrivilegiosRolDTO> lstprivilegiorol = new List<PrivilegiosRolDTO>();
            string SQLCommand = "sp_privilegios_rol";
            DataSet dsPrivilegiosRol = null;

            try
            {
                SqlDatabase db = new SqlDatabase(Conexion);
                DbCommand dbCommand = db.GetStoredProcCommand(SQLCommand);

                db.AddInParameter(dbCommand, "rol", DbType.String, rol);

                //consulta del motor para en memoria al programa
                dsPrivilegiosRol = db.ExecuteDataSet(dbCommand);

                //preguntar si tiene datos
                if (dsPrivilegiosRol != null)
                {
                    if (dsPrivilegiosRol.Tables[0].Rows.Count > 0)
                    {
                        //un ciclo para recorrer los eementos sin limite
                        foreach (DataRow oRow in dsPrivilegiosRol.Tables[0].Rows)
                        {
                            PrivilegiosRolDTO objPrivRol = new PrivilegiosRolDTO();
                            objPrivRol.rolid = Convert.ToInt32(oRow["rol_id"]);
                            objPrivRol.privnom = oRow["priv_nom"].ToString();
                            objPrivRol.privurl = oRow["priv_url"].ToString();
                            //Se añade el objeto dependencia a la lista
                            lstprivilegiorol.Add(objPrivRol);

                        }
                    }
                    else
                    {
                        lstprivilegiorol = null;
                    }
                }
                else
                {
                    lstprivilegiorol = null;
                }
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                dsPrivilegiosRol.Dispose();
            }

            return lstprivilegiorol;
        }

    }
}
