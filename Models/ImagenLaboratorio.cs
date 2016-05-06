using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("imagen_laboratorio")]
    public class ImagenLaboratorio
    {
        [Key]
        [Column("id_imagen_laboratorio", TypeName = "INT")]
        public int ImagenLaboratorioID { get; set; }

        [Column("id_orden_laboratorio", TypeName = "INT")]
        public int OrdenLaboratorioID { get; set; }

        [Column("iml_imagen_path", TypeName = "VARCHAR"), MaxLength(250)]        
        public String ImagenPath { get; set; }

        [Column("iml_descripcion", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Descripcion { get; set; }

        [Column("iml_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual OrdenLaboratorio OrdenLaboratorio { get; set; }
        public virtual Estado Estado { get; set; }
    }
}