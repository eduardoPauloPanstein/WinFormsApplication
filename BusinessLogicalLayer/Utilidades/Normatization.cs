using Entities;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BusinessLogicalLayer
{
    public class Normatization
    {
        public Normatization()
        {
        }

        public static string NormatizeName(string nome)
        {
            string nomeNormatizado = new CultureInfo("pt-br").TextInfo.ToTitleCase(nome);
            nomeNormatizado = nomeNormatizado.Trim();
            return Regex.Replace(nomeNormatizado, @"\s+", " ");
        }
        public static string NormatizeCPF(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace(",", "").Replace("-", "");
        }
        public static string NormatizeTelefone(string telefone)
        {
            telefone = telefone.Trim();

            telefone =
                telefone.Replace("(", "")
                        .Replace(")", "")
                        .Replace("-", "")
                        .Replace(" ", "")
                        .Replace(".", "")
                        .Replace("+", "");
            return telefone;
        }
        public static string NormatizeRG(string rg)
        {
            return rg.Trim().Replace(".", "").Replace("-", "").Replace(",", "");
        }
        public static string NormatizeEmail(string email)
        {
            return email = email.Trim();
        }
        public static string NormatizeCNPJ(string cnpj)
        {
            return cnpj.Trim().Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "");
        }
        public static string NormatizeNumResidencial(string num)
        {
            return num.Trim();
        }
        public static string NormatizeCEP(string cep)
        {
            return cep.Trim().Replace("-", "");
        }
        public static string NormatizeDinheiro(string dinheiro)
        {
            return dinheiro.Trim().Replace("$", "").Replace("R", "").Replace(":", "");
        }

        public static void NormatizeCliente(Cliente cliente)
        {
            cliente.Nome = NormatizeName(cliente.Nome);
            cliente.CPF = NormatizeCPF(cliente.CPF);
            cliente.RG = NormatizeRG(cliente.RG);
            cliente.Telefone_Um = NormatizeTelefone(cliente.Telefone_Um);
            cliente.Telefone_Dois = NormatizeTelefone(cliente.Telefone_Dois);
            cliente.Email = NormatizeEmail(cliente.Email);
        }
        public static void NormatizeFuncionario(Funcionario funcionario)
        {
            funcionario.Nome = NormatizeName(funcionario.Nome);
            funcionario.CPF = NormatizeCPF(funcionario.CPF);
            funcionario.Telefone = NormatizeTelefone(funcionario.Telefone);
            funcionario.RG = NormatizeRG(funcionario.RG);
            funcionario.Email = NormatizeEmail(funcionario.Email);


        }

        internal static void NormatizeEndereco(Endereco endereco)
        {
            endereco.Numero = NormatizeNumResidencial(endereco.Numero);
            endereco.CEP = NormatizeCEP(endereco.CEP);
        }

        public static void NormatizeFornecedor(Fornecedor fornecedor)
        {
            fornecedor.Nome_Contato = NormatizeName(fornecedor.Nome_Contato);
            fornecedor.Telefone = NormatizeTelefone(fornecedor.Telefone);
            fornecedor.CNPJ = NormatizeCNPJ(fornecedor.CNPJ);
            fornecedor.Email = NormatizeEmail(fornecedor.Email);
        }
    }
}