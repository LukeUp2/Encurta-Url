using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Encurtador_Url.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Encurtador_Url.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Link> Links { get; set; }
    }
    
}