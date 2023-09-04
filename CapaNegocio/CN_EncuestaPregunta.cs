using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_EncuestaPregunta
    {
        private CD_EncuestaPregunta objCapaDato = new CD_EncuestaPregunta();

        //public List<EncuestaPregunta> Listar()
        //{
        //    return objCapaDato.Listar();
        //}

        public List<EncuestaPreguntaTipo> ListarPreguntaTipo()
        {
            return Enum.GetValues(typeof(EncuestaPreguntaTipo)).Cast<EncuestaPreguntaTipo>().ToList();
        }

        public List<EncuestaPregunta> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(EncuestaPregunta obj, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El titulo de la pregunta no puede estar vacio.";
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

        //public bool Editar(EncuestaPregunta obj, out string mensaje)
        //{
        //    mensaje = string.Empty;


        //    if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
        //    {
        //        mensaje = "El titulo de la pregunta no puede estar vacio.";
        //    }

        //    if (string.IsNullOrEmpty(mensaje))
        //    {
        //        //return objCapaDato.Editar(obj, out mensaje);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
