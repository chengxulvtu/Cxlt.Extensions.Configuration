using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cxlt.Extensions.Configuration.EF
{
    internal class EFConfigurationProvider : ConfigurationProvider
    {
        Action<EFConfigurationOptionsBuilder> OptionsAction { get; }


        public EFConfigurationProvider(Action<EFConfigurationOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new EFConfigurationOptionsBuilder();
            OptionsAction(builder);
            using (var ctx = new ConfigurationDbContext(builder))
            {
                ctx.Database.EnsureCreated();
                Data = ctx.Configurations.ToDictionary(t => t.Key, t => t.Value);
            }
        }
    }
}
