using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;

namespace WebAuditInterception.Models
{
    public class AuditDBContext : DbContext
    {
        public AuditDBContext() : base("AuditEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<People>().ToTable("People");
            modelBuilder.Entity<PeopleHist>().ToTable("PeopleHist");
            modelBuilder.Entity<Comando>().ToTable("Comando");
            modelBuilder.Entity<Parametro>().ToTable("Parametro");

            // Especificando a chave Id como Identity (auto-incremento)
            modelBuilder.Entity<People>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PeopleHist>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Comando>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Parametro>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }



        public DbSet<People> Peoples { get; set; }
        public DbSet<Comando> Comandos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }

    }
}