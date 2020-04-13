using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Threading.Tasks;

namespace proyectoFormacion
{
    class UserContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: No se debería de almacenar así, usar archivo aparte y herramienta de admin. de secretos 
            optionsBuilder.UseMySql("Server=;Database=;user=;password=;");
        }
    }
}
