using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicosDirectivos.ViewModels
{
    public class ProfesionalVM
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Especialidades { get; set; }

        public ProfesionalVM()
        {

        }

        public ProfesionalVM(Profesionales profesional, List<Especialidades> especialidades)
        {
            this.Id = profesional.id;
            this.Apellido = profesional.primerApellido;
            this.DNI = profesional.numeroDocumento;
            this.Especialidades = ObtenerEspecialidadesSTring(especialidades);
            this.Nombre = profesional.primerNombre;
            
        }

        private string ObtenerEspecialidadesSTring(List<Especialidades> especialidades)
        {
            string retornador = string.Empty;
            foreach (Especialidades especialidad in especialidades)
            {
                retornador += especialidad.nombre + " ,";
            }

            if(especialidades.Count > 0)
                retornador = retornador.Substring(0,retornador.Length-2);
            return retornador;
        }
    }
}