using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
    
            
        Conexion oc = new Conexion();

        ScriptPaginaPrivilegios objutil = new ScriptPaginaPrivilegios();
        public String ScriptModulos; //Esta indica en el el aspx



        protected void Page_Load(object sender, EventArgs e)
        {
            DesplegarPrivilegios();
        }

        private void DesplegarPrivilegios()
        {
            Int32 rolid = (Int32)Session["_Rol"];
                //Convert.ToInt32(Session["_Rol"].ToString());
            
            ScriptModulos = objutil.DevolverScriptPrivilegiosPagina(rolid, oc.sConexion());
        }
        
    }
}