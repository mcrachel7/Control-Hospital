using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Examen.Models
{
    public class Hospital
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }
        public DateTime Fecha_Consulta { get; set; }
        public string Sintomas { get; set; }
        public string Diagnóstico { get; set; }

    }
}
