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
    public class ProdutoDAL : ConnectionSQL
    {
        public Response Insert(Produto produto)
        {
            string sql = $"INSERT INTO PRODUTOS (NOME_PRODUTO,DESCRICAO,LABORATORIO,QTD_ESTOQUE,PRECO_BASE,MARGEM_LUCRO,PRECO_VENDA) VALUES (@NOME_PRODUTO,@DESCRICAO,@LABORATORIO,@QTD_ESTOQUE,@PRECO_BASE,@MARGEM_LUCRO,@PRECO_VENDA)";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME_PRODUTO", produto.Nome_Produto);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@LABORATORIO", produto.Laboratorio.ID);
            command.Parameters.AddWithValue("@QTD_ESTOQUE", produto.Qtd_Estoque);
            command.Parameters.AddWithValue("@PRECO_BASE", produto.Preco_Base);
            command.Parameters.AddWithValue("@MARGEM_LUCRO", produto.Margem_Lucro);
            command.Parameters.AddWithValue("@PRECO_VENDA", produto.Preco_Venda);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Produto cadastrado com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_PRODUTOS_NOME_PRODUTO"))
                {
                    return new Response("Nome já está em uso.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        //Alterar dados
        public Response Update(Produto produto)
        {
            string sql = $"UPDATE PRODUTOS SET NOME_PRODUTO=@NOME_PRODUTO,DESCRICAO=@DESCRICAO,LABORATORIO=@LABORATORIO,QTD_ESTOQUE=@QTD_ESTOQUE,PRECO_BASE=@PRECO_BASE,MARGEM_LUCRO=@MARGEM_LUCRO,PRECO_VENDA=@PRECO_VENDA,ATIVO=@ATIVO WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME_PRODUTO", produto.Nome_Produto);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@LABORATORIO", produto.Laboratorio.ID);
            command.Parameters.AddWithValue("@QTD_ESTOQUE", produto.Qtd_Estoque);
            command.Parameters.AddWithValue("@PRECO_BASE", produto.Preco_Base);
            command.Parameters.AddWithValue("@MARGEM_LUCRO", produto.Margem_Lucro);
            command.Parameters.AddWithValue("@PRECO_VENDA", produto.Preco_Venda);
            command.Parameters.AddWithValue("@ATIVO", produto.Ativo);
            command.Parameters.AddWithValue("@ID", produto.ID);

            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_PRODUTOS_NOME_PRODUTO"))
                {
                    return new Response("Nome já está em uso.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }

        public Response Delete(int iD)
        {
            string sql = $"DELETE FROM PRODUTOS WHERE ID = @ID";
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

        //Atualizar estoque e preço - Para quando tiver entrada de produtos
        public Response Atualizar(Produto produto)
        {
            string sql = $"UPDATE PRODUTOS SET QTD_ESTOQUE=@QTD_ESTOQUE,PRECO_BASE=@PRECO_BASE WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@QTD_ESTOQUE", produto.Qtd_Estoque);
            command.Parameters.AddWithValue("@PRECO_BASE", produto.Preco_Base);
            command.Parameters.AddWithValue("@ID", produto.ID);

            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        public DataResponse<Produto> GetAllView()
        {
            string sql = $"SELECT P.ID,P.NOME_PRODUTO,P.DESCRICAO,L.NOME,P.LABORATORIO,P.QTD_ESTOQUE,P.PRECO_BASE,P.MARGEM_LUCRO,P.ATIVO" +
                $" FROM PRODUTOS P INNER JOIN LABORATORIOS L ON P.LABORATORIO = L.ID";
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Produto> produtos = new();

                while (reader.Read())
                {
                    Produto produto = new();
                    Laboratorio laboratorio = new();
                    produto.ID = Convert.ToInt32(reader["ID"]);
                    produto.Nome_Produto = Convert.ToString(reader["NOME_PRODUTO"]);
                    produto.Descricao = Convert.ToString(reader["DESCRICAO"]);
                    laboratorio.Nome = Convert.ToString(reader["NOME"]);
                    laboratorio.ID = Convert.ToInt32(reader["LABORATORIO"]);
                    produto.Qtd_Estoque = Convert.ToInt32(reader["QTD_ESTOQUE"]);
                    produto.Preco_Base = Convert.ToInt32(reader["PRECO_BASE"]);
                    produto.Margem_Lucro = Convert.ToInt32(reader["MARGEM_LUCRO"]);
                    //produto.Preco_Venda = Convert.ToInt32(reader["PRECO_VENDA"]);
                    produto.Ativo = Convert.ToBoolean(reader["ATIVO"]);
                    produto.Laboratorio = laboratorio;

                    produtos.Add(produto);
                }
                return new DataResponse<Produto>("Produtos selecionados com sucesso!", true, produtos);
            }
            catch (Exception ex)
            {
                return new DataResponse<Produto>("Erro no banco de dados, contate  administrador", false, null);
            }
            finally
            {
                connection.Dispose();
            }
        }
        /// <summary>
        /// Get by RAZAO_SOCIAL or ID
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataResponse<Produto> GetByValue(string value)
        {
            int produtoID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;


            string sql = $"SELECT P.ID,P.NOME_PRODUTO,P.DESCRICAO,L.NOME,P.LABORATORIO,P.QTD_ESTOQUE,P.PRECO_BASE,P.MARGEM_LUCRO,P.ATIVO" +
                            $" FROM PRODUTOS P INNER JOIN LABORATORIOS L ON P.LABORATORIO = L.ID WHERE P.ID = @ID OR NOME_PRODUTO LIKE '%'+@NOME_PRODUTO+'%'";
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", produtoID);
            command.Parameters.AddWithValue("@NOME_PRODUTO", value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Produto> produtos = new();

                while (reader.Read())
                {
                    Produto produto = new();
                    Laboratorio laboratorio = new();
                    produto.ID = Convert.ToInt32(reader["ID"]);
                    produto.Nome_Produto = Convert.ToString(reader["NOME_PRODUTO"]);
                    produto.Descricao = Convert.ToString(reader["DESCRICAO"]);
                    laboratorio.Nome = Convert.ToString(reader["NOME"]);
                    laboratorio.ID = Convert.ToInt32(reader["LABORATORIO"]);
                    produto.Qtd_Estoque = Convert.ToInt32(reader["QTD_ESTOQUE"]);
                    produto.Preco_Base = Convert.ToInt32(reader["PRECO_BASE"]);
                    produto.Margem_Lucro = Convert.ToInt32(reader["MARGEM_LUCRO"]);
                    produto.Ativo = Convert.ToBoolean(reader["ATIVO"]);
                    produto.Laboratorio = laboratorio;

                    produtos.Add(produto);
                }
                return new DataResponse<Produto>("Produtos selecionados com sucesso!", true, produtos);
            }
            catch (Exception ex)
            {
                return new DataResponse<Produto>("Erro no banco de dados, contate  administrador", false, null);
            }
            finally
            {
                connection.Dispose();
            }
        }
        public SingleResponse<Produto> GetByID(int ID)
        {
            string sql = $"SELECT P.ID,P.NOME_PRODUTO,P.DESCRICAO,L.NOME,P.LABORATORIO,P.QTD_ESTOQUE,P.PRECO_BASE,P.MARGEM_LUCRO,P.ATIVO" +
                            $" FROM PRODUTOS P INNER JOIN LABORATORIOS L ON P.LABORATORIO = L.ID WHERE P.ID = @ID";

            SqlConnection connection = GetConnection();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Produto produto = new();
                    Laboratorio laboratorio = new();
                    produto.ID = Convert.ToInt32(reader["ID"]);
                    produto.Nome_Produto = Convert.ToString(reader["NOME_PRODUTO"]);
                    produto.Descricao = Convert.ToString(reader["DESCRICAO"]);
                    laboratorio.Nome = Convert.ToString(reader["NOME"]);
                    laboratorio.ID = Convert.ToInt32(reader["LABORATORIO"]);
                    produto.Qtd_Estoque = Convert.ToInt32(reader["QTD_ESTOQUE"]);
                    produto.Preco_Base = Convert.ToInt32(reader["PRECO_BASE"]);
                    produto.Margem_Lucro = Convert.ToInt32(reader["MARGEM_LUCRO"]);
                    produto.Ativo = Convert.ToBoolean(reader["ATIVO"]);
                    produto.Laboratorio = laboratorio;
                    return new SingleResponse<Produto>("Dados selecionados com sucesso!", true, produto);
                }
                return new SingleResponse<Produto>("Produto não encontrado", false, null);
            }
            catch (Exception ex)
            {
                return new SingleResponse<Produto>("Erro no banco de dados, contate  administrador", false, null);
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}