
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
    
public partial class EvolucionesSM
{

    public System.Guid id { get; set; }

    public string anamnesis { get; set; }

    public string notasPropias { get; set; }

    public Nullable<int> idSNOMed { get; set; }

    public string diagnosticoDetalle { get; set; }

    public string tratamiento { get; set; }

    public Nullable<System.DateTime> fechaProximaConsulta { get; set; }

    public string notasPropiasCompartirCon { get; set; }

    public bool orientacion { get; set; }

    public string tipoEntrevista { get; set; }



    public virtual Evoluciones Evoluciones { get; set; }

}

}
