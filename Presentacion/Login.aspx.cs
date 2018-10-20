using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        Conexion oc = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            // Verificar si el usuario existe 
            ValidarUsuario();
        }
        private void ValidarUsuario()
        {

            UsuariosDTO objUsuarioDTO = new UsuariosDTO();
            UsuarioControlador UsuarioDALC = new UsuarioControlador();


            string strClave = txtpassword.Text;
            string strLlave = "";
            string strClaveEncriptada = "";
            try
            {

                strLlave = Constantes.EncryptionKey;
                Encriptacion objSymetric = new Encriptacion();
                strClaveEncriptada = objSymetric.DecryptData(strLlave, "84xa3zqaB8E2nblxXcNaWg==");
                strClaveEncriptada = objSymetric.EncryptData(strLlave, strClave);


                objUsuarioDTO.usu_login = txtlogin.Text;
                objUsuarioDTO.usu_pass = strClaveEncriptada;


                objUsuarioDTO = UsuarioDALC.ConsultarUsuario(objUsuarioDTO, oc.sConexion());


                if (objUsuarioDTO != null)
                {
                    Label4.Text = "Bienvenido";

                    //Se crean las variables de sesion

                    Session["_Usuario"] = objUsuarioDTO.usu_nom;
                    Session["_Rol"] = objUsuarioDTO.rol_id;

                    Response.Redirect("MenuPrincipal.aspx");

                }
                else
                {
                    Label4.Text = "Usuario No existe";
                }

               
            }
            catch (Exception ex)
            {
                Label4.Text = "Usuario No encontrado";
            }



        }
    }
}