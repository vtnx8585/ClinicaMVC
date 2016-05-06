using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("referencia")]
    public class Referencia
    {
        [Column("id_referencia", TypeName = "INT")]
        public int ReferenciaID { get; set; }

        [Column("id_consulta", TypeName = "INT")]
        public int ConsultaID { get; set; }

        [Column("id_institucion_referencia", TypeName = "INT")]
        public int InstitucionReferenciaID { get; set; }

        [Column("ref_traslado_emergencia", TypeName = "INT")]
        public int TrasladoEmergencia { get; set; }

        [Required]
        [Column("id_medico", TypeName = "INT")]
        public int MedicoID { get; set; }

        [Required]
        [Column("ref_motivo_referencia", TypeName = "VARCHAR"), MaxLength(500)]
        public String MotivoReferencia { get; set; }

        [Required]
        [Column("ref_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        public virtual Consulta Consulta { get; set; }
        public virtual InstitucionReferencia InstitucionReferencia { get; set; }        
        public virtual Medico Medico { get; set; }
        
    }
}