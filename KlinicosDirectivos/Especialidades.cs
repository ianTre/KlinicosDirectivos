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
    
    public partial class Especialidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialidades()
        {
            this.AtencionesEstados = new HashSet<AtencionesEstados>();
            this.AtencionesEstados1 = new HashSet<AtencionesEstados>();
            this.Evoluciones = new HashSet<Evoluciones>();
            this.Profesionales = new HashSet<Profesionales>();
            this.ReportesEspecialidades = new HashSet<ReportesEspecialidades>();
        }
    
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public bool vigente { get; set; }
        public string tipoEspecialidad { get; set; }
        public string usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public string usuarioModi { get; set; }
        public System.DateTime fechaModi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionesEstados> AtencionesEstados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionesEstados> AtencionesEstados1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evoluciones> Evoluciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesionales> Profesionales { get; set; }
        public virtual EspecialidadesDisponibles EspecialidadesDisponibles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportesEspecialidades> ReportesEspecialidades { get; set; }
    }
}
