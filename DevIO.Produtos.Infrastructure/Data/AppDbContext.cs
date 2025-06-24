using Microsoft.EntityFrameworkCore;
using DevIO.Produtos.Domain.Entities;


namespace DevIO.Produtos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos => Set<Produto>();
    }
}
