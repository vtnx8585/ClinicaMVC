using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tc_profesion")]
    public class tcProfesion
    {
        [Key]
        [Column("id_profesion", TypeName = "INT")]
        public int tcProfesionID { get; set; }

        [Required]
        [Column("pro_nombre", TypeName = "VARCHAR"), MaxLength(100)]
        public String Nombre { get; set; }

        [Column("pro_descripcion", TypeName = "VARCHAR")]
        public String Descripcion { get; set; }

        [Required]
        [Column("pro_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual List<Paciente> Pacientes { get; set; }
        public virtual Estado Estado { get; set; }
    }
}