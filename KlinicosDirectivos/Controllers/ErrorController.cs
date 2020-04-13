using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlinicosDirectivos.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int error = 0 )
        {
            string desc = (string)Session["desc"];

            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    ViewBag.DescripcionAdicional = desc;
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    ViewBag.DescripcionAdicional = desc;
                    break;

                default:
                    ViewBag.Title = "Eror en la aplicacion";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    ViewBag.DescripcionAdicional = desc;
                    break;
            }

            return View("~/views/Shared/Error.cshtml");
        }
    }
}