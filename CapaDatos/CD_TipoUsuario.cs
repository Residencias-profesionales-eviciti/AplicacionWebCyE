using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_TipoUsuario
    {
        public List<tipo_usuario> Listar()
        {
            List<tipo_usuario> lista = new List<tipo_usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerTipoUsuario", oconexion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new tipo_usuario()
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    nombret = dr["nombret"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<tipo_usuario>();

            }
            return lista;
        }

    }
}
