using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClinicaMVC.Models
{
    public class ClinicaMedicaDataLayer: DbContext
    {
        public ClinicaMedicaDataLayer()
            : base("name=ClinicaMedicaDataLayer")
        {
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClinicaMedicaDataLayer, ClinicaMedicaCodeFirst.Migrations.Configuration>("ClinicaMedicaDataLayer"));
            //Database.SetInitializer(new DropCreateDatabaseAlways<ClinicaMedicaDataLayer>());
        }

        //public ClinicaMedicaDataLayer(): base("name=ClinicaMedicaDataLayer"){}

        public DbSet<AlergiaExpediente> AlergiaExpedientes { get; set; }
        public DbSet<CondicionMedicaExpediente> CondicionMedicaExpedientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<ExamenFisico> ExamenFisicos { get; set; }
        public DbSet<ExamenLaboratorio> ExamenLaboratorios { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<ImagenLaboratorio> ImagenLaboratorios { get; set; }
        public DbSet<InstitucionReferencia> InstitucionReferencias { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<OrdenLaboratorio> OrdenLaboratorios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Referencia> Referencias { get; set; }
        public DbSet<tcAlergia> tcAlergias { get; set; }
        public DbSet<tcEnfermedad> tcEnfermedades { get; set; }
        public DbSet<tcGenero> tcGeneros { get; set; }
        public DbSet<tcLaboratorio> tcLaboratorios { get; set; }
        public DbSet<tcMedicamento> tcMedicamentos { get; set; }
        public DbSet<tcProfesion> tcProfesiones { get; set; }
        public DbSet<tcUnidadMedida> tcUnidadMedidas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<TratamientoMedicamento> TratamientoMedicamentos { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }

        //Esto se utiliza cuando se quiere hacer especificaciones especiales a las clases de dominio. Aqui se afecta el mapping de las clases de dominio code first.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Expediente>()
                .HasRequired(ad => ad.Paciente).WithOptional(s => s.Expediente);

            modelBuilder.Entity<Referencia>()
                .HasRequired(c => c.Consulta).WithOptional(r => r.Referencia);

            //Este se utiliza para quitar toda las conveciones de entidad referencial en cascada de la base de datos, no es recomendable. 
            //Utiliza la libreria using System.Data.Entity.ModelConfiguration.Conventions
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Cuando se necesita eliminar un cycles or multiple cascade paths.
            //modelBuilder.Entity<Referencia>().HasRequired(m => m.Medico).WithMany(r => r.Referencias).WillCascadeOnDelete(false);
            modelBuilder.Entity<InstitucionReferencia>().HasRequired(e => e.Estado).WithMany(i => i.InstitutoReferencias).WillCascadeOnDelete(false);
            modelBuilder.Entity<OrdenLaboratorio>().HasRequired(e => e.Estado).WithMany(o => o.OrdenLaboratorios).WillCascadeOnDelete(false);
            modelBuilder.Entity<tcUnidadMedida>().HasRequired(e => e.Estado).WithMany(t => t.tcUnidadMedidas).WillCascadeOnDelete(false);
            modelBuilder.Entity<Tratamiento>().HasRequired(e => e.Estado).WithMany(t => t.Tratamientos).WillCascadeOnDelete(false);
            modelBuilder.Entity<ExamenLaboratorio>().HasRequired(e => e.Estado).WithMany(ex => ex.ExamenLaboratorios).WillCascadeOnDelete(false);
            modelBuilder.Entity<tcLaboratorio>().HasRequired(e => e.Estado).WithMany(t => t.tcLaboratorios).WillCascadeOnDelete(false);
            modelBuilder.Entity<ImagenLaboratorio>().HasRequired(e => e.Estado).WithMany(i => i.ImagenLaboratorios).WillCascadeOnDelete(false);
            modelBuilder.Entity<tcAlergia>().HasRequired(e => e.Estado).WithMany(t => t.tcAlergias).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}