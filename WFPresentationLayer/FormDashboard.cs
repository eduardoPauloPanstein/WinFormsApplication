using BusinessLogicalLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        //readonly Dashboard dashboard = new();
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            CarregarTextos(dashboard);
            CarregarTabelas(dashboard);
        }
        private void GridViewConfig(DataGridView d)
        {
            d.BackgroundColor = this.BackColor;
            d.RowsDefaultCellStyle.SelectionBackColor = this.BackColor;
            d.RowsDefaultCellStyle.SelectionForeColor = this.ForeColor;
            d.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            d.AllowUserToResizeColumns = false;
            d.ReadOnly = true;
        }
        private void CarregarTabelas(Dashboard dashboard)
        {
            dgvTopProdutos.DataSource = dashboard.TopProdutos;
            GridViewConfig(dgvTopProdutos);

            dgvEstoqueBaixo.DataSource = dashboard.ProdutosEstoqueBaixo;
            GridViewConfig(dgvEstoqueBaixo);
        }
        private void CarregarTextos(Dashboard dashboard)
        {
            txtQtdClientes.Text = $"{dashboard.NumClientes} CLIENTES";
            txtQtdFuncionarios.Text = $"{dashboard.NumFuncionarios} FUNCIONARIOS";
            txtQtdVendas.Text = $"{dashboard.NumVendas} VENDAS";

            bool i = Convert.ToBoolean(new Random().Next(0,2));
            if (i)
                txtValorVendas.Text = $"{dashboard.ValorVendasHoje.ToString("C2")} EM VENDAS HOJE";
            else
                txtValorVendas.Text = $"{dashboard.ValorVendasSemana.ToString("C2")} EM VENDAS NOS ULTIMOS 7 DIAS";
        }

        private void bbtnAtualizar_Click(object sender, EventArgs e)
        {
            FormDashboard_Load(sender, e);
        }
        
    }
}
