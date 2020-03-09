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
    
    public partial class PlanillaDiaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanillaDiaria()
        {
            this.Turno = new HashSet<Turno>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.TimeSpan HoraDesde { get; set; }
        public System.TimeSpan HoraHasta { get; set; }
        public int EstadoRefId { get; set; }
        public int ConfiguracionAgendaRefId { get; set; }
    
        public virtual ConfiguracionAgenda ConfiguracionAgenda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turno> Turno { get; set; }
    }
}