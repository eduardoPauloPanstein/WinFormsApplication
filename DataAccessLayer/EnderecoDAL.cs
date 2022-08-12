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
    public class EnderecoDAL : ConnectionSQL
    {
        //SingleResponse<int>
        public Response Insert(Endereco endereco)
        {
            string sql = $"INSERT INTO ENDERECOS (CEP,NUMERO) VALUES (@CEP,@NUMERO); select scope_identity()";

            SqlConnection connection = GetConnection();

            SqlCommand command = new SqlCommand(sql, connection);
            //SqlCommand commandGetID = new SqlCommand("SELECT MAX(ID) FROM ENDERECOS;", connection);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);
            command.Parameters.AddWithValue("@NUMERO", endereco.Numero);

            try
            {
                connection.Open();
                endereco.ID = Convert.ToInt32(command.ExecuteScalar());
                //int idGerado = Convert.ToInt32(command.ExecuteScalar());
                //commandGetID.ExecuteReader().GetDecimal(1);
                //return new SingleResponse<int>("Endereço cadastrado com sucesso", true, idGerado);
                return new Response("Endereço cadastrado com sucesso", true);
            }
            catch (Exception ex)
            {

                return new Response("Erro no banco de dados, contate o administrador." + ex, false);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Response Update(Endereco endereco)
        {
            string sql = $"UPDATE ENDERECOS SET CEP = @CEP, NUMERO = @NUMERO WHERE ID = @ID ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);
            command.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            command.Parameters.AddWithValue("@ID", endereco.ID);

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
    }
}
