using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DashboardDAL : IDashboard
    {
        public SingleResponse<int> GetNumTotalClientes()
        {
            string sql = "SELECT COUNT(ID) FROM CLIENTES";

            SqlCommand command = new(sql);
            try
            {
                int num = DbExecuter.ExecuteScalar(command);
                return new("Comando executado com sucesso", true, num);
            }
            catch (Exception)
            {
                return new ("Erro no banco de dados, contate o administrador.", false, 0);
            }
        }

        public SingleResponse<int> GetNumTotalFuncionarios()
        {            
            string sql = "SELECT COUNT(ID) FROM FUNCIONARIOS";

            SqlCommand command = new(sql);
            try
            {
                int num = DbExecuter.ExecuteScalar(command);
                return new("Comando executado com sucesso", true, num);
            }
            catch (Exception)
            {
                return new("Erro no banco de dados, contate o administrador.", false, 0);
            }
        }

        public SingleResponse<int> GetNumTotalVendas()
        {
            string sql = "SELECT COUNT(ID) FROM SAIDAS";

            SqlCommand command = new(sql);
            try
            {
                int num = DbExecuter.ExecuteScalar(command);
                return new("Comando executado com sucesso", true, num);
            }
            catch (Exception)
            {
                return new("Erro no banco de dados, contate o administrador.", false, 0);
            }
        }


        public DataResponse<ProdutoViewDash> GetProdutosEstoqueBaixo()
        {
            string sql = $"SELECT NOME_PRODUTO AS 'NOME', QTD_ESTOQUE AS 'QUANTIDADE' FROM PRODUTOS WHERE QTD_ESTOQUE < 20 AND ATIVO = 1 ORDER BY QTD_ESTOQUE ASC";

            SqlCommand command = new SqlCommand(sql);

            try
            {
                return new DbExecuter().GetData<ProdutoViewDash>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<ProdutoViewDash>("Erro no banco de dados, contate  administrador", false, null);
            }
        }


        public DataResponse<ProdutoViewDash> GetTopProdutos(int x)
        {
            //SELECT TOP @X P...
            string sql = $"SELECT TOP 5 P.NOME_PRODUTO as 'NOME', SUM(PS.QUANTIDADE) AS QUANTIDADE FROM PRODUTOS_SAIDA PS INNER JOIN PRODUTOS P ON P.ID = PS.IDPRODUTO GROUP BY P.NOME_PRODUTO ORDER BY QUANTIDADE DESC";

            SqlCommand command = new SqlCommand(sql);
            //command.Parameters.AddWithValue("@X", x);

            try
            {
                return new DbExecuter().GetData<ProdutoViewDash>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<ProdutoViewDash>("Erro no banco de dados, contate  administrador", false, null);
            }
        }

        public SingleResponse<double> GetValorVendas(DataFiltro dt)
        {
            string sql = "SELECT SUM(VALOR_TOTAL) FROM SAIDAS  WHERE DATA BETWEEN @INICIO AND @FIM";

            SqlCommand command = new(sql);
            command.Parameters.AddWithValue("@INICIO", dt.DtInicio);
            command.Parameters.AddWithValue("@FIM", dt.DtFim);

            try
            {
                double num = DbExecuter.ExecuteScalar(command);
                return new("Comando executado com sucesso", true, num);
            }
            catch (Exception)
            {
                return new("Erro no banco de dados, contate o administrador.", false, 0);
            }
        }
    }
}
