using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;

namespace Presentacion
{
    public partial class GestionJornada : System.Web.UI.Page
    {
        Conexion oConexion = new Conexion();
        JornadaControlador objJornadaControlador = new JornadaControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //La pagina no ha sido procesada por segunda vez
            {
                ListarJornada();
            }
        }

        private void ListarJornada()
        {
            //El método se conectará con las reglas de negocio y cargar en la Grilla los datos
            List<JornadaDTO> lstJornadaDTO = new List<JornadaDTO>();
            gvlistadojornada.DataSource = objJornadaControlador.ListarJornadas(oConexion.sConexion());
            gvlistadojornada.DataBind();
        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            String NombreJornada = txtnombrejornada.Text;
            //objJornadaControlador.InsertarJornada(NombreJornada,oConexion.sConexion());
            objJornadaControlador.InsertarJornada(NombreJornada, oConexion.sConexion());
            //visualizar si se realizaron los cambios

            ListarJornada();
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigojornada = Convert.ToInt32(gvlistadojornada.Rows[currentRow.RowIndex].Cells[0].Text);

            objJornadaControlador.ELiminarJornada(codigojornada, oConexion.sConexion());

            ListarJornada();
        }

        protected void btnactualizar_Click1(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodejornada = Convert.ToInt32(gvlistadojornada.Rows[currentRow.RowIndex].Cells[0].Text);
            JornadaDTO objJornadaDTO = new JornadaDTO();

            objJornadaDTO = objJornadaControlador.ConsultarJornada(codigodejornada, oConexion.sConexion());


            lblvalorcodigo.Text = objJornadaDTO.jor_id.ToString();
            txtnombrejornada.Text = objJornadaDTO.jor_nom;
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            Int32 CodigoJornada = Convert.ToInt32(lblvalorcodigo.Text);
            String NombreJornada = txtnombrejornada.Text;

            objJornadaControlador.ActualizarJornada(CodigoJornada, NombreJornada, oConexion.sConexion());

            //Visualizar si realizó los cambios

            ListarJornada();
        }
    }
}