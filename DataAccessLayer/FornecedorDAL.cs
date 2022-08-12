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
    public class FornecedorDAL : ConnectionSQL
    {
        public Response Insert(Fornecedor fornecedor)
        {
            string sql = $"INSERT INTO FORNECEDORES (RAZAO_SOCIAL,CNPJ,NOME_CONTATO,TELEFONE,EMAIL) VALUES (@RAZAO_SOCIAL,@CNPJ,@NOME_CONTATO,@TELEFONE,@EMAIL)";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@RAZAO_SOCIAL", fornecedor.Razao_Social);
            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
            command.Parameters.AddWithValue("@NOME_CONTATO", fornecedor.Nome_Contato);
            command.Parameters.AddWithValue("@TELEFONE", fornecedor.Telefone);
            command.Parameters.AddWithValue("@EMAIL", fornecedor.Email);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Fornecedor cadastrado com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_FORNECEDORES_EMAIL"))
                {
                    return new Response("Email já está em uso.", false);
                }
                if (ex.Message.Contains("UQ_FORNECEDORES_CPF"))
                {
                    return new Response("CPF já está em uso.", false);
                }
                //SE NAO ENTROU EM NENHUM IF DE CIMA, SÓ PODE SER UM ERRO DE INFRAESTRUTURA
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }

        public Response Delete(int iD)
        {
            string sql = $"DELETE FROM FORNECEDORES WHERE ID = @ID";
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

        public Response Update(Fornecedor fornecedor)
        {

            string sql = $"UPDATE FORNECEDORES SET RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ,NOME_CONTATO = @NOME_CONTATO,TELEFONE = @TELEFONE,EMAIL = @EMAIL WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@RAZAO_SOCIAL", fornecedor.Razao_Social);
            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
            command.Parameters.AddWithValue("@NOME_CONTATO", fornecedor.Nome_Contato);
            command.Parameters.AddWithValue("@TELEFONE", fornecedor.Telefone);
            command.Parameters.AddWithValue("@EMAIL", fornecedor.Email);
            command.Parameters.AddWithValue("@ID", fornecedor.ID);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_FORNECEDORES_EMAIL"))
                {
                    return new Response("Email já está em uso.", false);
                }
                if (ex.Message.Contains("UQ_FORNECEDORES_CPF"))
                {
                    return new Response("CPF já está em uso.", false);
                }
                //SE NAO ENTROU EM NENHUM IF DE CIMA, SÓ PODE SER UM ERRO DE INFRAESTRUTURA
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        public Response Desativar(int id)
        {
            string sql = $"UPDATE FORNECEDORES SET ATIVO = 0 WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Fornecedor desativado.", true);
            }
            catch (Exception ex)
            {
                //Quais expetion podem ocorrer aqui?
                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }
        }
        public Response Ativar(int id)
        {
            string sql = $"UPDATE FORNECEDORES SET ATIVO = 1 WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Fornecedor ativado.", true);
            }
            catch (Exception ex)
            {
                //Quais expetion podem ocorrer aqui?
                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }
        }
        public DataResponse<Fornecedor> GetAll()
        {
            string sql = $"SELECT ID,RAZAO_SOCIAL,CNPJ,NOME_CONTATO,TELEFONE,EMAIL,ATIVO FROM FORNECEDORES";

            SqlCommand command = new SqlCommand(sql);
            try
            {
                return new DbExecuter().GetData<Fornecedor>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<Fornecedor>("Erro no banco de dados, contate  administrador", false, null);
            }
        }
        /// <summary>
        /// Get by RAZAO_SOCIAL or ID
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataResponse<Fornecedor> GetByValue(string value)
        {
            int fornecedorID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            string sql = $"SELECT ID,RAZAO_SOCIAL,CNPJ,NOME_CONTATO,TELEFONE,EMAIL,ATIVO" +
                $" FROM FORNECEDORES WHERE ID = @ID OR RAZAO_SOCIAL LIKE '%'+@RAZAO_SOCIAL+'%'";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", fornecedorID);
            command.Parameters.AddWithValue("@RAZAO_SOCIAL", value);
            try
            {
                return new DbExecuter().GetData<Fornecedor>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<Fornecedor>("Erro no banco de dados, contate  administrador", false, null);
            }
        }

        public Response Existe(int iD)
        {
            string sql = $"SELECT * FROM FORNECEDORES WHERE ID = @ID";
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", iD);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    return new("Fornecedor existe!\r\n", true);
                return new("Fornecedor não existe!\r\n", false);
            }
            catch (Exception ex)
            {
                return new("Erro no banco de dados, contate  administrador", false);
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
