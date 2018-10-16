using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Presentacion
{
    public class Conexion
    {
        public string sConexion()
        {

            return ConfigurationManager.ConnectionStrings["dbProgWeb"].ConnectionString;
        }
    }
}