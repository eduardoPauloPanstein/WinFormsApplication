using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Saida : Transacao
    {
        public int IDCLIENTE { get; set; }
        public string Forma_Pagamento { get; set; }
    }

}
