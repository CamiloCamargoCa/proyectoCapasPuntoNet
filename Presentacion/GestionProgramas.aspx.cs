using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;

namespace Presentacion
{
    public partial class GestionProgramas : System.Web.UI.Page
    {
        Conexion oConexion = new Conexion();
        ProgramaControlador objProgramaControlador = new ProgramaControlador();
        FacultadControlador objProgramaFacultad = new FacultadControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //La pagina no ha sido procesada por segunda vez
            {
                ListarProgramas();
                CargarFacultad();
            }
        }

        private void CargarFacultad() {
            ddlfacultad.DataSource = objProgramaFacultad.ListarFacultades(oConexion.sConexion());
            ddlfacultad.DataBind();
        }


        private void ListarProgramas()
        {
            //El método se conectará con las reglas de negocio y cargar en la Grilla los datos
            List<EstudianteDTO> lstEstudianteDTO = new List<EstudianteDTO>();

            gvlistadoprogramas.DataSource = objProgramaControlador.ListarProgramas(oConexion.sConexion());
            gvlistadoprogramas.DataBind();
        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            String NombrePrograma = txtnomprograma.Text;
            Int32 IdFacultad = Convert.ToInt32(ddlfacultad.SelectedValue);

            //Int32 IdFacultad = Convert.ToInt32(txtidfacultad.Text);
            objProgramaControlador.InsertarPrograma(NombrePrograma,IdFacultad, oConexion.sConexion());

            //Visualizar si realizó los cambios

            ListarProgramas();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodeprograma = Convert.ToInt32(gvlistadoprogramas.Rows[currentRow.RowIndex].Cells[0].Text);

            objProgramaControlador.EliminarPrograma(codigodeprograma, oConexion.sConexion());

            ListarProgramas();
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodeprograma = Convert.ToInt32(gvlistadoprogramas.Rows[currentRow.RowIndex].Cells[0].Text);
            ProgramaDTO objProgramaDTO = new ProgramaDTO();

            objProgramaDTO = objProgramaControlador.ConsultarPrograma(codigodeprograma, oConexion.sConexion());


            lblvalorcodigo.Text = objProgramaDTO.pro_id.ToString();
            txtnomprograma.Text = objProgramaDTO.pro_nom;
            ddlfacultad.SelectedValue = objProgramaDTO.fac_id.ToString();
        }

        protected void btnactualizar_Click1(object sender, EventArgs e)
        {
            Int32 CodigoPrograma = Convert.ToInt32(lblvalorcodigo.Text);
            String NombrePrograma = txtnomprograma.Text;
            Int32 CodigoFacultad = Convert.ToInt32(ddlfacultad.SelectedValue);

            objProgramaControlador.ActualizarPrograma(CodigoPrograma, NombrePrograma, CodigoFacultad, oConexion.sConexion());

            //Visualizar si realizó los cambios

            ListarProgramas();
        }
    }
}