using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace DataAccessLayer
{
    //public class FuncionarioDAL : ConnectionSQL, ICRUD<Funcionario>, IFuncionarioService
    public class FuncionarioDAL : ConnectionSQL
    {
        
        public Response Insert(Funcionario funcionario)
        {
            string sql = $"INSERT INTO FUNCIONARIOS (NOME,CPF,RG,TELEFONE,EMAIL,ENDERECO,SENHA)" +
                         $" VALUES (@NOME,@CPF,@RG,@TELEFONE,@EMAIL,@ENDERECO,@SENHA)";
            //NOME CPF RG TELEFONE EMAIL ENDERECO SENHA
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@ENDERECO", funcionario.Endereco.ID);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);

            try
            {
                DbExecuter.Execute(command);
                return new Response("Funcionário cadastrado com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_FUNCIONARIOS_EMAIL"))
                {
                    return new Response("Email já está em uso.", false);
                }
                if (ex.Message.Contains("UQ_FUNCIONARIOS_CPF"))
                {
                    return new Response("CPF já está em uso.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }

        }

        public void ConferirDefault(string senha)
        {
            string sql = "SELECT COUNT(ID) FROM FUNCIONARIOS";
            string sql1 = $"INSERT INTO ENDERECOS VALUES(11111111,11) INSERT INTO FUNCIONARIOS" +
                  " VALUES ('ADMIN',11111111111,11111111111,11111111111,'ADMIN',(select scope_identity()),@SENHA,1,1);";
            SqlCommand command = new SqlCommand(sql);
            SqlCommand command1 = new SqlCommand(sql1);
            command1.Parameters.AddWithValue("@SENHA", senha);
            //The COUNT() function returns the number of rows that matches a specified criterion.

            try
            {              
                int qtdFuncionaios = DbExecuter.ExecuteScalar(command);
                if (qtdFuncionaios == 0)
                {
                    DbExecuter.Execute(command1);
                }
                //
            }
            catch (Exception ex)
            {
                //
            }
        }

        public Response Delete(int iD)
        {
            string sql = $"DELETE FROM FUNCIONARIOS WHERE ID = @ID";
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

        public DataResponse<Funcionario> GetByValue(string value)
        {
            int funcionarioID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            string sql = $"SELECT F.ID,F.NOME,F.CPF,F.RG,F.TELEFONE,F.EMAIL,E.CEP,E.NUMERO,F.SENHA,F.ATIVO" +
                $" FROM FUNCIONARIOS F INNER JOIN ENDERECOS E ON F.ENDERECO = E.ID WHERE F.ID = @ID OR F.NOME LIKE '%'+@NOME+'%'";

            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", funcionarioID);
            command.Parameters.AddWithValue("@NOME", value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Funcionario> funcionarios = new();
                //Enquanto houver registros, o loop será executado!
                while (reader.Read())
                {
                    Funcionario funcionario = new();
                    Endereco endereco = new();
                    funcionario.ID = Convert.ToInt32(reader["ID"]);
                    funcionario.Nome = Convert.ToString(reader["NOME"]);
                    funcionario.CPF = Convert.ToString(reader["CPF"]);
                    funcionario.RG = Convert.ToString(reader["RG"]);
                    funcionario.Telefone = Convert.ToString(reader["TELEFONE"]);
                    funcionario.Email = Convert.ToString(reader["EMAIL"]);
                    endereco.CEP = Convert.ToString(reader["CEP"]);
                    endereco.Numero = Convert.ToString(reader["NUMERO"]);
                    funcionario.Senha = Convert.ToString(reader["SENHA"]);
                    funcionario.Ativo = (bool)reader["ATIVO"];
                    funcionario.Endereco = endereco;

                    funcionarios.Add(funcionario);
                }
                return new DataResponse<Funcionario>("Funcionários selecionados com sucesso!", true, funcionarios);
            }
            catch (Exception ex)
            {
                return new DataResponse<Funcionario>("Erro no banco de dados, contate o administrador", false, null);
            }
            finally
            {
                connection.Dispose();
            }

        }
        /// <summary>
        /// Verifica a partir de um ID se funcionario existe no banco de dados
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public Response Existe(int iD)
        {
            string sql = $"SELECT * FROM FUNCIONARIOS WHERE ID = @ID";
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", iD);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    return new("Funcionario existe!\r\n", true);
                return new("Funcionario não existe!\r\n", false);
            }
            catch (Exception ex)
            {
                return new("Erro no banco de dados, contate o administrador", false);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Response UpdateSenha(int iD, string senha)
        {
            string sql = $"UPDATE FUNCIONARIOS SET SENHA = @SENHA WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@SENHA", senha);
            command.Parameters.AddWithValue("@ID", iD);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_SENHA"))
                {
                    return new Response("Senha repetida.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        public SingleResponse<int> getEnderecoID(int funcionarioID)
        {
            string sql = $"SELECT ENDERECO FROM FUNCIONARIOS WHERE ID = @ID";

            SqlConnection connection = GetConnection();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", funcionarioID);

            try
            {
                connection.Open();
                int enderecoID = Convert.ToInt32(command.ExecuteScalar());
                return new SingleResponse<int>("ID do endereço pego com sucesso", true, enderecoID);
            }
            catch (Exception ex)
            {

                return new SingleResponse<int>("Erro no banco de dados, contate o administrador." + ex, false, 0);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Response Login(string email, string senha)
        {
            using (var connection = GetConnection())
            {

                //faz com que o código fique mais estruturado, evitando a necessidade de se utilizar o try/finaly,
                //pois o compilador traduz o using para a instrução try/finaly. Ao utilizarmos o using tudo acontece
                //automaticamente, ou seja, o objeto é liberado automaticamente, sem o risco de esquecer de colocar o Dispose().
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM FUNCIONARIOS where EMAIL=@EMAIL and SENHA=@SENHA";
                    command.Parameters.AddWithValue("@EMAIL", email);
                    command.Parameters.AddWithValue("@SENHA", senha);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            FuncionarioLogado.ID = reader.GetInt32(0);
                            FuncionarioLogado.Nome = reader.GetString(1);
                            int cargo = reader.GetInt32(9);
                            if (cargo == 1)
                            {
                                FuncionarioLogado.ISADM = true;
                            }
                        }
                        return new Response("Credenciais para login validadas com sucesso.", true);
                    }
                    else
                        return new Response("Credenciais para login inválidas.", false);                   
                }
            }
        }
        public DataResponse<Funcionario> GetAllView()
        {
            string sql = $"SELECT F.ID,F.NOME,F.CPF,F.RG,F.TELEFONE,F.EMAIL,E.CEP,E.NUMERO,F.SENHA,F.ATIVO" +
                $" FROM FUNCIONARIOS F INNER JOIN ENDERECOS E ON F.ENDERECO = E.ID";
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Funcionario> funcionarios = new();

                while (reader.Read())
                {
                    Funcionario funcionario = new();
                    Endereco endereco = new();
                    funcionario.ID = Convert.ToInt32(reader["ID"]);
                    funcionario.Nome = Convert.ToString(reader["NOME"]);
                    funcionario.CPF = Convert.ToString(reader["CPF"]);
                    funcionario.RG = Convert.ToString(reader["RG"]);
                    funcionario.Telefone = Convert.ToString(reader["TELEFONE"]);
                    funcionario.Email = Convert.ToString(reader["EMAIL"]);
                    endereco.CEP = Convert.ToString(reader["CEP"]);
                    endereco.Numero = Convert.ToString(reader["NUMERO"]);
                    funcionario.Senha = Convert.ToString(reader["SENHA"]);
                    funcionario.Ativo = (bool)reader["ATIVO"];
                    funcionario.Endereco = endereco;

                    funcionarios.Add(funcionario);
                }
                return new DataResponse<Funcionario>("Categorias selecionados com sucesso!", true, funcionarios);
            }
            catch (Exception ex)
            {
                return new DataResponse<Funcionario>("Erro no banco de dados, contate  administrador", false, null);
            }
            finally
            {
                connection.Dispose();
            }
        }
        public Response Update(Funcionario funcionario)
        {
            //fazer update de ativo/desativo aqui? ou deixar separado
            string sql = $"UPDATE FUNCIONARIOS SET NOME = @NOME,CPF = @CPF,RG = @RG,TELEFONE = @TELEFONE,EMAIL = @EMAIL WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@ID", funcionario.ID);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_FUNCIONARIOS_EMAIL"))
                {
                    return new Response("Email já está em uso.", false);
                }
                if (ex.Message.Contains("UQ_FUNCIONARIOS_CPF"))
                {
                    return new Response("CPF já está em uso.", false);
                }
                //SE NAO ENTROU EM NENHUM IF DE CIMA, SÓ PODE SER UM ERRO DE INFRAESTRUTURA
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }


        public Response ChangeAtivo(int id, bool ativo)
        {
            string sql = $"UPDATE FUNCIONARIOS SET ATIVO = @ATIVO WHERE ID = @ID ";

            int numAtivo;
            if (ativo) numAtivo = 1;
            else numAtivo = 0;

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@ATIVO", numAtivo);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Ativo do fornecedor alterado com sucesso.", true);
            }
            catch (Exception ex)
            {
                //Quais expetion podem ocorrer aqui?
                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }
        }
    }
}
