using DataAccessLayer;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public  class Validator
    {
        private StringValidator stringValidator = new StringValidator();

        public Response ValidateItem(Item item)
        {
            string erros = "";
            //Normatization

            erros += stringValidator.ValidateQuantidade(item.Qtd);
            erros += stringValidator.ValidateProdutoPrecoBase(item.Preco);

            if (erros.Length != 0)
            {
                return new Response(erros, false);
            }
            return new Response("Item validado", true);
        }
        public Response ValidateCliente(Cliente cliente)
        {
            string erros = "";
            Normatization.NormatizeCliente(cliente);

            erros += stringValidator.ValidateNome(cliente.Nome);
            erros += stringValidator.ValidateCPF(cliente.CPF);
            erros += stringValidator.ValidateEmail(cliente.Email);
            erros += stringValidator.ValidateTelefone(cliente.Telefone_Um);
            erros += stringValidator.ValidateTelefone(cliente.Telefone_Dois);
            erros += stringValidator.ValidateRG(cliente.RG);
            //Sintaxe cliente.Endereco?.CEP verifica e só passaria o CEP informado caso a propriedade
            //Endereco de dentro do Cliente não seja nula, caso contrário, passará o valor padrão do CEP (que é uma string e vale null!)
            //erros += stringValidator.ValidateCEP(cliente.Endereco?.CEP);

            if (erros.Length != 0)
            {
                return new Response(erros, false);
            }
            return new Response("Validado", true);

        }
        public Response ValidateFuncionario(Funcionario funcionario)
        {
            string erros = "";
            Normatization.NormatizeFuncionario(funcionario);

            erros += stringValidator.ValidateNome(funcionario.Nome);
            erros += stringValidator.ValidateCPF(funcionario.CPF);
            erros += stringValidator.ValidateEmail(funcionario.Email);
            erros += stringValidator.ValidateTelefone(funcionario.Telefone);
            erros += stringValidator.ValidateRG(funcionario.RG);

            if (erros.Length != 0)
            {
                return new Response(erros, false);
            }

            return new Response("Funcionário validado", true);

        }
        public Response ValidateEndereco(Endereco endereco)
        {
            string erros = "";
            Normatization.NormatizeEndereco(endereco);
            erros += stringValidator.ValidateNumeroResidencial(endereco.Numero);
            erros += stringValidator.ValidateCEP(endereco.CEP);

            if (erros.Length != 0)
            {
                return new Response(erros, false);
            }
            return new Response("Endereço validado", true);
        }
        public Response ValidateFornecedor(Fornecedor fornecedor)
        {
            string erros = "";

            Normatization.NormatizeFornecedor(fornecedor);

            erros += stringValidator.ValidateRazaoSocial(fornecedor.Razao_Social);
            erros += stringValidator.ValidateCNPJ(fornecedor.CNPJ).Message;
            erros += stringValidator.ValidateNome(fornecedor.Nome_Contato);
            erros += stringValidator.ValidateTelefone(fornecedor.Telefone);
            erros += stringValidator.ValidateEmail(fornecedor.Email);


            if (erros.Length != 0)
            {
                return new Response(erros, false);
            }

            return new Response("Fornecedor validado", true);

        }

        public Response ValidateProduto(Produto produto)
        {
            string erros = "";
            produto.Nome_Produto = Normatization.NormatizeName(produto.Nome_Produto);

            erros += stringValidator.ValidateProdutoNome(produto.Nome_Produto);
            erros += stringValidator.ValidateProdutoDescricao(produto.Descricao);
            erros += stringValidator.ValidateProdutoML(produto.Margem_Lucro);
            erros += stringValidator.ValidateProdutoPrecoBase(produto.Preco_Base);

            if (erros.Length != 0)
            {
                return new Response(erros, false);
            }
            return new Response("Produto validado", true);
        }
        public Response ValidateLaboratorio(Laboratorio laboratorio)
        {
            laboratorio.Nome = Normatization.NormatizeName(laboratorio.Nome);
            laboratorio.CNPJ = Normatization.NormatizeCNPJ(laboratorio.CNPJ);

            Response response= stringValidator.ValidateLaboratorioNome(laboratorio.Nome);
            if (!response.HasSuccess) return response;
            response = stringValidator.ValidateCNPJ(laboratorio.CNPJ);
            if (!response.HasSuccess) return response;

            return new Response("Laboratório validado", true);
        }
        public static Response ValidateSaida(Saida saida)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            ClienteDAL clienteDAL = new();
            bool isCliente = clienteDAL.Existe(saida.IDCLIENTE).HasSuccess;
            if (!isCliente)
                return new("Para efetuar uma venda precisa de um cliente.\r\n", false);

            //CONFERIR SE TEM ESTOQUE
            foreach (var item in saida.Items)
            {
                //Pegar produto/informações do banco
                Produto produto = produtoDAL.GetByID(item.IDProduto).Item;
                //Conferir estoque 
                if (produto.Qtd_Estoque == 0)
                {
                    return new($"Não possui {produto.Nome_Produto} no estoque.\r\n", false);
                }
                if (produto.Qtd_Estoque < item.Qtd)
                {
                    return new($"Não possui {produto.Nome_Produto}'s o suficiente no estoque.\r\n", false);
                }
            }

            if(saida.Items.Count < 1)
                return new("Para efetuar uma venda precisa de produtos.\r\n", false);

            return new("Dados para registrar saida validados com sucesso.\r\n", true);
        }
        public static Response ValidateEntrada(Entrada entrada)
        {
            FornecedorDAL fornecedorDAL = new();
            bool isFornecedor = fornecedorDAL.Existe(entrada.IDFornecedor).HasSuccess;
            if (!isFornecedor)
                return new("Para efetuar uma entrada precisa de um fornecedor.\r\n", false);
            //+
            if (entrada.Items.Count < 1)
                return new("Para efetuar uma entrada precisa de produtos.\r\n", false);

            return new("Dados para registrar entrada validados com sucesso.\r\n", true);
        }
    }
}