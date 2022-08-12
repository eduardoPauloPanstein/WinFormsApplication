using DataAccessLayer;
using Entities;
using Shared;

namespace BusinessLogicalLayer
{
    public class ClienteBLL : ICRUD<Cliente>
    {

        private ClienteDAL clienteDAL = new ClienteDAL();
        private Validator validator = new Validator();

        public Response Insert(Cliente item)
        {
            Response response = validator.ValidateCliente(item);
            if (response.HasSuccess)
            {
                return clienteDAL.Insert(item);
            }
            return response;

        }

        public Response Update(Cliente item)
        {
            Response response = validator.ValidateCliente(item);
            if (response.HasSuccess)
            {
                return clienteDAL.Update(item);
            }
            return response;
        }
        public Response Desativar(int id)
        {
            return clienteDAL.Desativar(id);
        }

        public DataResponse<Cliente> GetAll()
        {
            return clienteDAL.GetAll();
        }
        public DataResponse<Cliente> GetByValue(string value)
        {
            return clienteDAL.GetByValue(value.Trim());
        }

        public Response Ativar(int id)
        {
            return clienteDAL.Ativar(id);
        }

        public DataResponse<Cliente> GetAllView()
        {
            throw new NotImplementedException();
        }

        public Response Delete(int ID)
        {
            return clienteDAL.Delete(ID);
        }
    }
}