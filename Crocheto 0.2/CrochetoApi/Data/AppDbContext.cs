using CrochetoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Web.Providers.Entities;

namespace CrochetoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Role> Roles { get; set; }
    }
}
