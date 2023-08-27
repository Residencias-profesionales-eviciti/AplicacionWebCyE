using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class EncuestaPreguntaRespuesta
    {
        public int ID { get; set; }
        public string Respuesta { get; set; }
        public EncuestaPreguntaTipo oEncuestaPreguntaTipo { get; set; }
        public Pregunta oPregunta { get; set; }
    }
}
