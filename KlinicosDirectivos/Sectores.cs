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
    
    public partial class Sectores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sectores()
        {
            this.Sectores1 = new HashSet<Sectores>();
            this.UsuariosSectores = new HashSet<UsuariosSectores>();
            this.ConfiguracionAgenda = new HashSet<ConfiguracionAgenda>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string nombreAbreviado { get; set; }
        public int orden { get; set; }
        public string tipo { get; set; }
        public bool vigente { get; set; }
        public string usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public string usuarioModi { get; set; }
        public System.DateTime fechaModi { get; set; }
        public Nullable<int> idSectorPadre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sectores> Sectores1 { get; set; }
        public virtual Sectores Sectores2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosSectores> UsuariosSectores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfiguracionAgenda> ConfiguracionAgenda { get; set; }
    }
}
