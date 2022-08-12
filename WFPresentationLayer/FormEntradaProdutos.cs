using BusinessLogicalLayer;
using Entities;
using Shared;
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
    public partial class FormEntradaProdutos : Form
    {
        public FormEntradaProdutos()
        {
            InitializeComponent();
        }

        readonly ProdutoBLL produtoBLL = new();
        FornecedorBLL fornecedorBLL = new();
        EntradaBLL entradaBLL = new();
        //Entrada entrada = new();
        BindingList<Item> items = new();
        Validator validator = new();
        private void FormEntradaProdutos_Load(object sender, EventArgs e)
        {
            AtualizarData();
            tabControl1.TabPages.Remove(tabPage2);
            dtpFim.Value = DateTime.Now.AddDays(1);
            dtpIncio.Value = DateTime.Now.AddDays(-6);
        }

        private void AtualizarData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = items;
            dataGridViewHistorico.DataSource = entradaBLL.LerEntradas(dtpIncio.Value, dtpFim.Value).Dados;

            double valorTotal = 0;
            foreach (var item in items)
            {
                valorTotal += (item.Preco * item.Qtd);
            }
            txtValorTotal.Text = valorTotal.ToString("C2");
        }

        private void btnAdcionar_Click(object sender, EventArgs e)
        {
            foreach (var i in items)
            {
                if (i.IDProduto == produtoSelecionado.ID)
                {
                    MessageBox.Show("Produto já adcionado na lista, por favor altere apenas a quantidade");
                    return;
                }
            }

            string spreco = Normatization.NormatizeDinheiro(txtPreco.Text);
            double preco = double.TryParse(spreco, out _) ? Convert.ToDouble(spreco) : 0;
            double quantidade = Convert.ToDouble(nudQuantidade.Value);
            Item item = new() {
                IDProduto = produtoSelecionado.ID,
                Nome = produtoSelecionado.Nome_Produto,
                Preco = preco, Qtd = quantidade
            };
            //validatorItem conferir
            Response response = validator.ValidateItem(item);
            if (response.HasSuccess)
            {
                items.Add(item);
                txtPreco.ResetText();
                nudQuantidade.Value = 0;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
            AtualizarData();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string total = Normatization.NormatizeDinheiro(txtValorTotal.Text);
            double valorTotal = Convert.ToDouble(total);

            Entrada entrada = new()
            {
                IDFornecedor = fornecedorSelecionado.ID,
                IDFuncionario = FuncionarioLogado.ID,
                Data = dateTimePicker1.Value,
                ValorTotal = valorTotal,
                Items = items.ToList() 
            };
            Response response = entradaBLL.EfetuarEntrada(entrada);
            if (response.HasSuccess)
            {
                items.Clear();
                AtualizarData();
            }
            MessageBox.Show(response.Message);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
            AtualizarData();
        }

        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            AtualizarData();
        }

        private void dtpIncio_ValueChanged(object sender, EventArgs e)
        {
            AtualizarData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            if (items.Count > 0) items.Remove(items[dataGridView1.CurrentRow.Index]);
            AtualizarData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _linhaIndice = e.RowIndex;
            if (_linhaIndice == -1)
            {
                return;
            }

        }
        private Produto produtoSelecionado = new();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormProdutos formProdutos = new(true);
            AbrirForm(formProdutos);
            produtoSelecionado = formProdutos.ProdutoSelecionado;
            if (produtoSelecionado != null)
            {
                txtProduto.Text = $"{produtoSelecionado.Nome_Produto}";
            }
        }
        private void AbrirForm(Form formulario)
        {
            formulario.TopLevel = true;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            //formulario.WindowState = FormWindowState.Maximized;
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            formulario.BringToFront();
        }
        private Fornecedor fornecedorSelecionado = new();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormFornecedores formFornecedores = new(true);
            AbrirForm(formFornecedores);
            fornecedorSelecionado = formFornecedores.FornecedorSelecionado;
            if (produtoSelecionado != null)
            {
                txtFornecedor.Text = $"{fornecedorSelecionado.Razao_Social}";
            }
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
