using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cxlt.Extensions.Configuration.EF
{
    public class EFConfigurationOptionsBuilder
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName { get; set; } = "Configuration";

        public DbContextOptionsBuilder DbContextOptions { get; set; } = new DbContextOptionsBuilder();
    }
}
