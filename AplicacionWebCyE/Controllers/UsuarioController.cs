using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace AplicacionWebCyE.Controllers
{
    public class UsuarioController : Controller
    {
       /* string SistemaContext = ConfigurationManager.ConnectionStrings["SistemaContext"].ConnectionString.ToString();*/

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<usuarios> olista = new List<usuarios>();

            olista = new CN_usuarios().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarUsuarios(string objeto, HttpPostedFileBase archivoImagen)
        {
            //object resultado;
            string mensaje = string.Empty;
            bool operacion_correcta = true;
            bool guardar_imagen_exito = true;

            usuarios ousuarios = new usuarios();

            ousuarios = JsonConvert.DeserializeObject<usuarios>(objeto);


            if (ousuarios.ID == 0)
            {
                int ID_UsuarioGenerado = new CN_usuarios().Registrar(ousuarios, out mensaje);

                if(ID_UsuarioGenerado !=0)
                {
                    ousuarios.ID = ID_UsuarioGenerado;
                }
                else
                {
                    operacion_correcta = false;
                }


            }
            else
            {
                operacion_correcta = new CN_usuarios().Editar(ousuarios, out mensaje);
            }

            if(operacion_correcta)
            {
                if(archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorImagenes"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_imagen = string.Concat(ousuarios.ID.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_imagen));
                    }
                    catch (Exception ex)
                    {
                        string mensaje_error = ex.Message;
                        guardar_imagen_exito = false;
                    }


                    if(guardar_imagen_exito)
                    {
                        ousuarios.rutafoto = ruta_guardar;
                        ousuarios.foto = nombre_imagen;
                        bool respuesta = new CN_usuarios().GuardarImagen(ousuarios, out mensaje);
                    }
                    else
                    {
                        mensaje = "Se guardo el usuario, pero la imagen no";
                    }
                        
                }
            }

            return Json(new { operacionCorrecta = operacion_correcta, IDGenerado = ousuarios.ID, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ImagenUsuario(int ID)
        {
            bool conversion;
            usuarios ousuarios = new CN_usuarios().Listar().Where(u => u.ID == ID).FirstOrDefault();

            string textoBase64 = CN_usuarios.ConvertirBase64(Path.Combine(ousuarios.rutafoto,ousuarios.foto), out conversion);

            return Json(new
            {
                conversion = conversion,
                textobase64 = textoBase64,
                extension = Path.GetExtension(ousuarios.foto)

            }, 
            JsonRequestBehavior.AllowGet
            );
        }

        [HttpPost]
        public JsonResult EliminarUsuarios(int ID)
        {
            bool resultado = false;
            string mensaje = string.Empty;

            resultado = new CN_usuarios().Eliminar(ID, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }


        

        //public  List<usuarios> Listar()
        //{
        //    List<usuarios> lista = new List<usuarios>();

        //    using (SqlConnection cn = new SqlConnection(SistemaContext))
        //    {
        //        SqlCommand cmd = cn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "sp_ObtenerUsuario";
        //        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        //        DataTable dtUsuarios = new DataTable();

        //        cn.Open();
        //        sqlDa.Fill(dtUsuarios);
        //        cn.Close();

        //        foreach(DataRow dr in dtUsuarios.Rows)
        //        {
        //            lista.Add(new usuarios
        //            {
        //                ID = Convert.ToInt32(dr["ID"]),
        //                ID_departamento = Convert.ToInt32(dr["ID_departamento"]),
        //                ID_tipo_usuario = Convert.ToInt32(dr["ID_tipo_usuario"]),
        //                nombres = dr["nombres"].ToString(),
        //                apellido_paterno = dr["apellido_paterno"].ToString(),
        //                apellido_materno = dr["apellido_materno"].ToString(),
        //                genero = dr["genero"].ToString(),
        //                telefono = dr["telefono"].ToString(),
        //                email = dr["email"].ToString(),
        //                restablecer = Convert.ToBoolean(dr["restablecer"]),
        //                status = Convert.ToBoolean(dr["status"]),
        //                nombre_usuario = dr["nombre_usuario"].ToString(),
        //                foto = dr["foto"].ToString()
        //            }); 
        //        }
        //    }

            //try
            //{
            //    using (SqlConnection cn = new SqlConnection(SistemaContext))
            //    {
            //        SqlCommand cmd = new SqlCommand("sp_ObtenerUsuario", cn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cn.Open();

            //        using (SqlDataReader dr = cmd.ExecuteReader())
            //        {
            //            while (dr.Read())
            //            {
            //                lista.Add(
            //                        new usuarios()
            //                        {
            //                            ID = Convert.ToInt32(dr["ID"]),
            //                            ID_departamento = Convert.ToInt32(dr["ID_departamento"]),
            //                            ID_tipo_usuario = Convert.ToInt32(dr["ID_tipo_usuario"]),
            //                            nombres = dr["nombres"].ToString(),
            //                            apellido_paterno = dr["apellido_paterno"].ToString(),
            //                            apellido_materno = dr["apellido_materno"].ToString(),
            //                            genero = dr["genero"].ToString(),
            //                            telefono = dr["telefono"].ToString(),
            //                            email = dr["email"].ToString(),
            //                            restablecer = Convert.ToBoolean(dr["restablecer"]),
            //                            status = Convert.ToBoolean(dr["status"]),
            //                            nombre_usuario = dr["nombre_usuario"].ToString()
            //                        }
            //                    );
            //            }
            //        }


            //    }
            //} 
            //catch (Exception ex)
            //{
            //    lista = new List<usuarios>();
            //}
            //return lista;
        

        
        //public JsonResult ListarUsuarios()
        //
        //    return Json(Listar(), JsonRequestBehavior.AllowGet);
        //}



        //[HttpPost]

        //public ActionResult Registrar(usuarios ousuarios)
        //{
        //    bool resultado = false;
        //    string mensaje;

        //    using (SqlConnection cn = new SqlConnection(SistemaContext))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
        //        cmd.Parameters.AddWithValue("ID", ousuarios.ID);
        //        cmd.Parameters.AddWithValue("ID_departamento", ousuarios.ID_departamento);
        //        cmd.Parameters.AddWithValue("ID_tipo_usuario", ousuarios.ID_tipo_usuario);
        //        cmd.Parameters.AddWithValue("nombres", ousuarios.nombres);
        //        cmd.Parameters.AddWithValue("apellido_paterno", ousuarios.apellido_paterno);
        //        cmd.Parameters.AddWithValue("apellido_materno", ousuarios.apellido_materno);
        //        cmd.Parameters.AddWithValue("genero", ousuarios.genero);
        //        cmd.Parameters.AddWithValue("telefono", ousuarios.telefono);
        //        cmd.Parameters.AddWithValue("email", ousuarios.email);
        //        cmd.Parameters.AddWithValue("restablecer", ousuarios.restablecer);
        //        cmd.Parameters.AddWithValue("status", ousuarios.status);    
        //        cmd.Parameters.AddWithValue("nombre_usuario", ousuarios.nombre_usuario);
        //        cmd.Parameters.AddWithValue("pass", ousuarios.pass);
        //        cmd.Parameters.AddWithValue("foto", ousuarios.foto);
        //        cmd.Parameters.Add("Registrado", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        cn.Open();      
        //        resultado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
        //        mensaje = cmd.Parameters["Mensaje"].Value.ToString();
        //    }

        //    ViewData["Mensaje"] = mensaje;

        //    if(resultado)
        //    {
        //        return RedirectToAction("Index","Usuario");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]

        //public ActionResult Login(usuarios ousuarios)
        //{
        //    using (SqlConnection cn = new SqlConnection(SistemaContext))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
        //        cmd.Parameters.AddWithValue("email", ousuarios.email);
        //        cmd.Parameters.AddWithValue("pass", ousuarios.pass);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cn.Open();

        //        ousuarios.ID = Convert.ToInt32(cmd.ExecuteScalar().ToString());

        //    }
        //    if (ousuarios.ID != 0)
        //    {
        //        Session["usuarios"] = ousuarios;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewData["mensaje"] = "Usuario o contraseña incorrectos";
        //        return View();
        //    }

        //}
    }
}
