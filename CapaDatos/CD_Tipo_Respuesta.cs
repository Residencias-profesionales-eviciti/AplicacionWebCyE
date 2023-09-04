using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Tipo_Respuesta
    {
        public List<Tipo_Respuesta> Listar()
        {
            List<Tipo_Respuesta> lista = new List<Tipo_Respuesta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerTipo_Respuesta", oconexion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Tipo_Respuesta()
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    descripcion = dr["descripcion"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Tipo_Respuesta>();

            }
            return lista;
        }
    }
}
