using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicosDirectivos.ViewModels
{
    public class VMProfesionalDesempeño
    {

        private Profesionales profesional;

        private string nomUsuario;



        private DateTime ultimoTurno;
        private DateTime ultimoLlamado;

        public enum diasSemana { lunes , martes, miercoles , jueves, viernes , sabado , domingo }
        

        public string nombreUsuario;
        public string nombre;
        public string apellido;

        public string dni;
        public string especialidad;
        public string matricula;
        public string ultimaConexion;

        public int cantidadTurnosReservados;
        public int cantidadTurnosEspontaneos;
        public int totalIngresos;
        public int totalAtendidos;

        public Dictionary<string, bool> diasAtencion;


        public VMProfesionalDesempeño(Usuarios usuario  , Profesionales profesional , List<Especialidades> lstEspecialidades)
        {
            this.apellido = profesional.primerApellido;
            this.profesional = profesional;
            if(Object.Equals(null , usuario.ultimoIngreso))
            {
                this.ultimaConexion = "El usuario no tiene conexiones";
            }
            else
            {
                this.ultimaConexion = ((DateTime)usuario.ultimoIngreso).ToShortDateString();
            }
            this.especialidad = string.Empty;

            foreach (Especialidades especialidad in lstEspecialidades)
            {
                this.especialidad += especialidad.nombre + " , ";
            }
            this.especialidad = this.especialidad.Substring(0, this.especialidad.Length - 2);

            this.matricula = profesional.matricula;
            this.nombre = profesional.primerNombre;
            this.nombreUsuario = usuario.nombreUsuario;
            this.dni = profesional.numeroDocumento;
        }



        public VMProfesionalDesempeño(Usuarios usuario, Profesionales profesional)
        {
            this.apellido = profesional.primerApellido;
            this.profesional = profesional;
            if (Object.Equals(null, usuario.ultimoIngreso))
            {
                this.ultimaConexion = "El usuario no tiene conexiones";
            }
            else
            {
                this.ultimaConexion = ((DateTime)usuario.ultimoIngreso).ToShortDateString();
            }
            this.especialidad = string.Empty;

            
            
                this.especialidad = "NONE";
            
            this.especialidad = this.especialidad.Substring(0, this.especialidad.Length - 2);

            this.matricula = profesional.matricula;
            this.nombre = profesional.primerNombre;
            this.nombreUsuario = usuario.nombreUsuario;
            this.dni = profesional.numeroDocumento;
        }

        public void ObtenerDiasAtencion(List<Evoluciones> evoluciones)
        {
            Dictionary<string, bool> diccionario = new Dictionary<string, bool>();
            
            diccionario.Add("domingo", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.domingo));
            diccionario.Add("lunes", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.lunes));
            diccionario.Add("martes", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.martes));
            diccionario.Add("miercoles", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.miercoles));
            diccionario.Add("jueves", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.jueves));
            diccionario.Add("viernes", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.viernes));
            diccionario.Add("sabado", ComprobarAtencionEnElDia(evoluciones, (int)diasSemana.sabado));

            this.diasAtencion = diccionario;
        }

        public bool ComprobarAtencionEnElDia(List<Evoluciones> evoluciones, int miDia)
        {

            if (evoluciones == null || evoluciones.Count == 0 || object.Equals(evoluciones, null))
                return false;

            foreach (Evoluciones evo in evoluciones)
            {
                //Comprobar datetime
                if (Object.Equals(evo.fechaCrea, null) || evo.fechaCrea == DateTime.MinValue)
                    continue;

                if (miDia == (int)evo.fechaCrea.DayOfWeek)
                    return true;
            }

            return false;
        }

    }
}