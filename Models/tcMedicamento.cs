using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tc_medicamento")]
    public class tcMedicamento
    {
        [Key]
        [Column("id_medicamento", TypeName = "INT")]
        public int tcMedicamentoID { get; set; }

        [Required]
        [Column("med_nombre", TypeName = "VARCHAR"), MaxLength(250)]
        public String Nombre { get; set; }

        [Column("med_descripcion", TypeName = "VARCHAR"), MaxLength(250)]
        public String Descripcion { get; set; }

        [Required]
        [Column("med_presentacion", TypeName = "VARCHAR"), MaxLength(250)]
        public String Presentacion { get; set; }

        [Required]
        [Column("med_medida", TypeName = "INT")]
        public int Medida { get; set; }

        [Column("id_unidad_medida", TypeName = "INT")]
        public int tcUnidadMedidaID { get; set; }

        [Required]
        [Column("med_alerta_minimo", TypeName = "INT")]
        public int AlertaMinimo { get; set; }

        [Required]
        [Column("med_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual List<TratamientoMedicamento> TratamientoMedicamentos { get; set; }
        public virtual tcUnidadMedida tcUnidadMedida { get; set; }
        public virtual Estado Estado { get; set; }

    }
}