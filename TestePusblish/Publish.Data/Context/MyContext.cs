using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Publish.Core.Entities;

namespace Publish.Data.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions context)
            :base(context)
        {}

        public DbSet<ParamsRabbitMQ> ParamsRabbitMQ { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}