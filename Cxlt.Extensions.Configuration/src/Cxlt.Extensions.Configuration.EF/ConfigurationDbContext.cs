using System;
using Microsoft.EntityFrameworkCore;

namespace Cxlt.Extensions.Configuration.EF
{
    internal class ConfigurationDbContext : DbContext
    {
        private EFConfigurationOptionsBuilder Builder { get; }

        public ConfigurationDbContext(EFConfigurationOptionsBuilder options) : base(options.DbContextOptions.Options)
        {
            Builder = options;
        }

        public DbSet<Configuration> Configurations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Configuration>(b =>
            {
                if (!string.IsNullOrEmpty(Builder.TableName))
                {
                    b.Metadata.RemoveAnnotation("Relational:TableName");
                    b.Metadata.AddAnnotation("Relational:TableName", Builder.TableName);
                }

                b.HasKey(t => t.Key);
                b.Property(t => t.Key).ValueGeneratedNever();
            });
        }
    }
}
