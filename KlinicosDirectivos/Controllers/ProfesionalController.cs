using KlinicosDirectivos.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlinicosDirectivos.Controllers
{
    public class ProfesionalController : Controller
    {
        // GET: Profesional
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetalleProfesional(int idProfesional)
        {
            DateTime  hasta = DateTime.Now;
            DateTime desde = DateTime.Now.AddDays(-7);

            Klinicos_BEntities entidades = Repositorio.CrearEntityFramework();
            Profesionales profesional = entidades.Profesionales.Where(x => x.id == idProfesional && x.vigente == true).FirstOrDefault();
            /*List<Especialidades> especialidades = entidades.Especialidades
                .Join(entidades.ProfesionalesEspecialidades, e => e.id, pe => pe.idEspecialidad, (e, pe) => new { especialidad = e, profesional = pe.idProfesional })
                .Where(x => x.profesional == idProfesional)
                .Select(x => x.especialidad).ToList();*/

            var especialidades = entidades.SP_ESPECIALIDADES_X_PROFESIONAL((int?)idProfesional).ToList();
            

            Usuarios usuario = entidades.Usuarios.Where(x => x.idProfesional == idProfesional).FirstOrDefault();
            //var turnosIngresados = entidades.Turno.Join(entidades.Atenciones, t => t.Id, a => a.idTurno, (t, a) => new { atencion = a, idprofe = t.AtendidoPorRefId }).Where(x => x.idprofe == idProfesional).Count();
            //  var ultimoTurno = turnosReservados.OrderByDescending(x => x.Turno.FechaYHora).Select(x => x.Turno).FirstOrDefault();
            //var Ultimasatenciones = entidades.AtencionesEstados.Where(x => x.idProfesionalDestino == idProfesional).OrderByDescending(x => x.llamadosUltimaFechayHora).FirstOrDefault();


            var turnosReservados = entidades.TurnosReserva.Where(x => x.Turno.AtendidoPorRefId == idProfesional && (x.Turno.FechaYHora > desde && x.Turno.FechaYHora < hasta  )).Count(); //Reservas de hoy en adelante
            var turnosHistoricos = entidades.Turno_Historicos.Where(x => x.AtendidoPorRefId == idProfesional && (x.FechaYHora > desde && x.FechaYHora < hasta)).Count(); // Reservas en el historico
            int cantidadTurnosReservados = turnosReservados + turnosHistoricos; // Usar esta variable en la vista

            var cantidadturnosEspontaneos = entidades.AtencionesEstados.Where(x => x.idProfesionalDestino == idProfesional && (x.Atenciones.idTurno.Equals(null) || x.Atenciones.idTurno == 0) && ( x.fechaCrea > desde && x.fechaCrea < hasta )).Count();

            var ingresosXProfesional = entidades.AtencionesEstados.Where(x => x.idProfesionalDestino == idProfesional && (x.fechaCrea > desde && x.fechaCrea< hasta));

            var evolucionesXProfesional = entidades.Evoluciones.Where(x => x.idProfesional == idProfesional && (x.fechaCrea> desde && x.fechaCrea< hasta));

            VMProfesionalDesempeño viewModel = new VMProfesionalDesempeño(usuario , profesional , especialidades);
            viewModel.cantidadTurnosEspontaneos = cantidadturnosEspontaneos;
            viewModel.cantidadTurnosReservados = cantidadTurnosReservados;
            viewModel.totalAtendidos = evolucionesXProfesional.Count();
            viewModel.totalIngresos = ingresosXProfesional.Count();

            viewModel.ObtenerDiasAtencion(evolucionesXProfesional.ToList());
            return View(viewModel);
        }

        private bool EntreFechas(DateTime fechaYHora, DateTime desde, DateTime hasta)
        {
            return fechaYHora > desde && fechaYHora < hasta;
        }


        private List<SemanalProfesional> CastearASemanales(IEnumerable<AtencionesEstados> listaAtenciones, IEnumerable<Evoluciones> listaEvoluciones)
        {
            return new List<SemanalProfesional>();
        }

        public int MyProperty { get; set; }






        public ActionResult Default(DetalleSemanalPartialVM model)
        {
            int idEstablecimiento = 3;
            Reportes reporte = null;
            ReportesEspecialidades reporteEspecialidad = null;
            DataSet dataset;
            Klinicos_BEntities modelo = new Klinicos_BEntities();
            reporteEspecialidad = modelo.ReportesEspecialidades.Where(x => x.idEspecialidad == model.idEspecialidad).FirstOrDefault();
            string sp = reporteEspecialidad == null ? "[Atencion].[RegistroDiarioGeneral_entrefechas_multisets]" : reporteEspecialidad.storeProcedure;

            dataset = getRegistroDiarioDataSet(
                    sp,
                    model.fechadesde,
                    model.fechaHasta,
                    model.mes,
                    model.anio,
                    model.mesHasta,
                    model.anioHasta,
                    model.idSector,
                    model.idEspecialidad,
                    model.idProfesional,
                    model.tipoEspecialidad,
                    idEstablecimiento
                );

            if (dataset == null)
            {
                //Error("No Existen datos que informar");
                return View(model);
            }
            else
            {


                DataTable dtHeader1 = dataset.Tables[0];
                int leftMargin = 10;
                int bottomMargin = 10;
                int rightMargin = 10;
                int topMargin = 10;
                int.TryParse(reporte.pageMarginsLeft, out leftMargin);
                int.TryParse(reporte.pageMarginsBottom, out bottomMargin);
                int.TryParse(reporte.pageMarginsRight, out rightMargin);
                int.TryParse(reporte.pageMarginsTop, out topMargin);

                return new ViewAsPdf(reporteEspecialidad == null ? reporte.defaultHtml : reporteEspecialidad.html, dataset)
                {
                    FileName = reporte.nombre.Replace(" ", "_") + DateTime.Now.ToShortDateString().Replace("/", "_") + ".pdf",
                    PageOrientation = reporte.pageOrientation == "Landscape" ? Rotativa.Options.Orientation.Landscape : Rotativa.Options.Orientation.Portrait,
                    PageSize = reporte.pageSize == "A4" ? Rotativa.Options.Size.A4 : Rotativa.Options.Size.Legal,
                    PageMargins = { Left = leftMargin, Bottom = bottomMargin, Right = rightMargin, Top = topMargin },
                    CustomSwitches = "--footer-left \"Generado el : " + DateTime.Now.Date.ToString("MM/dd/yyyy") + "  Página: [page]/[toPage]\"" + " --footer-font-size \"10\" --footer-spacing 2 --footer-font-name \"calibri light\""
                };

                //else if (model.formato == "EXCEL")
                //{
                //    Response.AddHeader("content-disposition", "attachment;filename=" + reporte.nombre.Replace(" ", "_") + '_' + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls");
                //    Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                //    return View("~/Views/Reporte/reporte_excel_multiResultSets.cshtml", dataset);
                //}
            }
        }








        public DataSet getRegistroDiarioDataSet(string storeProcedure, DateTime? fecha, DateTime? fechaHasta, string mes, string anio, string mesHasta, string anioHasta, int? idSector, int? idEspecialidad, int? idProfesional, string tipoEspecialidad, int idEstablecimiento)
        {

            SqlConnection con = new SqlConnection(@"data source = 127.0.0.1; initial catalog = KLINICOS; persist security info = True; user id = sa; password = sql2018 *; MultipleActiveResultSets = True; App = EntityFramework");
            DataSet dst = new DataSet();
            SqlCommand cmd = new SqlCommand(storeProcedure, con);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha == null ? SqlDateTime.Null : (DateTime)fecha;
            cmd.Parameters.Add("@fechahasta", SqlDbType.DateTime).Value = fechaHasta == null ? SqlDateTime.Null : (DateTime)fechaHasta;
            cmd.Parameters.Add("@mes", SqlDbType.VarChar).Value = string.IsNullOrEmpty(mes) ? SqlString.Null : mes;
            cmd.Parameters.Add("@anio", SqlDbType.VarChar).Value = string.IsNullOrEmpty(anio) ? SqlString.Null : anio;
            cmd.Parameters.Add("@mesHasta", SqlDbType.VarChar).Value = string.IsNullOrEmpty(mesHasta) ? SqlString.Null : mesHasta;
            cmd.Parameters.Add("@anioHasta", SqlDbType.VarChar).Value = string.IsNullOrEmpty(anioHasta) ? SqlString.Null : anioHasta;
            cmd.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
            cmd.Parameters.Add("@idSector", SqlDbType.Int).Value = idSector == null ? SqlInt32.Null : (int)idSector;
            cmd.Parameters.Add("@idEspecialidad", SqlDbType.Int).Value = idEspecialidad == null ? SqlInt32.Null : (int)idEspecialidad;
            cmd.Parameters.Add("@idProfesional", SqlDbType.Int).Value = idProfesional == null ? SqlInt32.Null : (int)idProfesional;
            cmd.Parameters.Add("@tipoEspecialidad", SqlDbType.VarChar).Value = string.IsNullOrEmpty(tipoEspecialidad) ? SqlString.Null : tipoEspecialidad;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dst);
            return dst;
        }


        


    }
}