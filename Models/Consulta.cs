using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("consulta")]
    public class Consulta
    {
        [Key]
        [Column("id_consulta", TypeName = "INT")]
        public int ConsultaID { get; set; }


        [Column("id_expediente", TypeName = "INT")]
        public int ExpedienteID { get; set; }

        [Column("id_medico", TypeName = "INT")]
        public int MedicoID { get; set; }

        [Required]
        [Column("con_titulo", TypeName = "VARCHAR"), MaxLength(150)]     
        public String Titulo { get; set; }

        [Required]
        [Column("con_motivo_consulta", TypeName = "VARCHAR"), MaxLength(2500)]        
        public String MotivoConsulta { get; set; }

        [Required]
        [Column("con_detalles_medico", TypeName = "VARCHAR"), MaxLength(5000)]        
        public String DetallesMedico { get; set; }

        [Required]
        [Column("con_notas", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Notas { get; set; }

        [Required]
        [Column("con_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }
        
        public virtual Expediente Expediente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Estado Estado { get; set; }   
        public virtual Referencia Referencia { get; set; }
    }
}