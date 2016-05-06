using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("expediente")]
    public class Expediente
    {
        // para crear la relacion one-to-one entre Paciente y Expediente de manera correcta
        //[Key,ForeignKey("PacienteID")]
        //[Column("id_paciente", TypeName = "INT")]
        //public int PacienteID { get; set; }        
        [Key]
        [Column("id_expediente", TypeName = "INT")]
        public int ExpedienteID { get; set; }

        [Column("id_paciente", TypeName = "INT")]
        public int PacienteID { get; set; }

        [Column("exp_foto_path", TypeName = "VARCHAR"), MaxLength(250)]        
        public String FotoPath { get; set; }
        
        [Column("exp_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        //Esta relacion es redundante
        //[Column("id_estado", TypeName = "INT")]
        //public int EstadoID { get; set; }
        //public virtual Estado Estado { get; set; }

        public virtual Paciente Paciente { get; set; }
        
    }
}