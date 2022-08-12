using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Fornecedor
    {
        public Fornecedor(string razaoSocial, string cNPJ, string nomeContato, string telefone, string email)
        {
            Razao_Social = razaoSocial;
            CNPJ = cNPJ;
            Nome_Contato = nomeContato;
            Telefone = telefone;
            Email = email;
        }
        public Fornecedor()
        {

        }

        public int ID { get; set; }
        public string Razao_Social { get; set; }
        public string CNPJ { get; set; }
        public string Nome_Contato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

    }
}
