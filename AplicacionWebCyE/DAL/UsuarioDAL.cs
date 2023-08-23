using AplicacionWebCyE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AplicacionWebCyE.DAL
{
    public class UsuarioDAL
    {

        string SistemaContext = ConfigurationManager.ConnectionStrings["SistemaContext"].ConnectionString.ToString();

        public List<usuarios> Listar()
        {
            List<usuarios> lista = new List<usuarios>();

            using (SqlConnection cn = new SqlConnection(SistemaContext))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ObtenerUsuario";
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtUsuarios = new DataTable();

                cn.Open();
                sqlDa.Fill(dtUsuarios);
                cn.Close();

                foreach (DataRow dr in dtUsuarios.Rows)
                {
                    lista.Add(new usuarios
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        ID_departamento = Convert.ToInt32(dr["ID_departamento"]),
                        ID_tipo_usuario = Convert.ToInt32(dr["ID_tipo_usuario"]),
                        nombres = dr["nombres"].ToString(),
                        apellido_paterno = dr["apellido_paterno"].ToString(),
                        apellido_materno = dr["apellido_materno"].ToString(),
                        genero = dr["genero"].ToString(),
                        telefono = dr["telefono"].ToString(),
                        email = dr["email"].ToString(),
                        restablecer = Convert.ToBoolean(dr["restablecer"]),
                        status = Convert.ToBoolean(dr["status"]),
                        nombre_usuario = dr["nombre_usuario"].ToString(),
                        foto = dr["foto"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
