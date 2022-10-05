using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publish.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string TipoProduto { get; set; }
        public decimal Preco { get; set; }
        public bool Descontinuado { get; set; }
    }
}