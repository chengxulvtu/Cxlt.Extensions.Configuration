using System;
using Microsoft.EntityFrameworkCore;
using Cxlt.Extensions.Configuration.EF;

namespace Microsoft.Extensions.Configuration
{
    public static class EFConfigurationExtensions
    {
        public static IConfigurationBuilder AddEntityFramework(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(new EFConfigurationSource(setup));
        }
    }
}
