using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objCapaDato = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede estar vacio.";
            } 
            else if (string.IsNullOrEmpty(obj.Apellido_paterno) || string.IsNullOrWhiteSpace(obj.Apellido_paterno))
            {
                Mensaje = "El apellido paterno del usuario no puede estar vacio.";
            }
            else if (string.IsNullOrEmpty(obj.Apellido_materno) || string.IsNullOrWhiteSpace(obj.Apellido_materno))
            {
                Mensaje = "El apellido materno del usuario no puede estar vacio.";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo electronico es necesario para el registro.";
            }
            //else if(string.Equals(obj.Correo,obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            //{
            //    Mensaje = "El correo electronico ya existe.";
            //}
            else if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                Mensaje = "Se necesita de una clave para el registro.";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }

            else
            {
                return 0;
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del colaborador no puede estar vacio.";

            }
            else if (string.IsNullOrEmpty(obj.Apellido_paterno) || string.IsNullOrWhiteSpace(obj.Apellido_paterno))
            {
                Mensaje = "El apellido paterno del colaborador no puede estar vacio.";
            }
            else if (string.IsNullOrEmpty(obj.Apellido_materno) || string.IsNullOrWhiteSpace(obj.Apellido_materno))
            {
                Mensaje = "El apellido materno del colaborador no puede estar vacio.";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo electronico es necesario para el acceso a la aplicación.";
            }
            else if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                Mensaje = "Se necesita de una clave para el acceso a la aplicación.";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

    }
}
