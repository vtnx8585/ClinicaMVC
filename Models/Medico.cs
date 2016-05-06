using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("medico")]
    public class Medico
    {
        [Key]
        [Column("id_medico", TypeName = "INT")]
        public int MedicoID { get; set; }

        [Required]
        [Column("med_nombre", TypeName = "VARCHAR")]
        [MaxLength(250)]        
        public String Nombre { get; set; }

        //[Required(ErrorMessage= "Ingresar Numero de Casa")]
        [Required]
        [Column("med_telefono", TypeName = "INT"), Range(0, 13)]        
        public int Telefono { get; set; }
        
        [Column("med_cel1", TypeName = "INT"), Range(0, 13)]        
        public int Celular { get; set; }

        [Required]
        [Column("med_especializacion",TypeName = "VARCHAR"), MaxLength(250)]        
        public String Especializacion { get; set; }

        [Required]
        [Column("med_area", TypeName = "VARCHAR"), MaxLength(150)]        
        public String Area { get; set; }

        [Required]
        [Column("med_numero_colegiado", TypeName = "INT"), MinLength(1)]        
        public int NumeroColegiado { get; set; }

        [Required]
        [Column("med_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual List<Consulta> Consultas { get; set; }
        public virtual List<Referencia> Referencias { get; set; }
        public virtual List<TratamientoMedicamento> TratamientoMedicamentos { get; set; }
    }
}