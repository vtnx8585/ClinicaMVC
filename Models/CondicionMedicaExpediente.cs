using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("condicion_medica_expediente")]
    public class CondicionMedicaExpediente
    {
        [Key]
        [Column("id_condicion_medica_expediente", TypeName = "INT")]        
        public int CondicionMedicaExpedienteID { get; set; }

        [Column("id_expediente", TypeName = "INT")]       
        public int ExpedienteID { get; set; }

        [Column("id_enfermedad", TypeName = "INT")]        
        public int EnfermedadID { get; set; }

        [Required]
        [Column("cme_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }
        
        public virtual Expediente Expediente { get; set; }
        public virtual Estado Estado { get; set; }        
        public virtual tcEnfermedad tcEnfermedad { get; set; }
    }
}