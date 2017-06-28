using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cxlt.Extensions.Configuration.EF
{
    internal class EFConfigurationProvider : ConfigurationProvider
    {
        Action<DbContextOptionsBuilder> OptionsAction { get; }
        DbContextOptionsBuilder<ConfigurationDbContext> Builder { get; } = new DbContextOptionsBuilder<ConfigurationDbContext>();

        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
            OptionsAction(Builder);
        }

        public override void Load()
        {
            using (var ctx = new ConfigurationDbContext(Builder.Options))
            {
                ctx.Database.EnsureCreated();
                Data = ctx.Configurations.ToDictionary(t => t.Key, t => t.Value);
            }
        }
    }
}
