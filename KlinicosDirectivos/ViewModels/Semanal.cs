using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicosDirectivos.ViewModels
{
    public class Semanal
    {
        public int cantidadAtenciones { get; set; }
        public int  cantidadEvoluciones { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int idProfesional { get; set; }

        public string NomyAp()
        {
            return this.Nombre + " " + this.Apellido;
        }
    }
}