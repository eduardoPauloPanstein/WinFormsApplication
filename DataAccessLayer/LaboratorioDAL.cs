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
    public class LaboratorioDAL : ConnectionSQL
    {
        public Response Insert(Laboratorio laboratorio)
        {
            string sql = $"INSERT INTO LABORATORIOS (NOME, CNPJ) VALUES (@NOME, @CNPJ)";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME", laboratorio.Nome);
            command.Parameters.AddWithValue("@CNPJ", laboratorio.CNPJ);
            try
            {
                DbExecuter.Execute(command);
                return new Response("Laboratório cadastrado com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_LABORATORIOS_CNPJ"))
                {
                    return new Response("CNPJ já cadastrado.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        public DataResponse<Laboratorio> GetByValue(string value)
        {
            int laboratorioID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            string sql = $"SELECT ID,NOME,CNPJ,ATIVO FROM LABORATORIOS WHERE ID = @ID OR NOME = @NOME";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ID", laboratorioID);
            command.Parameters.AddWithValue("@NOME", value);
            try
            {
                return new DbExecuter().GetData<Laboratorio>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<Laboratorio>("Erro no banco de dados, contate  administrador", false, null);
            }
        }
        public Response Update(Laboratorio laboratorio)
        {
            string sql = $"UPDATE LABORATORIOS SET NOME = @NOME, CNPJ = @CNPJ, ATIVO = @ATIVO WHERE ID = @ID";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@NOME", laboratorio.Nome);
            command.Parameters.AddWithValue("@CNPJ", laboratorio.CNPJ);
            command.Parameters.AddWithValue("@ATIVO", laboratorio.Ativo);
            command.Parameters.AddWithValue("@ID", laboratorio.ID);
       
            try
            {
                DbExecuter.Execute(command);
                return new Response("Dados atualizados com sucesso.", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_LABORATORIOS_CNPJ"))
                {
                    return new Response("CNPJ já cadastrado.", false);
                }
                return new Response("Erro no banco de dados, contate o administrador.", false);
            }
        }
        public DataResponse<Laboratorio> GetAllView()
        {
            string sql = $"SELECT ID,NOME,CNPJ,ATIVO FROM LABORATORIOS";
            SqlCommand command = new SqlCommand(sql);
            try
            {
                return new DbExecuter().GetData<Laboratorio>(command);
            }
            catch (Exception ex)
            {
                return new DataResponse<Laboratorio>("Erro no banco de dados, contate o administrador", false, null);
            }
        }
        public Response Delete(int iD)
        {
            string sql = $"DELETE FROM LABORATORIOS WHERE ID = @ID";
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
    }
}
