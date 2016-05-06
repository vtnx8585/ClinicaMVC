using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tc_laboratorio")]
    public class tcLaboratorio
    {
        [Key]
        [Column("id_laboratorio", TypeName = "INT")]
        public int tcLaboratorioID { get; set; }

        [Required]
        [Column("lab_nombre", TypeName = "VARCHAR"), MaxLength(150)]
        public String Nombre { get; set; }

        [Required]
        [Column("lab_descripcion", TypeName = "VARCHAR"), MaxLength(250)]
        public String Descripcion { get; set; }

        [Required]
        [Column("lab_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual List<ExamenLaboratorio> ExamenLaboratorios { get; set; }
        public virtual Estado Estado { get; set; }
    }
}