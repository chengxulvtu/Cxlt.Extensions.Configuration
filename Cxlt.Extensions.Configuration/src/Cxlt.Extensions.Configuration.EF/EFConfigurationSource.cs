using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cxlt.Extensions.Configuration.EF
{
    internal class EFConfigurationSource : IConfigurationSource
    {
        private readonly Action<EFConfigurationOptionsBuilder> _optionsAction;

        public EFConfigurationSource(Action<EFConfigurationOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EFConfigurationProvider(_optionsAction);
        }
    }
}
