using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tratamiento_medicamento")]
    public class TratamientoMedicamento
    {
        [Key]
        [Column("id_tratamiento_medicamento", TypeName = "INT")]
        public int TratamientoMedicamentoID { get; set; }

        [Column("id_tratamiento", TypeName = "INT")]
        public int TratamientoID { get; set; }

        [Column("id_medicamento", TypeName = "INT")]
        public int MedicamentoID { get; set; }

        [Required]
        [Column("trm_cantidad", TypeName = "INT")]
        public int Cantidad { get; set; }

        [Required]
        [Column("trm_receta", TypeName = "VARCHAR"), MaxLength(500)]
        public String Receta { get; set; }

        [Required]
        [Column("trm_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual Tratamiento Tratamiento { get; set; }
        public virtual tcMedicamento tcMedicamento { get; set; }
        public virtual Estado Estado { get; set; }

    }
}