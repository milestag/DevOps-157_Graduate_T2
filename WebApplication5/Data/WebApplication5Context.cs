using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class WebApplication5Context : DbContext
    {
        public WebApplication5Context (DbContextOptions<WebApplication5Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication5.Models.Student> Student { get; set; }
    }
}
