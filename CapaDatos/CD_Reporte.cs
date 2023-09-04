using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public Dashboard VerDashboard()
        {
            Dashboard objeto = new Dashboard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", oconexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Dashboard()
                            {
                                TotalUsuario = Convert.ToInt32(dr["TotalUsuario"]),
                                TotalDepartamento = Convert.ToInt32(dr["TotalDepartamento"]),
                                TotalEncuesta = Convert.ToInt32(dr["TotalEncuesta"]),
                                TotalCuestionario = Convert.ToInt32(dr["TotalCuestionario"])
                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new Dashboard();

            }
            return objeto;
        }

    }
}
