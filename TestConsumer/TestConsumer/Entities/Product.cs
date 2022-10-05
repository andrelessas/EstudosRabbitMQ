using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsumer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string TipoProduto { get; set; }
        public decimal Preco { get; set; }
    }
}
