using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("alergia_expediente")]
    public class AlergiaExpediente
    {
         [Key]
         [Column("id_alergia_expediente", TypeName = "INT")]         
         public int AlergiaExpedienteID { get; set; }

         [Column("id_alergia", TypeName = "INT")]         
         public int tcAlergiaID { get; set; }

         [Column("id_expediente", TypeName = "INT")]         
         public int ExpedienteID { get; set; }

         [Required]
         [Column("ale_fecha_creacion", TypeName = "DATE")]         
         public DateTime FechaCreacion { get; set; }

         [Column("id_estado", TypeName = "INT")]         
         public int EstadoID { get; set; }
         
         public virtual Expediente Expediente { get; set; }
         public virtual tcAlergia tcAlergia { get; set; }
         public virtual Estado Estado { get; set; }                  
    }
}