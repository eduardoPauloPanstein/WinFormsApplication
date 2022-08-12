using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class Dashboard
    {
        public int NumClientes { get; private set; }
        public int NumFuncionarios { get; private set; }
        public int NumVendas { get; private set; }
        public double ValorVendasHoje { get; private set; }
        public double ValorVendasSemana { get; private set; }

        //public Dictionary<string, int> TopProdutos { get; private set; }
        public List<ProdutoViewDash> TopProdutos { get; private set; }
        public List<ProdutoViewDash> ProdutosEstoqueBaixo { get; private set; }

        public Dashboard()
        {
            GetNums();
            GetList();
        }

        readonly DashboardBLL d = new();
        private void GetNums()
        {
            this.NumClientes = d.GetNumTotalClientes().Item;
            this.NumFuncionarios = d.GetNumTotalFuncionarios().Item;
            this.NumVendas = d.GetNumTotalVendas().Item;

            this.ValorVendasHoje = d.GetValorVendas(new DataFiltro(1)).Item;
            this.ValorVendasSemana = d.GetValorVendas(new DataFiltro(7)).Item;
        }
        private void GetList()
        {
            this.TopProdutos = d.GetTopProdutos(5).Dados;
            this.ProdutosEstoqueBaixo = d.GetProdutosEstoqueBaixo().Dados;
        }

    }
}
