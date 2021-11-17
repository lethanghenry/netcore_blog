using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using thang_core1.Models;

namespace thang_core1.Data
{
    public class thang_core1Context : DbContext
    {
        public thang_core1Context (DbContextOptions<thang_core1Context> options)
            : base(options)
        {
        }

        public DbSet<thang_core1.Models.Blog> Blog { get; set; }
    }
}
