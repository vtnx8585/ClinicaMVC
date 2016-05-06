using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMVC.Models
{
    [Table("examen_fisico")]
    public class ExamenFisico
    {
        [Key]
        [Column("id_estado_fisico", TypeName = "INT")]
        public int ExamenFisicoID { get; set; }

        [Column("id_consulta", TypeName = "INT")]
        public int ConsultaID { get; set; }

        [Column("exf_estado_general", TypeName = "VARCHAR"), MaxLength(500)]        
        public String EstadoGeneral { get; set; }

        [Column("exf_peso", TypeName = "DECIMAL")]
        public Decimal Peso { get; set; }

        [Column("exf_presion_arterial", TypeName = "VARCHAR"), MaxLength(45)]        
        public String PresionArterial { get; set; }

        [Column("exf_piel", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Piel { get; set; }

        [Column("exf_cabeza", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Cabeza { get; set; }

        [Column("exf_ojos_oidos", TypeName = "VARCHAR"), MaxLength(500)]        
        public String OjosOios { get; set; }

        [Column("exf_nariz_boca", TypeName = "VARCHAR"), MaxLength(500)]        
        public String NarizBoca { get; set; }

        [Column("exf_cuello", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Cuello { get; set; }

        [Column("exf_torax_anterior", TypeName = "VARCHAR"), MaxLength(500)]        
        public String ToraxAnterior { get; set; }

        [Column("exf_corazon", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Corazon { get; set; }

        [Column("exf_pulmones", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Pulmones { get; set; }

        [Column("exf_abdomen", TypeName = "VARCHAR"), MaxLength(500)]       
        public String Abdomen { get; set; }

        [Column("exf_genitales", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Genitales { get; set; }

        [Column("exf_extremidades", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Extremidades { get; set; }

        [Column("exf_dorso_raquis", TypeName = "VARCHAR"), MaxLength(500)]        
        public String DorsoRaquis { get; set; }

        [Column("exf_ginecologico", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Ginecologico { get; set; }

        [Column("exf_neurologica", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Neurologica { get; set; }

        [Column("exf_pulso", TypeName = "VARCHAR"), MaxLength(500)]        
        public String Pulso { get; set; }

        [Required]
        [Column("exf_fecha_creacion", TypeName = "VARCHAR"), MaxLength(500)]        
        public String FechaCreacion { get; set; }

        public virtual Consulta Consulta { get; set; }
    }
}