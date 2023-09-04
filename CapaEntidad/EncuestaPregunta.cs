using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EncuestaPregunta
    {
        public int IdEncuesta_pregunta { get; set; }
        public Encuesta oIdEncuesta { get; set; }

        public string Titulo { get; set; }
        public string Forma_respuesta { get; set; }

        public string Tipo_respuesta { get; set; }

        //public List<EncuestaPreguntaTipo> oEncuestaPreguntaTipo { get; set; }
       
    }

    public enum EncuestaPreguntaTipo
    {
        OpcionUnica,
        OpcionMultiple,
        OpcionAbierta
    }
}
