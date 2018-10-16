using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class UsuariosDTO
    {
        public int usu_id { get; set; }
        public string usu_nom { get; set; }
        public string usu_login { get; set; }
        public string usu_pass { get; set; }
        public int rol_id { get; set; }

    }
}
