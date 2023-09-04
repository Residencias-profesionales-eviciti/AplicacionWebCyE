using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public departamentos oIdDepartamento { get; set; }
        public tipo_usuario oIdRol { get; set; }
        public string Nombres { get; set; }
        public string Apellido_paterno { get; set; }
        public string Apellido_materno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Status { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
