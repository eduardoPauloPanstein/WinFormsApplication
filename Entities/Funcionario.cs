using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Funcionario
    {
        public Funcionario(string nome, string cPF, string rG, string telefone, string email, Endereco endereco, string senha)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Senha = senha;
        }

        public Funcionario()
        {
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public string Senha { get; set; } 
        public bool Ativo { get; set; }
        

    }
}
