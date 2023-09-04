using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Tipo_Respuesta
    {
            private CD_Tipo_Respuesta objCapaDato = new CD_Tipo_Respuesta();

            public List<Tipo_Respuesta> Listar()
            {
                return objCapaDato.Listar();
            }

        }
    }
