using Shared;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BusinessLogicalLayer
{
    internal class StringValidator     
    {

        private const int CARACTERES_CNPJ = 14;

        internal string ValidateQuantidade(double qtd)
        {
            if (qtd <= 0)
            {
                return "Quantidade deve ser maior do que zero.\r\n";
            }
            return "";
        }

        //todas funções retornar string, ficando vazio caso não tenha erro

        /// <summary>
        /// Verifica algumas regras para o nome, como:
        /// 1)Apenas alfabeto romano
        /// 2)Apenas um espaço entre nome e sobrenome
        /// 3)Mínimo de 3 caracteres
        /// 4)Mínimo de 2 entre nome e sobrenome
        /// </summary>
        /// <param name="nome">Nome a ser validado</param>
        /// <returns>Retorna vazio "" caso o nome esteja correto</returns>
        public string ValidateNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return "Nome deve ser informado.\r\n";
            }

            if (nome.Length < 3)
            {
                return "Nome deve conter no mínimo 3 caracteres.\r\n";
            }
            string[] nomes = nome.Split(" ");
            if (nomes.Length <= 1)
            {
                return "Nome completo deve ser informado.\r\n";
            }

            for (int i = 0; i < nomes.Length; i++)
            {
                if (nomes[i].Length < 2)
                {
                    return "Nome e/ou Sobrenome deve possuir ao menos 2 caracteres.\r\n";
                }
            }
            //Alfabeto romano e acentos gráficos
            string regex = @"^[a-zA-Záâãéêíïóõôüúç ÁÂÃÉÊÍÏÓÔÜÚÇ]+$";
            if (!Regex.IsMatch(nome, regex))
            {
                return "Nome deve conter apenas caracteres do alfabeto romano.\r\n";
            }

            if (nome.Length > 100)
            {
                return "Nome não pode conter mais que 100 caracteres.\r\n";
            }

            return "";
        }

        /// <summary>
        /// Executa validação de CPF utilizando as regras disponibilizadas pela Receita Federal
        /// </summary>
        /// <param name="cpf">Cpf a ser validado</param>
        /// <returns>Retorna "" se o CPF está válido, caso contrário retorna a mensagem de erro</returns>
        public string ValidateCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return "CPF deve ser informado.\r\n";
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            //cpf = cpf.Trim();
            //cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return "CPF deve conter 11 caracteres\r\n";
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool ehValido = cpf.EndsWith(digito);
            if (!ehValido)
            {
                return "CPF com formato inválido.\r\n";
            }
            return "";
        }

        internal string ValidateRazaoSocial(string razaoSocial)
        {
            if (string.IsNullOrWhiteSpace(razaoSocial))
            {
                return "Razão Social deve ser informada.\r\n";
            }

            if (razaoSocial.Length < 2)
            {
                return "Razão Social deve conter no mínimo 2 caracteres.\r\n";
            }
            return "";
        }

        internal string ValidateProdutoPrecoBase(double preco_Base)
        {
            if (preco_Base <= 0)
            {
                return "Preço Base deve ser maior que zero.\r\n";
            }
            return "";
        }

        internal string ValidateProdutoML(double margem_Lucro)
        {
            if (margem_Lucro <= 0)
            {
                return "Margem de lucro deve ser maior que zero.\r\n";
            }
            return "";
        }

        internal string ValidateNumeroResidencial(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero) || numero.Length > 5)
            {
                return "Numero residencial invalido.\r\n";
            }
            return "";
        }

        public string ValidateRG(string rg)
        {
            rg = Normatization.NormatizeRG(rg);
            if (string.IsNullOrWhiteSpace(rg))
            {
                return "RG deve ser informado.\r\n";
            }
            bool isNum = double.TryParse(rg, out _);
            if (!isNum)
            {
                return "RG deve ser numérico.\r\n";
            }
            if (rg.Length > 14 || rg.Length < 6)
            {
                return "RG com número invalido.\r\n";
            }

            return "";
        }

        public string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email deve ser informado.\r\n";
            }

            email = email.Trim();

            if (email.Length < 5)
            {
                return "Email não pode conter menos que 5 caracteres.\r\n";
            }

            if (email.Length > 100)
            {
                return "Email não pode conter mais que 100 caracteres.\r\n";
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                return "Email inválido.\r\n";
            }
            return "";
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public string ValidateCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                return "CEP deve ser informado.\r\n";
            }
            cep = cep.Trim();
            cep = cep.Replace("-", "").Replace(".", "");

            if (cep.Length != 8)
            {
                return "CEP deve conter 8 dígitos (sem considerar hífen/ponto).\r\n";
            }

            int temp = 0;
            if (!int.TryParse(cep, out temp))
            {
                return "CEP em formato incorreto.\r\n";
            }

            return "";
        }

        public string ValidateTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                return "Telefone deve ser informado.\r\n";
            }
            

            if (telefone.Length != 8 && telefone.Length != 9 && telefone.Length != 11 && telefone.Length != 13)
            {
                return "Telefone deve conter 8, 9, 11 ou 13 dígitos.\r\n";
            }

            long temp;
            if (!long.TryParse(telefone, out temp))
            {
                return "Telefone inválido.\r\n";
            }
            return "";
        }

        public bool ValidaCEP(string cep)

        {
            Regex Rgx = new Regex(@"^\d{8}$"); 

            if (!Rgx.IsMatch(cep)) 
                return false;

            else
                return true;

        }
        internal bool IsCnpj(string cnpj)
        {


            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != CARACTERES_CNPJ)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);

        }
        internal Response ValidateCNPJ(string cnpj)
        {
            if (IsCnpj(cnpj)) return new ("", true);
            else return new Response("CNPJ INVALIDO\r\n", false);
        }
        public string ValidateProdutoNome(string nomeProduto)
        {
            if (string.IsNullOrWhiteSpace(nomeProduto))
            {
                return "Nome do produto precisa ser informado\r\n";
            }
            if (nomeProduto.Length <= 1)
            {
                return "Nome precisa ter mais de uma letra\r\n";
            }
            return "";
        }
        public string ValidateProdutoDescricao(string descricao)
        {
            if (descricao.Length < 10)
            {
                return "A descrição precisa possuir mais do que 10 caracteres\r\n";
            }
            return "";
        }
        public string ValidadeProdutoLaboratorio(string laboratorio)
        {
            if (laboratorio == null)
            {
                return "Laboratório precisa ser informado";
            }
            return "";
        }
        public string ValidateProdutoQtdEstoque(int qtdEstoque)
        {
            if (qtdEstoque <= 0)
            {
                return "Estoque zerado";
            }
            return "";

        }
        public Response ValidateLaboratorioNome(string nomeLaboratorio)
        {
            if (string.IsNullOrWhiteSpace(nomeLaboratorio)) 
                return new ("Nome do laboratório precisa ser informado", false);
            if (nomeLaboratorio.Length < 3) 
                return new Response("Nome precisa ter mais de três letras", false);
            return new("Nome do laboratório validado", true);
        }
    }
}