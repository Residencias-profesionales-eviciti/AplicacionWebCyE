using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class usuarios
    {
        public int ID { get; set; }
        public departamentos oID_departamento { get; set; }
        public tipo_usuario oID_tipo_usuario { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public char genero { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public bool restablecer { get; set; }
        public bool status { get; set; }
        public string nombre_usuario { get; set; }
        public string pass { get; set; }
        public string foto { get; set; }    
        public string rutafoto { get; set; }

        public string base64 { get; set; }

        public string extension { get; set; }

    }
}
