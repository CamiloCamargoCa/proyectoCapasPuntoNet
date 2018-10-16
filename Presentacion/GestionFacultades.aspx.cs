using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;

namespace Presentacion
{
    public partial class GestionFacultades : System.Web.UI.Page
    {
        Conexion oConexion = new Conexion();
        FacultadControlador objFacultadControlador = new FacultadControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //La pagina no ha sido procesada por segunda vez
            {
                ListarFacultades();
            }
        }


        private void ListarFacultades()
        {
            //El método se conectará con las reglas de negocio y cargar en la Grilla los datos
            List<EstudianteDTO> lstEstudianteDTO = new List<EstudianteDTO>();

            gvlistadoFacultades.DataSource = objFacultadControlador.ListarFacultades(oConexion.sConexion());
            gvlistadoFacultades.DataBind();
        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            String NombreFacultad = txtnomFacultad.Text;
            objFacultadControlador.InsertarFacultad(NombreFacultad, oConexion.sConexion());         

            //Visualizar si realizó los cambios

            ListarFacultades();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodeFacultad = Convert.ToInt32(gvlistadoFacultades.Rows[currentRow.RowIndex].Cells[0].Text);

            objFacultadControlador.EliminarFacultad(codigodeFacultad, oConexion.sConexion());

            ListarFacultades();
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodeFacultad = Convert.ToInt32(gvlistadoFacultades.Rows[currentRow.RowIndex].Cells[0].Text);
            FacultadDTO objFacultadDTO = new FacultadDTO();
            objFacultadDTO = objFacultadControlador.ConsultarFacultad(codigodeFacultad, oConexion.sConexion());


            lblvalorcodigo.Text = objFacultadDTO.fac_id.ToString();
            txtnomFacultad.Text = objFacultadDTO.fac_nom;

        }

        protected void btnactualizar_Click1(object sender, EventArgs e)
        {
            Int32 CodigoFacultad = Convert.ToInt32(lblvalorcodigo.Text);
            String NombreFacultad = txtnomFacultad.Text;

            objFacultadControlador.ActualizarFacultad(CodigoFacultad, NombreFacultad, oConexion.sConexion());

            //Visualizar si realizó los cambios

            ListarFacultades();
        }
    }
}