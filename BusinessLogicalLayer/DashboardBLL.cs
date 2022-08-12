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
    public class DashboardBLL : IDashboard
    {
        DashboardDAL dl = new();

        public SingleResponse<int> GetNumTotalClientes()
        {
            return dl.GetNumTotalClientes();
        }

        public SingleResponse<int> GetNumTotalFuncionarios()
        {
            return dl.GetNumTotalFuncionarios();
        }

        public SingleResponse<int> GetNumTotalVendas()
        {
            return dl.GetNumTotalVendas();
        }

        public DataResponse<ProdutoViewDash> GetProdutosEstoqueBaixo()
        {
            return dl.GetProdutosEstoqueBaixo();
        }

        public DataResponse<ProdutoViewDash> GetTopProdutos(int x)
        {
            return dl.GetTopProdutos(x);
        }

        public SingleResponse<double> GetValorVendas(DataFiltro dt)
        {
            return dl.GetValorVendas(dt);
        }
    }
}
