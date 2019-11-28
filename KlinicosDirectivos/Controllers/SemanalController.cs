using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlinicosDirectivos.Controllers
{
    public class SemanalController : Controller
    {
        // GET: Semanal
        public ActionResult Index()
        {
            KlinicosEntities entidades = new KlinicosEntities();
            List<Sectores> listaSectores = entidades.Sectores.ToList();
            List<SelectListItem> sectores = new List<SelectListItem>();
            foreach (var sector in listaSectores)
            {
                sectores.Add(new SelectListItem() { Text = sector.nombre, Value = sector.id.ToString() });
            }




            ViewBag.Sectores = sectores;
            return View("Inicio");
        }

        public ActionResult SemanalEstablecimiento(int idEstablecimiento)
        {
            //KlinicosEntities entities = new KlinicosEntities();
            //entities.Atenciones.Join(
            //    entities.)

            return View("Semanal");
        }

    }
}
