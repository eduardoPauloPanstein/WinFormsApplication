using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public class SaidaDAL : ISaidaProdutos
    {
        public Response EfetuarSaida(Saida saida)
        {
            string sql = $"INSERT INTO SAIDAS (VALOR_TOTAL,IDFUNCIONARIO,IDCLIENTE,DATA,FORMA_PAGAMENTO)" +
                   $" VALUES (@VALOR_TOTAL,@IDFUNCIONARIO,@IDCLIENTE,@DATA,@FORMA_PAGAMENTO); select scope_identity()";


            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@VALOR_TOTAL", saida.ValorTotal);
            command.Parameters.AddWithValue("@IDCLIENTE", saida.IDCLIENTE);
            command.Parameters.AddWithValue("@IDFUNCIONARIO", saida.IDFuncionario);
            command.Parameters.AddWithValue("@DATA", saida.Data);
            command.Parameters.AddWithValue("@FORMA_PAGAMENTO", saida.Forma_Pagamento);

            using (TransactionScope scope = new())
            {
                try
                {
                    saida.ID = DbExecuter.ExecuteScalar(command);

                    foreach (var item in saida.Items)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO PRODUTOS_SAIDA (IDSAIDA,IDPRODUTO,QUANTIDADE,VALOR_UNITARIO) VALUES (@IDSAIDA,@IDPRODUTO,@QUANTIDADE,@VALOR_UNITARIO)");
                        cmd.Parameters.AddWithValue("@IDSAIDA", saida.ID);
                        cmd.Parameters.AddWithValue("@IDPRODUTO", item.IDProduto);
                        cmd.Parameters.AddWithValue("@QUANTIDADE", item.Qtd);
                        cmd.Parameters.AddWithValue("@VALOR_UNITARIO", item.Preco);
                        Response response = DbExecuter.Execute(cmd);
                        if (!response.HasSuccess)
                        {
                            return new Response("A venda não pode ser concluída.", false);
                        }
                    }
                    scope.Complete();
                    return new Response("Venda cadastrada com sucesso.", true);
                }
                catch (Exception ex)
                {
                    return new Response("Erro no banco de dados, contate o administrador.\r\n" + ex, false);
                }
            }
        }

        public Response Deletar(int iD)
        {
            string sql = $"DELETE FROM SAIDAS WHERE ID = @ID";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", iD);
            try
            {
                return DbExecuter.Execute(command);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    return new Response("Não é possivel deletar registros do histórico.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador" + ex, false);
            }
        }

        public DataResponse<SaidaView> LerSaidas(DateTime inicio, DateTime fim)
        {
            //string sql = $"SELECT PS.ID,S.DATA,S.IDCLIENTE,P.NOME_PRODUTO,PS.VALOR_UNITARIO,PS.QUANTIDADE,S.VALOR_TOTAL,S.FORMA_PAGAMENTO,S.IDFUNCIONARIO" +
            //    $" FROM PRODUTOS_SAIDA PS INNER JOIN SAIDAS S ON PS.IDSAIDA = S.ID INNER JOIN PRODUTOS P ON PS.IDPRODUTO = P.ID" +
            //    $" where S.DATA between @inicio and @fim";

            string sql = $"SELECT S.ID,S.DATA,C.NOME AS 'CLIENTE',P.NOME_PRODUTO,PS.VALOR_UNITARIO, PS.QUANTIDADE,S.VALOR_TOTAL,S.FORMA_PAGAMENTO,F.NOME AS 'FUNCIONARIO' FROM PRODUTOS_SAIDA PS INNER JOIN SAIDAS S ON PS.IDSAIDA = S.ID  INNER JOIN PRODUTOS P ON PS.IDPRODUTO = P.ID INNER JOIN CLIENTES C ON S.IDCLIENTE = C.ID INNER JOIN FUNCIONARIOS F ON S.IDFUNCIONARIO = F.ID  where S.DATA between @inicio and @fim";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@inicio", inicio);
            command.Parameters.AddWithValue("@fim", fim);

            try
            {
                return new DbExecuter().GetData<SaidaView>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<SaidaView>("Erro no banco de dados, contate  administrador", false, null);
            }
        }
    }
}
