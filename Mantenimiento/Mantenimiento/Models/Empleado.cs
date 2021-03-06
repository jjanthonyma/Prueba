//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mantenimiento.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Empleado
    {
        
        public int idempleado { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellido")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Ingrese Dui")]
        public string dui { get; set; }
        
        public string direccion { get; set; }
        [Required]
        [Display(Name = "Ingrese Telefono")]
        public string telefono { get; set; }
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public Nullable<double> salario { get; set; }
        [Required]
        [Display(Name = "Ingrese Oficina")]
        public Nullable<int> idoficina { get; set; }
    
        public virtual Oficina Oficina { get; set; }
    }
}
