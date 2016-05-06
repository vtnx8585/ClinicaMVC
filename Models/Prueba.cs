using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("prueba")]
    public class Prueba
    {
        [Key]
        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        [Required]
        [Column("est_nombre", TypeName = "VARCHAR"), MaxLength(45)]
        public String Nombre { get; set; }
    }
}