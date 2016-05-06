using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaMVC.Models
{
    [Table("tc_unidad_medida")]
    public class tcUnidadMedida
    {
        [Key]
        [Column("id_unidad_medida", TypeName = "INT")]
        public int tcUnidadMedidaID { get; set; }

        [Required]
        [DisplayName("Unidad Medida")]
        [Column("unm_nombre", TypeName = "VARCHAR"), MaxLength(50)]
        public String Nombre { get; set; }

        [Column("unm_descripcion", TypeName = "VARCHAR"), MaxLength(250)]
        public String Descripcion { get; set; }

        [Required]
        [Column("unm_fecha_crecion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual List<tcMedicamento> tcMedicamentos { get; set; }
    }
}