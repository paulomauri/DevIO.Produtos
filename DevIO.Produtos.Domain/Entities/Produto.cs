using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Produtos.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
