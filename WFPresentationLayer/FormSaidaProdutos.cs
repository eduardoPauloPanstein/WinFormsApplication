using BusinessLogicalLayer;
using Entities;
using Entities.Enums;
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
    public partial class FormSaidaProdutos : Form
    {
        public FormSaidaProdutos()
        {
            InitializeComponent();
        }
        readonly ProdutoBLL produtoBLL = new();
        ClienteBLL clienteBLL = new();
        SaidaBLL saidaBLL = new();
        BindingList<Item> items = new();
        Validator validator = new();
        private void FormVendaProdutos_Load(object sender, EventArgs e)
        {
            AtualizarData();
            AtualizarcbFormaPagamento();
            dtpFim.Value = DateTime.Now.AddDays(1);
            dtpIncio.Value = DateTime.Now.AddDays(-6);
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void AtualizarcbFormaPagamento()
        {
            cbFormaPagamento.DataSource = BusinessLogicalLayer.Enum.EnumToList<FormasPagamento>();
            cbFormaPagamento.DropDownStyle = ComboBoxStyle.DropDownList;           
        }
        //private void AtualizarcbProduto()
        //{
        //    cbProduto.DataSource = produtoBLL.GetAllView().Dados; //Get where ATIVO
        //    cbProduto.DisplayMember = "Nome_Produto"; // + "Laboratorio.Nome"
        //    cbProduto.ValueMember = "ID";
        //    cbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
        //}
        private void AtualizarData()
        {
            dataGridView1.DataSource = items;
            dataGridViewHistorico.DataSource = saidaBLL.LerSaidas(dtpIncio.Value, dtpFim.Value).Dados;

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

            double quantidade = Convert.ToDouble(nudQuantidade.Value);
            Item item = new()
            {
                IDProduto = produtoSelecionado.ID,
                Nome = produtoSelecionado.Nome_Produto,
                Preco = produtoSelecionado.Preco_Venda,
                Qtd = quantidade
            };
            Response response = validator.ValidateItem(item);
            if (response.HasSuccess)
            {
                items.Add(item);
                //txtQuantidade.ResetText();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
            AtualizarData();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //if (items.Any())
            //{
            //    MessageBox.Show("Sem itens para registrar");
            //    return;
            //}

            txtValorTotal.Text = Normatization.NormatizeDinheiro(txtValorTotal.Text);
            double valorTotal = Convert.ToDouble(txtValorTotal.Text);

            FormasPagamento pagamento = (FormasPagamento)cbFormaPagamento.SelectedItem;
            Saida saida = new()
            {
                IDCLIENTE = clienteSelecionado.ID,
                IDFuncionario = FuncionarioLogado.ID,
                Data = dateTimePicker1.Value,
                ValorTotal = valorTotal,
                Forma_Pagamento = pagamento.ToString(),
                Items = items.ToList(),
            };
            //validar separado primeiro ou efetuar saida e caso não for pago deletar
            Response response = saidaBLL.EfetuarSaida(saida);
            if (response.HasSuccess)
            {
                if (MessageBox.Show(response.Message, "Confirmar pagamento",MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    MessageBox.Show("Venda finalizada com sucesso! Obrigado :)");
                    //deletar ultimo registro
                }
                else
                {
                    saidaBLL.Deletar(saida.ID);
                }
                items.Clear();
                AtualizarData();
            }
            else MessageBox.Show(response.Message);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _linhaIndice = e.RowIndex;
            if (_linhaIndice == -1)
            {
                return;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }
        private Cliente clienteSelecionado = new();
        private void button1_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new(true);
            AbrirForm(formClientes);
            clienteSelecionado = formClientes.ClienteSelecionado;
            if (clienteSelecionado != null)
            {
                txtCliente.Text = $"{clienteSelecionado.Nome}";
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            //if (items.Count > 0) items.Remove(items.Last());
            if (items.Count > 0) items.Remove(items[dataGridView1.CurrentRow.Index]);
            AtualizarData();
        }
        private Produto produtoSelecionado = new();
        private void button2_Click(object sender, EventArgs e)
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

        private void dtpFim_ValueChanged_1(object sender, EventArgs e)
        {
            AtualizarData();
        }
    }
}
