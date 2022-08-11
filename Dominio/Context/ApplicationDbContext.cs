using Dominio.Models.Log;
using DreamyApi.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamyApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
