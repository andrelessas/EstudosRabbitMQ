using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publish.Core.DTOs
{
    public class ProductDTO
    {    
        public string Descricao { get; set; }
        public string TipoProduto { get; set; }
        public decimal Preco { get; set; }    
    }
}