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
    
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            this.Atenciones = new HashSet<Atenciones>();
            this.Turno_Historicos = new HashSet<Turno_Historicos>();
            this.TurnosReserva = new HashSet<TurnosReserva>();
        }
    
        public System.Guid id { get; set; }
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public int idSexo { get; set; }
        public string primerApellido { get; set; }
        public string primerNombre { get; set; }
        public string otrosNombres { get; set; }
        public string primerApellidoMaterno { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public Nullable<System.DateTime> fechaObito { get; set; }
        public string observaciones { get; set; }
        public bool denunciado { get; set; }
        public string grupoSanguineo { get; set; }
        public Nullable<int> idEtnia { get; set; }
        public string estado { get; set; }
        public Nullable<System.Guid> idUltimoPacienteDomicilio { get; set; }
        public Nullable<System.Guid> idUltimoPacienteContacto { get; set; }
        public Nullable<System.Guid> idUltimoPacienteCorreoElectronico { get; set; }
        public Nullable<System.Guid> idUltimoPacienteNivelInstruccion { get; set; }
        public Nullable<System.Guid> idUltimoPacienteSituacionLaboral { get; set; }
        public Nullable<System.Guid> idUltimoPacienteNacionalidad { get; set; }
        public Nullable<System.Guid> idUltimoPacienteEstadoCivil { get; set; }
        public string usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public string usuarioModi { get; set; }
        public System.DateTime fechaModi { get; set; }
        public Nullable<int> idTipoDocumentoMaterno { get; set; }
        public string numeroDocumentoMaterno { get; set; }
        public string nombresMaterno { get; set; }
        public Nullable<System.Guid> idDniFrente { get; set; }
        public Nullable<System.Guid> idDniDorso { get; set; }
        public Nullable<int> idGenero { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atenciones> Atenciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turno_Historicos> Turno_Historicos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurnosReserva> TurnosReserva { get; set; }
    }
}
