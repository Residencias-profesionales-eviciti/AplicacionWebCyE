using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class Pregunta
    {
        public int ID { get; set; }

        public string Titulo { get; set; }
        public EncuestaPregunta oPreguntasEncuestas { get; set; }

        public EncuestaPregunta oEncuestaPregunta { get; set; }
        public virtual ICollection<EncuestaPreguntaRespuesta> oEncuestaPreguntaRespuesta { get; set; }
    }
}
