using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Encuesta
    {
        public List<Encuesta> Listar()
        {
            List<Encuesta> lista = new List<Encuesta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerEncuesta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Encuesta()
                                {
                                    IdEncuesta = Convert.ToInt32(dr["IdEncuesta"]),
                                    oIdUsuario = new Usuario() { IdUsuario = Convert.ToInt32(dr["IdUsuario"]), Nombres = dr["Nombres"].ToString() },
                                    Nombre = dr["Nombre"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Fecha_inicio = Convert.ToDateTime(dr["Fecha_inicio"]),
                                    Fecha_cierre = Convert.ToDateTime(dr["Fecha_cierre"]),
                                    Status = Convert.ToBoolean(dr["Status"])
                                });

                        }
                    }
                }
            }
            catch
            {
                lista = new List<Encuesta>();

            }
            return lista;
        }


        public int Registrar(Encuesta obj, out string mensaje)
        {
            int idautogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEncuesta", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oIdUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Fecha_inicio", obj.Fecha_inicio);
                    cmd.Parameters.AddWithValue("Fecha_cierre", obj.Fecha_cierre);
                    cmd.Parameters.AddWithValue("Status", obj.Status);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    //mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Encuesta obj, out string mensaje)
        {
            bool resultado = false; //Debe ir false
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarEncuesta", oconexion);
                    cmd.Parameters.AddWithValue("IdEncuesta", obj.IdEncuesta);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oIdUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Fecha_inicio", obj.Fecha_inicio);
                    cmd.Parameters.AddWithValue("Fecha_cierre", obj.Fecha_cierre);
                    cmd.Parameters.AddWithValue("Status", obj.Status);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    //mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarEncuesta", oconexion);
                    cmd.Parameters.AddWithValue("IdEncuesta", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                        
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


    }
}
