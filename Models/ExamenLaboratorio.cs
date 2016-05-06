using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("examen_laboratorio")]
    public class ExamenLaboratorio
    {
        [Key]
        [Column("id_examen_laboratorio", TypeName = "INT")]        
        public int ExamenLaboratorioID { get; set; }

        [Column("id_orden_laboratorio", TypeName = "INT")]        
        public int OrdenLaboratorioID { get; set; }

        [Column("id_tipo_laboratorio", TypeName = "INT")]
        public int tcLaboratorioID { get; set; }

        [Column("exl_descripcion", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Descripcion { get; set; }

        [Required]
        [Column("exl_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual OrdenLaboratorio OrdenLaboratorio { get; set; }
        public virtual tcLaboratorio tcLaboratorio { get; set; }
        public virtual Estado Estado { get; set; }
    }
}