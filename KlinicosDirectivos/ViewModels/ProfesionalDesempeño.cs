using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicosDirectivos.ViewModels
{
    public class ProfesionalDesempeño
    {

        Profesionales profesional;
        List<Especialidades> especialidad;

        string nomUsuario;
        DateTime ultimaConexion;

        

        DateTime ultimoTurno;
        DateTime ultimoLlamado;

        enum diasSemana { lunes , martes, miercoles , jueves, viernes , sabado , domigno }
        Dictionary<diasSemana, bool> diasAtencion;

    }
}