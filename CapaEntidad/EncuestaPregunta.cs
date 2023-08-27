using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class EncuestaPregunta
    {
        public int ID { get; set; }

        public Encuesta oEncuesta { get; set; }
        public EncuestaPreguntaTipo oEncuestaPreguntaTipo { get; set; }
        public string Titulo { get; set; }


        public virtual ICollection<Pregunta> EncuestasPreguntas { get; set; }
    }

    public enum EncuestaPreguntaTipo
    {
        OpcionUnica,
        OpcionMultiple,
        OpcionAbierta
    }
}
