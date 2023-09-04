using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_EncuestaPregunta
    {
        public List<EncuestaPregunta> Listar()
        {
            List<EncuestaPregunta> lista = new List<EncuestaPregunta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerEncuestaPregunta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new EncuestaPregunta()
                                {
                                    IdEncuesta_pregunta = Convert.ToInt32(dr["IdEncuesta_pregunta"]),
                                    oIdEncuesta = new Encuesta() { IdEncuesta = Convert.ToInt32(dr["IdEncuesta"]), Nombre = dr["Nombre"].ToString() },  
                                    Titulo = dr["Titulo"].ToString(),
                                    Forma_respuesta = dr["Opcion"].ToString(),
                                    Tipo_respuesta = dr["Tipo_respuesta"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<EncuestaPregunta>();

            }
            return lista;
        }

        public int Registrar(EncuestaPregunta obj, out string mensaje)
        {
            int idautogenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEncuestaPregunta", oconexion);
                    cmd.Parameters.AddWithValue("Titulo", obj.Titulo);
                    //cmd.Parameters.AddWithValue("IdEncuesta", obj.oIdEncuesta.IdEncuesta);
                    cmd.Parameters.AddWithValue("Forma_respuesta", obj.Forma_respuesta);
                    cmd.Parameters.AddWithValue("Tipo_respuesta", obj.Tipo_respuesta);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
            } 
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }

            return idautogenerado;

        }


    }
}
