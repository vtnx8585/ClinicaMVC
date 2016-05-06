using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("orden_laboratorio")]
    public class OrdenLaboratorio
    {
        [Key]
        [Column("id_orden_laboratorio", TypeName = "INT")]
        public int OrdenLaboratorioID { get; set; }

        [Column("id_consulta", TypeName = "INT")]
        public int ConsultaID { get; set; }

        [Column("id_institucion_referencia", TypeName = "INT")]
        public int InstitucionReferenciaID { get; set; }

        [Column("orl_descripcion", TypeName = "VARCHAR")]
        [MaxLength(500)]
        public String Descripcion { get; set; }

        [Required]
        [Column("orl_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        [ForeignKey("EstadoID")]
        public virtual Estado Estado { get; set; }

        [ForeignKey("ConsultaID")]
        public virtual Consulta Consulta { get; set; }

        [ForeignKey("InstitucionReferenciaID")]
        public virtual InstitucionReferencia InstitucionReferencia { get; set; }
    }
}