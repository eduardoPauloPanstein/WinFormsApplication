using BusinessLogicalLayer.Utilidades;
using DataAccessLayer;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class FuncionarioBLL : ICRUD<Funcionario>
    {
        Validator validator = new Validator();
        private FuncionarioDAL funcionarioDAL = new();
        private EnderecoDAL enderecoDAL = new();

        public Response Insert(Funcionario item)
        {               
            Response response = validator.ValidateFuncionario(item);
            if (response.HasSuccess)
            {
                item.Senha = HashGenerator.ComputeSha256Hash(item.Senha);
                using (TransactionScope scope = new())
                {
                    response = enderecoDAL.Insert(item.Endereco);
                    response = funcionarioDAL.Insert(item);
                    if (!response.HasSuccess) return response;
                    //COMIT
                    scope.Complete();
                }
            }
            return response;
        }


        public Response Update(Funcionario item)
        {
            Response response = validator.ValidateEndereco(item.Endereco);
            if (!response.HasSuccess) return response;

            item.Endereco.ID = (funcionarioDAL.getEnderecoID(item.ID)).Item;
            response = validator.ValidateFuncionario(item);
            if (!response.HasSuccess) return response;

            response = funcionarioDAL.Existe(item.ID);
            if (!response.HasSuccess) return response;

            string senha = item.Senha;

            using (TransactionScope scope = new())
            {
                if (!string.IsNullOrWhiteSpace(senha))
                {
                    senha = HashGenerator.ComputeSha256Hash(senha);
                    funcionarioDAL.UpdateSenha(item.ID, senha);
                }         
                response = enderecoDAL.Update(item.Endereco);
                response = funcionarioDAL.Update(item);
                if (!response.HasSuccess) return response;
                scope.Complete();
            }
            return response;
        }

        public DataResponse<Funcionario> GetAllView()
        {
            return funcionarioDAL.GetAllView();
        }

        public DataResponse<Funcionario> GetByValue(string value)
        {
            DataResponse<Funcionario> response = funcionarioDAL.GetByValue(value);
            return response;
        }

        public Response ChangeAtivo(int id, bool ativo)
        {
            return funcionarioDAL.ChangeAtivo(id, ativo);
        }

        public Response Delete(int ID)
        {
            return funcionarioDAL.Delete(ID);
        }
    }
}
