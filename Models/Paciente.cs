using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("paciente")]
    public class Paciente
    {
        [Key]
        [Column("id_paciente", TypeName = "INT")]
        public int PacienteID { get; set; }

        [Required]
        [Column("pac_nombre", TypeName = "VARCHAR"), MaxLength(300)]        
        public String Nombre { get; set; }

        [Required]
        [Column("pac_apellido", TypeName = "VARCHAR"), MaxLength(300)]        
        public String Apellido { get; set; }

        [Required]
        [Column("pac_fecha_nacimiento", TypeName = "DATE")]
        public DateTime FechaNacimiento { get; set; }
        
        [Column("pac_telefono_casa", TypeName = "INT"), Range(1,13)]        
        public int TelefonoCasa { get; set; }
        
        [Required]
        [Column("pac_telefono_cel1", TypeName = "INT"), Range(1,13)]        
        public int TelefonoCel1 { get; set; }

        [Column("pac_telefono_cel2", TypeName = "INT"), Range(1,13)]        
        public int TelefonoCel2 { get; set; }

        [Required]
        [Column("pac_telefono_emergencia", TypeName = "INT"), Range(1, 13)]        
        public int TelefonoEmergencia { get; set; }

        [Required]
        [Column("pac_tipo_sangre", TypeName = "VARCHAR"), MaxLength(10)]        
        public String TipoSangre { get; set; }

        [Required]
        [Column("pac_estatura", TypeName = "VARCHAR"), MaxLength(45)]        
        public String Estatura { get; set; }

        [Required]
        [Column("pac_fecha_creacion", TypeName = "DATE")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("pac_direccion", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Direccion { get; set; }

        [Column("pac_nit", TypeName = "INT")]
        public int NIT { get; set; }

        [Column("id_genero", TypeName = "INT")]
        public int Genero { get; set; }

        [Column("id_profesion", TypeName = "INT")]
        public int Profesion { get; set; }

        [Column("id_estado", TypeName = "INT")]
        public int EstadoID { get; set; }

        public virtual tcGenero tcGenero { get; set; }
        public virtual tcProfesion tcProfesion { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Expediente Expediente { get; set; } 
    }
}