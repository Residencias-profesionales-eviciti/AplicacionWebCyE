using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace AplicacionWebCyE.Controllers
{
    public class Conexion
    {
        public static string cn = ConfigurationManager.ConnectionStrings["SistemaContext"].ToString();
    }

     
}