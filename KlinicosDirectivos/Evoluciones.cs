//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KlinicosDirectivos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evoluciones
    {
        public System.Guid id { get; set; }
        public System.Guid idProblemaSalud { get; set; }
        public int idProfesional { get; set; }
        public int idEspecialidad { get; set; }
        public int idEstablecimiento { get; set; }
        public Nullable<System.Guid> idAtencion { get; set; }
        public string usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public int idSector { get; set; }
        public Nullable<System.Guid> idAtencionesEstados { get; set; }
    
        public virtual Atenciones Atenciones { get; set; }
        public virtual AtencionesEstados AtencionesEstados { get; set; }
        public virtual Especialidades Especialidades { get; set; }
        public virtual Establecimientos Establecimientos { get; set; }
        public virtual Profesionales Profesionales { get; set; }
        public virtual EvolucionesSM EvolucionesSM { get; set; }
        public virtual EvolucionesSOAP EvolucionesSOAP { get; set; }
    }
}
