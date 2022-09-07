using Microsoft.EntityFrameworkCore;
using Perfume.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Infrastructure.Persistence.Contexts
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<PerfumeModel>? Products { get; set; }
    }
}

