using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("institucion_referencia")]
    public class InstitucionReferencia
    {
        [Key]
        [Column("id_institucion_referencia", TypeName = "INT")]
        public int InstitucionReferenciaID { get; set; }

        [Required]
        [Column("inr_nombre_institucion", TypeName = "VARCHAR"), MaxLength(250)]        
        public String NombreInstitucion { get; set; }

        [Required]
        [Column("inr_direccion", TypeName = "VARCHAR"), MaxLength(250)]        
        public String Direccion { get; set; }

        [Required]
        [Column("inr_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual List<Referencia> Referencias { get; set; }
        public virtual List<OrdenLaboratorio> OrdenLaboratorios { get; set; }
    }
}