using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLogicalLayer
{
    public class SaidaBLL : ISaidaProdutos
    {
        SaidaDAL saidaDAL = new();
        ProdutoBLL produtoBLL = new();
        ClienteDAL clienteDAL = new();

        public Response EfetuarSaida(Saida saida)
        {
            Response response;
            bool hasDesconto = false;
            response = Validator.ValidateSaida(saida);
            if(!response.HasSuccess)
                return response;
            //Conferir desconto/alterar os pontos -- Reestruturar
            Cliente cli = clienteDAL.GetByID(saida.IDCLIENTE).Item;
            if (cli.Nome != "CLIENTE_PADRAO") //MELHORAR ISSO
            {
                if (cli.Pontos >= 10)
                {
                    hasDesconto = true;
                    cli.Pontos -= 10;
                    saida.ValorTotal *= 0.9;
                }
                int pontosGanhos = (int)Math.Floor(saida.ValorTotal / 10);
                cli.Pontos += pontosGanhos;
            }
           

            //TRANSITION SCOPE HERE
            response = saidaDAL.EfetuarSaida(saida);
            clienteDAL.Update(cli);
            if (response.HasSuccess)
            {
                foreach (var item in saida.Items)
                {
                    Produto produto = produtoBLL.GetByID(item.IDProduto).Item;
                    //diminuindo estoque 
                    produto.Qtd_Estoque -= item.Qtd;
                    produtoBLL.Atualizar(produto);
                }
            }
            //Hmmm
            return new ($"{saida.ValorTotal.ToString("C2")}", response.HasSuccess);
        }


        public DataResponse<SaidaView> LerSaidas(DateTime inicio, DateTime fim)
        {
            return saidaDAL.LerSaidas(inicio, fim);
        }

        public Response Deletar(int iD)
        {
            return saidaDAL.Deletar(iD);
        }
    }

}
