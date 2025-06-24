using DevIO.Produtos.Application.Command;
using DevIO.Produtos.Domain.Entities;
using DevIO.Produtos.Domain.Repository;
using MediatR;


namespace DevIO.Produtos.Application.Handler;
public class CreateProdutoHandler : IRequestHandler<CreateProdutoCommand, Guid>
{
    private readonly IProdutoRepository _repository;
    public CreateProdutoHandler(IProdutoRepository repository) => _repository = repository;

    public async Task<Guid> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto
        {
            Id = Guid.NewGuid(),
            Descricao = request.Descricao,
            Preco = request.Preco,
            Ativo = request.Ativo
        };

        await _repository.AddAsync(produto, cancellationToken);

        return produto.Id;
    }
}
