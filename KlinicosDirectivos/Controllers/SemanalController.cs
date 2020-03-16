using KlinicosDirectivos.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlinicosDirectivos.Controllers
{
    public class SemanalController : Controller
    {
        // GET: Semanal
        public ActionResult Index(string lugar)
        {
            Klinicos_BEntities entidades = new Klinicos_BEntities();
            List<Sectores> listaSectores = entidades.Sectores.ToList();
            List<SelectListItem> sectores = new List<SelectListItem>();
            foreach (var sector in listaSectores)
            {
                sectores.Add(new SelectListItem() { Text = sector.nombre, Value = sector.id.ToString() });
            }

            ViewBag.Sectores = sectores;
            ViewBag.Establecimiento = lugar;

            List<ProfesionalVM> listProfesionalesVM = new List<ProfesionalVM>();
            IEnumerable<Profesionales> listProfesionales = entidades.ProfesionalesDisponibles.Join(entidades.Profesionales, pd => pd.id, p => p.id, (pd, p) =>   p );
            var EspecialidadesXProfesional = entidades.ProfesionalesEspecialidades.Join(entidades.Especialidades, pe => pe.idEspecialidad, e => e.id, (pe, e) => new { idProfesional = pe.idProfesional, especialidad = e });

            foreach (Profesionales profesional in listProfesionales)
            {
                List<Especialidades> listaEspecialidades = EspecialidadesXProfesional.Where(x => x.idProfesional == profesional.id).Select(exp => (Especialidades)exp.especialidad ).ToList();
                ProfesionalVM profesionalVM = new ProfesionalVM(profesional, listaEspecialidades);
                listProfesionalesVM.Add(profesionalVM);
            }

            return View("Inicio", listProfesionalesVM);
        }

        public ActionResult SemanalSector(int idSector)
        {
            DateTime fechaDesde = DateTime.Now.AddDays(-7);
            DateTime fechaHasta = DateTime.Now;
            Klinicos_BEntities entities = new Klinicos_BEntities();
            //var AtencionesXProfesional = from profesional in entities.Profesionales
            //                             join ae in entities.AtencionesEstados
            //                             on new { profe = (int?)profesional.id , estable = Boolean.TrueString } equals new { profe = ae.idProfesionalDestino  , estable = ae.Evoluciones.Select(x => x.idSector).Contains(1).ToString() }
            //                             into pGroup
            //                             where pGroup.Count() > 10 
            //                             select new Semanal
            //                             {
            //                                 idProfesional = profesional.id,
            //                                 Apellido = profesional.primerApellido,
            //                                 Nombre =  profesional.primerNombre,
            //                                 cantidadAtenciones = pGroup.Count()

            //                             };

            //foreach (Semanal semanal in AtencionesXProfesional)
            //{
            //    Console.WriteLine("El profesional {0} tiene {1} Atenciones", semanal.NomyAp(), semanal.cantidadAtenciones);
            //    semanal.cantidadEvoluciones = ObtenerEvolucionesPorProfesionales(semanal.idProfesional, fechaDesde, fechaHasta, entities);
            //}

            var atencionesXProfesional = entities.SP_OBTENER_SEMANAL_ATENCIONES("12", "2019", idSector, 3);
            var evolucionesXProfesional = entities.SP_OBTENER_SEMANAL_EVOLUCIONES("12", "2019", idSector, 3);
            List<Semanal> semanales = CastearASemanales(atencionesXProfesional.ToList(),evolucionesXProfesional.ToList());
            
            return View("Semanal", semanales.Take(10));
        }

        private List<Semanal> CastearASemanales(List<SP_OBTENER_SEMANAL_ATENCIONES_Result> listaAtenciones, List<SP_OBTENER_SEMANAL_EVOLUCIONES_Result> listaEvoluciones)
        {
            List<Semanal> listaSemanal = new List<Semanal>();
            foreach (var atencion in listaAtenciones)
            {
                Semanal semanal = new Semanal();
                semanal.Apellido = atencion.primerApellido;
                semanal.Nombre = atencion.primerNombre;
                semanal.idProfesional = (int)atencion.idprof;
                semanal.cantidadAtenciones = (int)atencion.cantAtenciones;
                semanal.cantidadEvoluciones = 0;
                if(listaEvoluciones.Exists(x => x.idProfesional == semanal.idProfesional))
                {
                    var evolucion = listaEvoluciones.FirstOrDefault(x => x.idProfesional == semanal.idProfesional);
                    semanal.cantidadEvoluciones = (int)evolucion.cantidad;
                    
                }
                listaSemanal.Add(semanal);
            }
            return listaSemanal;

        }

        private int ObtenerEvolucionesPorProfesionales(int idProfesional, DateTime fechaDesde, DateTime fechaHasta, Klinicos_BEntities entities)
        {
            int cantidad;
            cantidad = entities.Evoluciones.Where(x => x.idProfesional == idProfesional).Count();
            return cantidad;
        }
    }
}

