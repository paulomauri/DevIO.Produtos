using MediatR;

namespace DevIO.Produtos.Application.Command;

public record CreateProdutoCommand(string Descricao, decimal Preco, bool Ativo) : IRequest<Guid>;