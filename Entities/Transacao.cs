using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Transacao
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int IDFuncionario { get; set; }
        public double ValorTotal { get; set; }
        public List<Item> Items { get; set; }
        public Transacao()
        {
            this.Items = new List<Item>();
        }
    }

    public class Item
    {
        public int IDProduto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Qtd { get; set; }
    }

}
