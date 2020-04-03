using KlinicosDirectivos.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KlinicosDirectivos.Controllers
{
    public class HomeController : Controller
    {
      

        public ActionResult Index()
        {
            Klinicos_BEntities entidades = new Klinicos_BEntities();
            List<Establecimientos> listaEstablecimientos = entidades.Establecimientos.ToList();
            List<SelectListItem> establecimientos = new List<SelectListItem>();
            foreach (var establecimiento in listaEstablecimientos)
            {
                establecimientos.Add(new SelectListItem() { Text = establecimiento.nombre, Value = establecimiento.id.ToString() });
            }


            ViewBag.Establecimientos = establecimientos;
            return View("Index");
        }

        public ActionResult establecimiento(int id)
        {
            Session["Establecimiento"] = id;
            //Klinicos_BEntities entities = new Klinicos_BEntities();

            //var establecimientosTotales = entities.Establecimientos.ToList();
            //Establecimientos nombreEsta = new Establecimientos();
            //foreach (var item in establecimientosTotales)
            //{
            //    if (item.id == id)
            //    {
            //        nombreEsta = item;
            //    }
            //}



            return RedirectToAction("Index", "Semanal");
        }

     
    }
}