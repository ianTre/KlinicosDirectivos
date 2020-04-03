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
    
    public partial class AtencionesEstados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AtencionesEstados()
        {
            this.Evoluciones = new HashSet<Evoluciones>();
        }
    
        public System.Guid id { get; set; }
        public System.Guid idAtencion { get; set; }
        public int idAtencionEstado { get; set; }
        public Nullable<int> idProfesionalDestino { get; set; }
        public int idEspecialidadDestino { get; set; }
        public string estado { get; set; }
        public string usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public string motivoDerivacion { get; set; }
        public string tipoRegistro { get; set; }
        public Nullable<int> llamadosCantidad { get; set; }
        public Nullable<System.DateTime> llamadosUltimaFechayHora { get; set; }
        public string llamadosPuestoTrabajoNombre { get; set; }
        public string sectorOrigenNombre { get; set; }
        public Nullable<int> idProfesionalOrigen { get; set; }
        public Nullable<int> idEspecialidadOrigen { get; set; }
        public string sectorDestinoNombre { get; set; }
        public string puestoTrabajoNombre { get; set; }
        public bool conPrioridad { get; set; }
        public string usuarioFinaliza { get; set; }
        public Nullable<System.DateTime> fechaFinaliza { get; set; }
    
        public virtual Atenciones Atenciones { get; set; }
        public virtual Especialidades Especialidades { get; set; }
        public virtual Especialidades Especialidades1 { get; set; }
        public virtual Profesionales Profesionales { get; set; }
        public virtual Profesionales Profesionales1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evoluciones> Evoluciones { get; set; }
    }
}
