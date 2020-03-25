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

            Klinicos_BEntities entities = new Klinicos_BEntities();

            var establecimientosTotales = entities.Establecimientos.ToList();
            Establecimientos nombreEsta = new Establecimientos();
            foreach (var item in establecimientosTotales)
            {
                if (item.id == id)
                {
                    nombreEsta = item;
                }
            }



            return RedirectToAction("Index", "Semanal", new { lugar = nombreEsta.nombre });
        }

        ////Crear metodo que reciba id establecimiento y devuelva IP

        ////Lista de IP: 
        ////Cemefir: 192.168.71.10
        ////Eizaguirre: 172.48.1.10
        ////Germani: 172.28.1.220
        ////Giovinazzo: 172.26.1.10
        ////Niños: 172.29.1.100
        ////Policlinico: 192.168.34.10
        ////Rebasa: 172.46.1.10
        ////Sakamoto: 172.45.1.10
        ////Salud Mental: 192.168.70.10

        //private double ip;

        //public ActionResult ObtenerIp(int id)
        //{
        //    Klinicos_BEntities entities = new Klinicos_BEntities();

        //    var establecimientosTotales = entities.Establecimientos.ToList();
        //    Establecimientos establecimientos = new Establecimientos();

        //    foreach (var item in establecimientosTotales)
        //    {
        //        switch (id)
        //        {
        //            //Cemefir: 192.168.71.10
        //            case 15:
        //                ip = 192.168.71.10;
        //                break;

        //            //Rebasa: 172.46.1.10
        //            case 10:
        //                ip = 172.46.1.10;
        //                break;

        //            //Eizaguirre: 172.48.1.10
        //            case 11:
        //                ip = 172.48.1.10;
        //                break;

        //            //Germani: 172.28.1.220
        //            case 17:
        //                ip = 172.28.1.220;
        //                break;

        //            //Giovinazzo: 172.26.1.10
        //            case 9:
        //                ip = 172.26.1.10;
        //                break;

        //            //Niños: 172.29.1.100
        //            case 3:
        //                ip = 172.29.1.100;
        //                break;

        //            //Policlinico: 192.168.34.10
        //            case 4:
        //                ip = 192.168.34.10;
        //                break;

        //            //Sakamoto: 172.45.1.10
        //            case 8:
        //                ip = 172.45.1.10;
        //                break;

        //            //Salud Mental: 192.168.70.10
        //            case 14:
        //                ip = 192.168.70.10;
        //                break;
        //            default:
        //                break;
        //        }

        //        return (ip);
        //    }
        //}
    }
}