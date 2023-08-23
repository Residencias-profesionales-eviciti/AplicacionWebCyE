using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace CapaDatos
{
    public class CD_usuarios
    {
        public List<usuarios> Listar()
        {
            List<usuarios> lista = new List<usuarios>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerUsuario", oconexion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new usuarios()
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    oID_departamento = new departamentos() { ID = Convert.ToInt32(dr["ID_departamento"]), nombre = dr["nombre"].ToString() },
                                    oID_tipo_usuario = new tipo_usuario() { ID = Convert.ToInt32(dr["ID_tipo_usuario"]), nombre = dr["nombre"].ToString() },
                                    nombres = dr["nombres"].ToString(),
                                    apellido_paterno = dr["apellido_paterno"].ToString(),
                                    apellido_materno = dr["apellido_materno"].ToString(),
                                    genero = dr["genero"].ToString()[0],
                                    telefono = dr["telefono"].ToString(),
                                    email = dr["email"].ToString(),
                                    restablecer = Convert.ToBoolean(dr["restablecer"]),
                                    status = Convert.ToBoolean(dr["status"]),
                                    nombre_usuario = dr["nombre_usuario"].ToString(),
                                    foto = dr["foto"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<usuarios>();

            }
            return lista;
        }

        public int Registrar(usuarios obj, out string mensaje)
        {
            int idautogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("ID_departamento", obj.oID_departamento);
                    cmd.Parameters.AddWithValue("ID_tipo_usuario", obj.oID_tipo_usuario);
                    cmd.Parameters.AddWithValue("nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("apellido_paterno", obj.apellido_paterno);
                    cmd.Parameters.AddWithValue("apellido_materno", obj.apellido_materno);
                    cmd.Parameters.AddWithValue("genero", obj.genero);
                    cmd.Parameters.AddWithValue("telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("email", obj.email);
                    cmd.Parameters.AddWithValue("status", obj.status);
                    cmd.Parameters.AddWithValue("nombre_usuario", obj.nombre_usuario);
                    cmd.Parameters.AddWithValue("pass", obj.pass);
                    cmd.Parameters.AddWithValue("foto", obj.foto);
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }
            return idautogenerado;
        }


        public bool Editar(usuarios obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("ID", obj.ID);
                    cmd.Parameters.AddWithValue("ID_departamento", obj.oID_departamento);
                    cmd.Parameters.AddWithValue("ID_tipo_usuario", obj.oID_tipo_usuario);
                    cmd.Parameters.AddWithValue("nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("apellido_paterno", obj.apellido_paterno);
                    cmd.Parameters.AddWithValue("apellido_materno", obj.apellido_materno);
                    cmd.Parameters.AddWithValue("genero", obj.genero);
                    cmd.Parameters.AddWithValue("telefono", obj.genero);
                    cmd.Parameters.AddWithValue("email", obj.email);
                    cmd.Parameters.AddWithValue("status", obj.status);
                    cmd.Parameters.AddWithValue("nombre_usuario", obj.nombre_usuario);
                    cmd.Parameters.AddWithValue("foto", obj.foto);
                    cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int ID, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("ID", ID);
                    cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();                  

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


        public bool GuardarImagen(usuarios osuarios, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarImagenUsuario", oconexion);
                    cmd.Parameters.AddWithValue("ID", osuarios.ID);
                    cmd.Parameters.AddWithValue("foto", osuarios.foto);
                    cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        mensaje = "No se pudo guardar la imagen";
                    }


                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;

        }

    }
}
