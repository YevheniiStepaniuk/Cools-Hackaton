using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Valeriy.Domain.Entities;

namespace Valeriy.DAL
{
    public class ValeriyDbContext : DbContext
    {

        public ValeriyDbContext(DbContextOptions<ValeriyDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}