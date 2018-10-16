using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class EstudianteDTO
    {
        public Int32 est_id { get; set; }
        public String est_nom { get; set; }
        public String est_dir { get; set; }
        public String est_tel { get; set; }
        public Int32 jor_id { get; set; }
        public String jor_nom { get; set; }
        public Int32 pro_id { get; set; }
        public String pro_nom { get; set; }
    }
}
