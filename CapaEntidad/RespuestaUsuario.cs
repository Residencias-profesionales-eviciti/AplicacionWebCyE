using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class RespuestaUsuario
    {
        public int ID { get; set; }
        public Encuesta oEncuestas { get; set; }
        public Usuario oUsuario { get; set; }

        public EncuestaPreguntaRespuesta oEncuestaPreguntaRespuesta { get; set; }
        public string Respuesta { get; set; }
    }
}
