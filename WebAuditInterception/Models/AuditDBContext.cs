using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

            // Especificando a chave Id como Identity (auto-incremento)
            modelBuilder.Entity<People>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PeopleHist>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }

        public DbSet<People> Peoples { get; set; }

    }
}