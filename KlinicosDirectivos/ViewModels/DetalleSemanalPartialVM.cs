using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicosDirectivos.ViewModels
{
    public class DetalleSemanalPartialVM
    {
        public List<Especialidades> especialidad;


        public int cantTurnosReservados;
        public int cantTurnosIngresados;
        public int cantEspontaneos;
        public int totalIngresos;
        public int totalAtendidos;


        public SemanalProfesional semanal ;
        public enum diasSemana { lunes, martes, miercoles, jueves, viernes, sabado, domigno }
        public Dictionary<diasSemana, SemanalProfesional> diasAtencion;

        public DateTime fechadesde;
        public DateTime fechaHasta;
        public string mes;
        public string anio;
        public string mesHasta;
        public string anioHasta;
        public int idSector;
        public int idEspecialidad;
        public int idProfesional;
        public string tipoEspecialidad;

    }
}