using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicosDirectivos.ViewModels
{
    public class SemanalProfesional
    {
        public int cantidadAtenciones { get; set; }
        public int cantidadEvoluciones { get; set; }
        public string DiaSemana { get; set; }
    }
}