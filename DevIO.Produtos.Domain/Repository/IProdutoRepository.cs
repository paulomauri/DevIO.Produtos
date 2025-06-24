using DevIO.Produtos.Domain.Entities;
namespace DevIO.Produtos.Domain.Repository;
public interface IProdutoRepository
{
    Task AddAsync(Produto produto, CancellationToken cancellationToken);
}