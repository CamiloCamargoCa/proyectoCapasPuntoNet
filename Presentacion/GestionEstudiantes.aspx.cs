using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;

namespace Presentacion
{
    public partial class GestionEstudiantes : System.Web.UI.Page
    {

        Conexion oConexion = new Conexion();
        EstudianteControlador objEstudianteControlador = new EstudianteControlador();
        JornadaControlador objJornadaControlador = new JornadaControlador();
        ProgramaControlador objProgramaControlador = new ProgramaControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //La pagina no ha sido procesada por segunda vez
            {
                ListarEstudiantes();
                CargarJornada();
                CargarPrograma();
            }
        }

        private void CargarJornada()
        {
            ddlidjorestudiante.DataSource = objJornadaControlador.ListarJornadas(oConexion.sConexion());
            ddlidjorestudiante.DataBind();
        }

        private void CargarPrograma()
        {
            ddlidproestudiante.DataSource = objProgramaControlador.ListarProgramas(oConexion.sConexion());
            ddlidproestudiante.DataBind();
        }
        private void ListarEstudiantes()
        {
            //El método se conectará con las reglas de negocio y cargar en la Grilla los datos
            List<EstudianteDTO> lstEstudianteDTO = new List<EstudianteDTO>();
            
            gvlistadoestudiantes.DataSource = objEstudianteControlador.ListarEstudiantes(oConexion.sConexion());
            gvlistadoestudiantes.DataBind();
        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            String NombreEstudiante = txtnomestudiante.Text;
            String DireccionEstudiante = txtdirestudiante.Text;
            String TelefonoEstudiante = txttelestudiante.Text;
            //Int32 IdJornadaEstudiante = Convert.ToInt32(txtidjorestudiante.Text);
            //Int32 IdProgramaEstudiante = Convert.ToInt32(txtidproestudiante.Text);
            Int32 IdJornadaEstudiante = Convert.ToInt32(ddlidjorestudiante.SelectedValue);
            Int32 IdProgramaEstudiante = Convert.ToInt32(ddlidproestudiante.SelectedValue);

            objEstudianteControlador.InsertarEstudiante(NombreEstudiante, DireccionEstudiante, TelefonoEstudiante, IdJornadaEstudiante, IdProgramaEstudiante, oConexion.sConexion());

            //Visualizar si realizó los cambios

            ListarEstudiantes();
        }

        protected void BtnEliminar_Click1(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodeEstudiante = Convert.ToInt32(gvlistadoestudiantes.Rows[currentRow.RowIndex].Cells[0].Text);

            objEstudianteControlador.EliminarEstudiante(codigodeEstudiante, oConexion.sConexion());

            ListarEstudiantes();
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Button)sender).Parent.Parent;
            Int32 codigodeEstudiante = Convert.ToInt32(gvlistadoestudiantes.Rows[currentRow.RowIndex].Cells[0].Text);
            EstudianteDTO objEstudianteDTO = new EstudianteDTO();

            objEstudianteDTO = objEstudianteControlador.ConsultarEstudiante(codigodeEstudiante, oConexion.sConexion());

            lblvalorcodigo.Text = objEstudianteDTO.est_id.ToString();
            txtnomestudiante.Text = objEstudianteDTO.est_nom;
            txtdirestudiante.Text = objEstudianteDTO.est_dir;
            txttelestudiante.Text = objEstudianteDTO.est_tel;
            //txtidjorestudiante.Text = objEstudianteDTO.jor_id.ToString();
            //txtidproestudiante.Text = objEstudianteDTO.pro_id.ToString();
            ddlidjorestudiante.SelectedValue = objEstudianteDTO.jor_id.ToString();
            ddlidproestudiante.SelectedValue = objEstudianteDTO.pro_id.ToString();
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            Int32 CodigoEstudiante = Convert.ToInt32(lblvalorcodigo.Text);
            String NombreEstudiante = txtnomestudiante.Text;
            String DireccionEstudiante = txtdirestudiante.Text;
            String TelefonoEstudiante = txttelestudiante.Text;
            //Int32 IdJornadaEstudiante = Convert.ToInt32(txtidjorestudiante.Text);
            //Int32 IdProgramaEstudiante = Convert.ToInt32(txtidproestudiante.Text);
            Int32 IdJornadaEstudiante = Convert.ToInt32(ddlidjorestudiante.SelectedValue);
            Int32 IdProgramaEstudiante = Convert.ToInt32(ddlidproestudiante.SelectedValue);

            objEstudianteControlador.ActualizarEstudiante(CodigoEstudiante, NombreEstudiante, DireccionEstudiante, TelefonoEstudiante, IdJornadaEstudiante, IdProgramaEstudiante, oConexion.sConexion());

            //Visualizar si realizó los cambios

            ListarEstudiantes();
        }

        
    }
}