using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramLanguage> SomeFeatureEntities { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramLanguage>(a =>
            {
                a.ToTable("ProgramLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(a => a.SubProgramLanguages);
            });

            modelBuilder.Entity<SubProgramLanguage>(a =>
            {
                a.ToTable("SubProgramLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.SubName).HasColumnName("SubName");
                a.HasOne(a => a.ProgramLanguage);
            });

            modelBuilder.Entity<Github>(a =>
            {
                a.ToTable("Githubs").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });


            ProgramLanguage[] propgramLanguageEntitySeeds = { new(1, "Java") };
            modelBuilder.Entity<ProgramLanguage>().HasData(propgramLanguageEntitySeeds);


        }
    }
}
