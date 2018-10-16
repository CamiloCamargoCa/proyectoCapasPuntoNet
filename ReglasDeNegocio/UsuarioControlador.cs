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

    }
}
