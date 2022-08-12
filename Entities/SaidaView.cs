using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SaidaView
    {
        public int ID { get; set; }
        public string FUNCIONARIO { get; set; }
        public string NOME_PRODUTO { get; set; }
        public string FORMA_PAGAMENTO { get; set; }
        public double VALOR_UNITARIO { get; set; }
        public double QUANTIDADE { get; set; }
        public double VALOR_TOTAL { get; set; }
        public string CLIENTE { get; set; }
        public DateTime DATA { get; set; }
    }
}
