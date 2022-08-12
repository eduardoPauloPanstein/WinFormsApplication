using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome_Produto { get; set; }
        public string Descricao { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public double Qtd_Estoque { get; set; }
        public double Preco_Base { get; set; }
        public double Margem_Lucro { get; set; }
        public double Preco_Venda
        {
            get
            {
                return Preco_Base + (Preco_Base * (Margem_Lucro / 100));
            }
        }  
        public bool Ativo { get; set; }
    }

}
