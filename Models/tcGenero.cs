using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tc_genero")]
    public class tcGenero
    {
        [Key]
        [Column("id_genero", TypeName = "INT")]
        public int tcGeneroID { get; set; }

        [Required]
        [Column("gen_nombre", TypeName = "VARCHAR"), MaxLength(45)]
        public String Nombre { get; set; }

        [Required]
        [Column("gen_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual List<Paciente> Pacientes { get; set; }
        public virtual Estado Estado { get; set; }
    }
}