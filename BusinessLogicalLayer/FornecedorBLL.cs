using DataAccessLayer;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FornecedorBLL : ICRUD<Fornecedor>
    {
        private FornecedorDAL fornecedorDAL = new();
        private Validator validator = new();

        public Response Ativar(int id)
        {
            return fornecedorDAL.Ativar(id);
        }

        public Response Delete(int ID)
        {
            return fornecedorDAL.Delete(ID);
        }

        public Response Desativar(int id)
        {
            return fornecedorDAL.Desativar(id);
        }

        public DataResponse<Fornecedor> GetAll()
        {
            return fornecedorDAL.GetAll();
        }

        public DataResponse<Fornecedor> GetAllView()
        {
            throw new NotImplementedException();
        }

        public DataResponse<Fornecedor> GetByValue(string value)
        {
            return fornecedorDAL.GetByValue(value.Trim());
        }

        public Response Insert(Fornecedor item)
        {
            Response response = validator.ValidateFornecedor(item);
            if (response.HasSuccess)
            {
                return fornecedorDAL.Insert(item);
            }
            return response;
        }

        public Response Update(Fornecedor item)
        {
            Response response = validator.ValidateFornecedor(item);
            if (response.HasSuccess)
            {
                return fornecedorDAL.Update(item);
            }
            return response;
        }
    }
}
