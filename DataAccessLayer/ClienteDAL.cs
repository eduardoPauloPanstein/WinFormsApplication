using Entities;
using Shared;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ClienteDAL : ConnectionSQL
    {

        public Response Insert(Cliente cliente)
        {
            string sql = $"INSERT INTO CLIENTES (NOME,CPF,RG,TELEFONE_UM,TELEFONE_DOIS,EMAIL) VALUES (@NOME,@CPF,@RG,@TELEFONE_UM,@TELEFONE_DOIS,@EMAIL)";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@RG", cliente.RG);
            command.Parameters.AddWithValue("@TELEFONE_UM", cliente.Telefone_Um);
            command.Parameters.AddWithValue("@TELEFONE_DOIS", cliente.Telefone_Dois);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Cliente cadastrado com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_CLIENTES_EMAIL"))
                {
                    return new Response("Email já está em uso.", false);
                }
                if (ex.Message.Contains("UQ_CLIENTES_CPF"))
                {
                    return new Response("CPF já está em uso.", false);
                }
                //SE NAO ENTROU EM NENHUM IF DE CIMA, SÓ PODE SER UM ERRO DE INFRAESTRUTURA
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }

        public Response Delete(int iD)
        {
            string sql = $"DELETE FROM CLIENTES WHERE ID = @ID";
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

        public void ConferirDefault()
        {
            string sql = "SELECT COUNT(ID) FROM CLIENTES";
            string sql1 = "INSERT INTO CLIENTES VALUES('CLIENTE_PADRAO', 11111111111,111111111,11111111111,11111111111,'clientepadrao@gmail.com',0,1)";

            SqlCommand command = new SqlCommand(sql);
            SqlCommand command1 = new SqlCommand(sql1);

            try
            {

                int qtdClientes = DbExecuter.ExecuteScalar(command);
                if (qtdClientes == 0)
                {
                    DbExecuter.Execute(command1);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public SingleResponse<Cliente> GetByID(int iD)
        {
            string sql = $"SELECT ID,NOME,CPF,RG,TELEFONE_UM," +
    $"TELEFONE_DOIS,EMAIL,PONTOS,ATIVO FROM CLIENTES WHERE ID = @ID";

            SqlCommand command = new(sql);
            command.Parameters.AddWithValue("@ID", iD);
            try
            {
                return DbExecuter.GetItem<Cliente>(command);
            }
            catch (Exception)
            {
                return new SingleResponse<Cliente>("Erro no banco de dados, contate o administrador.", false, null);
            }
        }

        public Response Update(Cliente cliente)
        {
            string sql = $"UPDATE CLIENTES SET NOME = @NOME, CPF = @CPF,RG = @RG,TELEFONE_UM = @TELEFONE_UM,TELEFONE_DOIS = @TELEFONE_DOIS,EMAIL = @EMAIL, PONTOS = @PONTOS WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@RG", cliente.RG);
            command.Parameters.AddWithValue("@TELEFONE_UM", cliente.Telefone_Um);
            command.Parameters.AddWithValue("@TELEFONE_DOIS", cliente.Telefone_Dois);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            command.Parameters.AddWithValue("@PONTOS", cliente.Pontos);
            command.Parameters.AddWithValue("@ID", cliente.ID);

            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_CLIENTES_EMAIL"))
                {
                    return new Response("Email já está em uso.", false);
                }
                if (ex.Message.Contains("UQ_CLIENTES_CPF"))
                {
                    return new Response("CPF já está em uso.", false);
                }
                //SE NAO ENTROU EM NENHUM IF DE CIMA, SÓ PODE SER UM ERRO DE INFRAESTRUTURA
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        public Response Desativar(int id)
        {
            string sql = $"UPDATE CLIENTES SET ATIVO = 0 WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Cliente desativado.", true);
            }
            catch (Exception ex)
            {
               //Quais expetion podem ocorrer aqui?
                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }
        }
        public Response Ativar(int id)
        {
            string sql = $"UPDATE CLIENTES SET ATIVO = 1 WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Cliente ativado.", true);
            }
            catch (Exception ex)
            {
                //Quais expetion podem ocorrer aqui?
                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }
        }

        public DataResponse<Cliente> GetAll()
        {
            string sql = $"SELECT ID,NOME,CPF,RG,TELEFONE_UM," +
                $"TELEFONE_DOIS,EMAIL,PONTOS,ATIVO FROM CLIENTES";

          
            SqlCommand command = new SqlCommand(sql);
            try
            {
                return new DbExecuter().GetData<Cliente>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<Cliente>("Erro no banco de dados, contate o administrador", false, null);
            }
        }
        /// <summary>
        /// Get by name or ID
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataResponse<Cliente> GetByValue(string value)
        {
            int clienteID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            string sql = $"SELECT ID,NOME,CPF,RG,TELEFONE_UM," +
                $"TELEFONE_DOIS,EMAIL,PONTOS,ATIVO FROM CLIENTES WHERE ID = @ID OR NOME LIKE '%'+@NOME+'%'";            

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", clienteID);
            command.Parameters.AddWithValue("@NOME", value);
            try
            {
                return new DbExecuter().GetData<Cliente>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<Cliente>("Erro no banco de dados, contate o administrador", false, null);
            }
        }
        public Response Existe(int iD)
        {
            string sql = $"SELECT * FROM CLIENTES WHERE ID = @ID";
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", iD);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    return new ("Cliente existe!\r\n", true);
                return new("Cliente não existe!\r\n", false);
            }
            catch (Exception ex)
            {
                return new ("Erro no banco de dados, contate o administrador", false);
            }
            finally
            {
                connection.Dispose();
            }
        }

    }
}