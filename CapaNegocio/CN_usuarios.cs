using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public  class CN_usuarios
    {
        private CD_usuarios objCapaDato = new CD_usuarios();

        public List<usuarios> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(usuarios obj, out string mensaje)
        {

            mensaje = string.Empty;

            if(obj.oID_departamento.ID == 0)
            {
                mensaje = "Debe seleccionar un departamento.";
            }

            else if (obj.oID_tipo_usuario.ID == 0)
            {
                mensaje = "Debe seleccionar un tipo de usuario.";
            }

            else if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                mensaje = "El nombre del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.apellido_paterno) || string.IsNullOrWhiteSpace(obj.apellido_paterno))
            {
                mensaje = "El apellido paterno del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.apellido_materno) || string.IsNullOrWhiteSpace(obj.apellido_materno))
            {
                mensaje = "El apellido materno del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.genero.ToString()) || string.IsNullOrWhiteSpace(obj.genero.ToString()))
            {
                mensaje = "El genero del departamento no puede estar vacio.";
            }

            else if(string.IsNullOrEmpty(obj.telefono) || string.IsNullOrWhiteSpace(obj.telefono))
            {
                mensaje = "El telefono del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.email) || string.IsNullOrWhiteSpace(obj.email))
            {
                mensaje = "El email del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.nombre_usuario) || string.IsNullOrWhiteSpace(obj.nombre_usuario))
            {
                mensaje = "El nombre de usuario del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.pass) || string.IsNullOrWhiteSpace(obj.pass))
            {
                mensaje = "El password del departamento no puede estar vacio.";
            }


            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Registrar(obj, out mensaje);
            }

            else
            {
                return 0;
            }
        }


        public bool Editar(usuarios obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.oID_departamento.ID == 0)
            {
                mensaje = "Debe seleccionar un departamento.";
            }

            else if (obj.oID_tipo_usuario.ID == 0)
            {
                mensaje = "Debe seleccionar un tipo de usuario.";
            }

            else if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                mensaje = "El nombre del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.apellido_paterno) || string.IsNullOrWhiteSpace(obj.apellido_paterno))
            {
                mensaje = "El apellido paterno del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.apellido_materno) || string.IsNullOrWhiteSpace(obj.apellido_materno))
            {
                mensaje = "El apellido materno del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.genero.ToString()) || string.IsNullOrWhiteSpace(obj.genero.ToString()))
            {
                mensaje = "El genero del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.telefono) || string.IsNullOrWhiteSpace(obj.telefono))
            {
                mensaje = "El telefono del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.email) || string.IsNullOrWhiteSpace(obj.email))
            {
                mensaje = "El email del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.nombre_usuario) || string.IsNullOrWhiteSpace(obj.nombre_usuario))
            {
                mensaje = "El nombre de usuario del departamento no puede estar vacio.";
            }

            else if (string.IsNullOrEmpty(obj.pass) || string.IsNullOrWhiteSpace(obj.pass))
            {
                mensaje = "El password del departamento no puede estar vacio.";
            }


            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Editar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int ID, out string mensaje)
        {
            return objCapaDato.Eliminar(ID, out mensaje);
        }


        public bool GuardarImagen(usuarios osuarios, out string mensaje)
        {
            return objCapaDato.GuardarImagen(osuarios, out mensaje);
        }

        public static string ConvertirBase64(string ruta,out bool conversion)
        {
            string textoBase64 = string.Empty;
            conversion = false;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                textoBase64 = Convert.ToBase64String(bytes);
            }
            catch
            {
                conversion = false;
            }
            return textoBase64;
        }
    }
}
