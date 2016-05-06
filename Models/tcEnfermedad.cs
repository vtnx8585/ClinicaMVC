using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("tc_enfermedad")]
    public class tcEnfermedad
    {
        [Key]
        [Column("id_enfermedad", TypeName = "INT")]
        public int tcEnfermedadID { get; set; }

        [Required]
        [Column("enf_nombre", TypeName = "VARCHAR"), MaxLength(150)]
        public String Nombre { get; set; }

        [Column("enf_descripcion", TypeName = "VARCHAR"), MaxLength(150)]
        public String Descripcion { get; set; }

        [Required]
        [Column("enf_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual List<CondicionMedicaExpediente> CondicionMedicaExpedientes { get; set; }

    }
}