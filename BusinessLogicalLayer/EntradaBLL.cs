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
    public class EntradaBLL : IEntradaProdutos
    {
        EntradaDal entradaDal = new();
        ProdutoBLL produtoBLL = new();   

        public Response EfetuarEntrada(Entrada entrada)
        {
            Response response = Validator.ValidateEntrada(entrada);
            if(!response.HasSuccess)
                return response;
            
            response = entradaDal.EfetuarEntrada(entrada);
            if (response.HasSuccess)
            {
                foreach (var item in entrada.Items)
                {
                    Produto produto = produtoBLL.GetByID(item.IDProduto).Item;
                    //adcionando a quantidade que chegou da entrega ao estoque
                    produto.Qtd_Estoque += item.Qtd;
                    //Alterando preço base(de fabrica) minimo 
                    DadosPreco dadosPreco = new()
                    {
                        precoAntigo = produto.Preco_Base,
                        estoqueAntigo = produto.Qtd_Estoque,
                        precoNovo = item.Preco,
                        estoqueNovo = item.Qtd
                    };
                    //APENAS SE PREÇO E ESTOQUE ANTIGO FOR DIFERENTE DE ZERO
                    produto.Preco_Base = CalculoPrecoMin(dadosPreco);
                    produtoBLL.Atualizar(produto);
                }
            }
            return response;
        }
        private double CalculoPrecoMin(DadosPreco d)
        {
            //((precoAntigo * estoqueAntigo) + (precoNovo * estoqueNovo)) / (estoqueNovo + estoqueAntigo)
            return ((d.precoAntigo * d.estoqueAntigo) + (d.precoNovo * d.estoqueNovo)) / (d.estoqueNovo + d.estoqueAntigo);
        }
        private class DadosPreco
        {
            public double precoAntigo { get; set; }
            public double estoqueAntigo { get; set; }
            public double precoNovo { get; set; }
            public double estoqueNovo { get; set; }
        }

        public DataResponse<EntradaView> LerEntradas(DateTime inicio, DateTime fim)
        {
            return entradaDal.LerEntradas(inicio, fim);
        }
    }
}
