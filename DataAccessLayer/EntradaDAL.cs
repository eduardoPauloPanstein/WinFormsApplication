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
    public class EntradaDal : ConnectionSQL ,IEntradaProdutos 
    {
        public DataResponse<EntradaView> LerEntradas(DateTime inicio, DateTime fim)
        {
            string sql = $"SELECT E.ID,F.NOME as 'FUNCIONARIO',P.NOME_PRODUTO,PE.VALOR_UNITARIO,PE.QUANTIDADE,E.VALOR_TOTAL,FO.RAZAO_SOCIAL AS 'FORNECEDOR',E.DATA FROM PRODUTOS_ENTRADA PE INNER JOIN ENTRADAS E ON PE.IDENTRADA = E.ID INNER JOIN PRODUTOS P ON PE.IDPRODUTOS = P.ID INNER JOIN FUNCIONARIOS F ON E.IDFUNCIONARIO = F.ID INNER JOIN FORNECEDORES FO ON E.IDFORNECEDOR = FO.ID" +
                $" where E.DATA between @inicio and @fim";


            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@inicio", inicio);
            command.Parameters.AddWithValue("@fim", fim);

            try
            {
                return new DbExecuter().GetData<EntradaView>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<EntradaView>("Erro no banco de dados, contate  administrador", false, null);
            }

        }

        public SingleResponse<Entrada> GetByID(int id)
        {
            string sql = $"SELECT ID,DATA,PRODUTO,FORNECEDOR,QUANTIDADE,PRECO_UNITARIO,VALOR_TOTAL FROM Entrada WHERE ID = @ID";

            SqlCommand command = new(sql);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                return DbExecuter.GetItem<Entrada>(command);
            }
            catch (Exception)
            {
                return new SingleResponse<Entrada>("Erro no banco de dados, contate o administrador.", false, null);
            }
        }

        public Response EfetuarEntrada(Entrada entrada)
        {
            string sql = $"INSERT INTO ENTRADAS (VALOR_TOTAL,IDFORNECEDOR,IDFUNCIONARIO,DATA)" +
                       $" VALUES (@VALOR_TOTAL,@IDFORNECEDOR,@IDFUNCIONARIO,@DATA); select scope_identity()";


            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@VALOR_TOTAL", entrada.ValorTotal);
            command.Parameters.AddWithValue("@IDFORNECEDOR", entrada.IDFornecedor);
            command.Parameters.AddWithValue("@IDFUNCIONARIO", entrada.IDFuncionario);
            command.Parameters.AddWithValue("@DATA", entrada.Data);

            using (TransactionScope scope = new())
            {
                try
                {
                    entrada.ID = DbExecuter.ExecuteScalar(command);

                    foreach (var item in entrada.Items)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO PRODUTOS_ENTRADA (IDENTRADA,IDPRODUTOS,QUANTIDADE,VALOR_UNITARIO) VALUES (@IDENTRADA,@IDPRODUTOS,@QUANTIDADE,@VALOR_UNITARIO)");
                        cmd.Parameters.AddWithValue("@IDENTRADA", entrada.ID);
                        cmd.Parameters.AddWithValue("@IDPRODUTOS", item.IDProduto);
                        cmd.Parameters.AddWithValue("@QUANTIDADE", item.Qtd);
                        cmd.Parameters.AddWithValue("@VALOR_UNITARIO", item.Preco);
                        Response response = DbExecuter.Execute(cmd);
                        if (!response.HasSuccess)
                        {
                            return new Response("A entrada não pode ser concluída.", false);
                        }
                    }
                    scope.Complete();
                    return new Response("Compra cadastradada com sucesso.", true);
                }
                catch (Exception ex)
                {
                    return new Response("Erro no banco de dados, contate o administrador.\r\n" + ex, false);
                }
            }

        }
    }
}
