using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Endereco
    {
        public Endereco(string cEP, string numero)
        {
            CEP = cEP;
            Numero = numero;
        }

        public Endereco()
        {
        }

        public int ID { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }

        public override string ToString()
        {
            return this.CEP + "\r\n" +
                   this.Numero + "\r\n";
        }
    }
}
