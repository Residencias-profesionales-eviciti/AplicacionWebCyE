using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_departamentos
    {
        private CD_departamentos objCapaDato = new CD_departamentos();

        public List<departamentos> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(departamentos obj, out string mensaje)
        {

            mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                mensaje = "El nombre del departamento no puede estar vacio.";
            }

            if(string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Registrar(obj, out mensaje);
            }

            else
            {
                return 0;
            }
        }

        public bool Editar(departamentos obj, out string mensaje)
        {
            mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                mensaje = "El nombre del departamento no puede estar vacio.";
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

    }
}
