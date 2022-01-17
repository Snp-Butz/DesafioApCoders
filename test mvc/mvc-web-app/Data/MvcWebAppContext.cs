#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_web_app.Models;

    public class MvcWebAppContext : DbContext
    {
        public MvcWebAppContext (DbContextOptions<MvcWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<inquilino> inquilino { get; set; }
    }
