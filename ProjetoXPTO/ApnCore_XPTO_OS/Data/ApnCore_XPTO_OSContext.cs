using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApnCore_XPTO_OS.Models;

namespace ApnCore_XPTO_OS.Data
{
    public class ApnCore_XPTO_OSContext : DbContext
    {
        public ApnCore_XPTO_OSContext (DbContextOptions<ApnCore_XPTO_OSContext> options)
            : base(options)
        {
        }

        public DbSet<ApnCore_XPTO_OS.Models.OS> OS { get; set; }
    }
}
