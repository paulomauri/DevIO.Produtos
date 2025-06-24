using DevIO.Produtos.Application.Command;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace DevIO.Produtos.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProdutosController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateProdutoCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(Create), new { id });
        }
    }
}
