using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_TipoUsuario
    {
        private CD_TipoUsuario objCapaDato = new CD_TipoUsuario();

        public List<tipo_usuario> Listar()
        {
            return objCapaDato.Listar();
        }


    }
}
