using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tratamiento")]
    public class Tratamiento
    {
        [Key]
        [Column("id_tratamiento", TypeName = "INT")]
        public int TratamientoID { get; set; }

        [Column("id_consulta", TypeName = "INT")]
        public int ConsultaID { get; set; }

        [Column("tra_descripcion", TypeName = "VARCHAR"), MaxLength(500)]
        public String Descripcion { get; set; }

        [Required]
        [Column("tra_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual List<TratamientoMedicamento> TratamientoMedicamentos { get; set; }
        public virtual Estado Estado { get; set; }
    }
}