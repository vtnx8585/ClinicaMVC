using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tc_alergia")]
    public class tcAlergia
    {
        [Key]
        [Column("id_alergia", TypeName = "INT")]
        public int tcAlergiaID { get; set; }

        [Required]
        [Column("ale_nombre", TypeName = "VARCHAR"), MaxLength(100)]
        public String Nombre { get; set; }

        [Column("ale_descripcion", TypeName = "VARCHAR"), MaxLength(250)]
        public String Descripcion { get; set; }

        [Required]
        [Column("ale_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual List<AlergiaExpediente> AlergiaExpedientes { get; set; }
        public virtual Estado Estado { get; set; }

    }
}