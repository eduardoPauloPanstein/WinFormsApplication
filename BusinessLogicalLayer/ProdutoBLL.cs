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
    public class ProdutoBLL : ICRUD<Produto>
    {

        private ProdutoDAL produtoDAL = new ();
        private Validator validator = new ();//passar para static

        public Response Insert(Produto item)
        {
            Response response = validator.ValidateProduto(item);
            if (response.HasSuccess)
            {
                return produtoDAL.Insert(item);
            }
            return response;
        }
        /// <summary>
        /// Para alterar todas/qualquer informações de um produto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Response Update(Produto item)
        {
            Response response = validator.ValidateProduto(item);
            if (response.HasSuccess)
            {
                return produtoDAL.Update(item);
            }
            return response;
        }
        /// <summary>
        /// Para atualizar estoque e preço apos uma entrada 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Response Atualizar(Produto item)
        {
            return produtoDAL.Atualizar(item);
        }

        public DataResponse<Produto> GetByValue(string value)
        {
            value = Normatization.NormatizeName(value);
            if (!string.IsNullOrWhiteSpace(value))
                return produtoDAL.GetByValue(value);
            else return new("Campo da pesquisa está vazio", false, null);
        }
        public SingleResponse<Produto> GetByID(int iD)
        {
            return produtoDAL.GetByID(iD);
        }

        public DataResponse<Produto> GetAllView()
        {
            return produtoDAL.GetAllView();
        }

        public Response Delete(int ID)
        {
            return produtoDAL.Delete(ID);
        }
    }
}