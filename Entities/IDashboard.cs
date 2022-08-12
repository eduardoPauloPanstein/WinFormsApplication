using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IDashboard
    {
        public SingleResponse<int> GetNumTotalClientes();
        public SingleResponse<int> GetNumTotalFuncionarios();
        public SingleResponse<int> GetNumTotalVendas();
        /// <summary>
        /// Valor total das vendas dentro de um periodo filtrado
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>valor em reais</returns>
        public SingleResponse<double> GetValorVendas(DataFiltro dt);
        /// <summary>
        /// TOP X produtos mais vendidos(nome + quantidade de vendas dele)
        /// </summary>
        /// <param name="x">valor da quantidade de produtos a serem rankeados</param>
        /// <returns></returns>
        public DataResponse<ProdutoViewDash> GetTopProdutos(int x);
        public DataResponse<ProdutoViewDash> GetProdutosEstoqueBaixo();
    }
}
