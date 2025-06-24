using DevIO.Produtos.Domain.Entities;
using DevIO.Produtos.Domain.Repository;
using DevIO.Produtos.Infrastructure.Data;

namespace DevIO.Produtos.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Produto produto, CancellationToken cancellationToken)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
