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
    
    public partial class Profesionales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesionales()
        {
            this.AtencionesEstados = new HashSet<AtencionesEstados>();
        }
    
        public int id { get; set; }
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public int idSexo { get; set; }
        public string primerApellido { get; set; }
        public string primerNombre { get; set; }
        public string otrosNombres { get; set; }
        public string tipoTelefono { get; set; }
        public string telefono { get; set; }
        public string contactoObservaciones { get; set; }
        public string email { get; set; }
        public string matricula { get; set; }
        public bool vigente { get; set; }
        public string usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public string usuarioModi { get; set; }
        public System.DateTime fechaModi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionesEstados> AtencionesEstados { get; set; }
    }
}