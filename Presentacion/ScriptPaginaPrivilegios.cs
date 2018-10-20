using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReglasDeNegocio;

namespace Presentacion
{
    public class ScriptPaginaPrivilegios
    {
        Conexion oc = new Conexion();

        public String DevolverScriptPrivilegiosPagina(Int32 rolid, string sConexion)
        {
            String ScriptModulos = "";
            Int16 fila = 1;


            //Se despliegan los privilegios que tenga asignado el rol para el modulo
            UsuarioControlador objUsuarioDALC = new UsuarioControlador();

            List<PrivilegiosRolDTO> lstprivilegios = new List<PrivilegiosRolDTO>();

            lstprivilegios = objUsuarioDALC.ListarPrivilegiosRol(rolid, oc.sConexion());

            // String vControlZona = lstprivilegio.First().zondes;


            ScriptModulos += "<br><br><fieldset style='background-color:#fff' >" +
            "<legend class='ui-tabs ui-widget ui-widget-header ui-widget-content ui-corner-all'> " + "Menú Principal" + " </legend>" +
            "<div>";
            ScriptModulos += "<table width='100%'>";
            foreach (PrivilegiosRolDTO li in lstprivilegios)
            {

                if (fila % 2 != 0)
                {
                    ScriptModulos += "<tr>";
                    ScriptModulos += "<td style='width:50%' >" +

                    "<a href='/" + li.privurl + "" + "' class='textohl'>" + li.privnom + "</a>" +

                    "</td>";
                    fila++;
                }
                else
                {
                    ScriptModulos += "<td style='width:50%' >" +
                   "<a href='/" + li.privurl + "" + "' class='textohl'>" + li.privnom + "</a>" +
                   "</td></tr>";
                    fila++;
                }


            } //fin foreach
            ScriptModulos += "</tr>";
            ScriptModulos += "</table>";
            ScriptModulos += "</div></fieldset>";

            //  ScriptModulos += "<br><table width='100%'><tr><td align='right'><input type='button' class='button' value='Volver al Menú Principal' name='Volver' onclick='history.back()' /></td></tr></table>";


            return ScriptModulos;
        }
    }
}