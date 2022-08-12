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
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
        }
        bool abertoPorOutroForm = false;
        public Produto ProdutoSelecionado { get; set; } //para passar para outros forms se necessario
        private Laboratorio laboratorioSelecionadoEdit = new();
        ProdutoBLL produtoBLL = new();
        LaboratorioBLL laboratorioBLL = new();

        public FormProdutos(bool abertoPorOutroForm)
        {
            InitializeComponent();
            this.abertoPorOutroForm = abertoPorOutroForm;
        }
        private void FormProdutos_Load(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageAdd);
            TabControl.TabPages.Remove(tabPageEdit);
            AtualizarGrid();
        }
        private void AtualizarcbLaboratorio()
        {
            //cbLaboratorio.DataSource = laboratorioBLL.GetAllView().Dados;
            //cbLaboratorio.DisplayMember = "NOME";
            //cbLaboratorio.ValueMember = "ID";
            //cbLaboratorio.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbLaboratorio.Enabled = true;
            //cbLaboratorio.DroppedDown = true;  
        }

        private void DoGrid(List<Produto> produtos)
        {
            foreach (var p in produtos)
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                row.Cells[0].Value = p.ID;
                row.Cells[1].Value = p.Nome_Produto;
                row.Cells[2].Value = p.Descricao;
                row.Cells[3].Value = p.Laboratorio.Nome;
                row.Cells[4].Value = p.Qtd_Estoque;
                row.Cells[5].Value = p.Preco_Base;
                row.Cells[6].Value = p.Margem_Lucro;
                row.Cells[7].Value = p.Preco_Venda;
                row.Cells[8].Value = p.Ativo;

            }
        }
        private void AtualizarGrid()
        {
            dataGridView1.Rows.Clear();
            DataResponse<Produto> dataResponse = produtoBLL.GetAllView();
            if (dataResponse.HasSuccess) DoGrid(dataResponse.Dados);
        }
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string procurar = txtProcurar.Text;

            if (string.IsNullOrWhiteSpace(procurar) || procurar == "NOME OU ID")
            {
                AtualizarGrid(); return;
            }

            DataResponse<Produto> dataResponse = produtoBLL.GetByValue(txtProcurar.Text);
            List<Produto> produtos = dataResponse.Dados;

            if (dataResponse.HasSuccess)
                DoGrid(produtos);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            lblErros.Text = "";
            lblErros.Visible = false;
            VoltarTab();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Laboratorio laboratorio = new() { ID = (int)cbLaboratorio.SelectedValue };

            if (!Double.TryParse(txtPrecoBase.Text, out _))
            {
                MessageBox.Show("Insira um preço base");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLab.Text))
            {
                MessageBox.Show("Insira um laboratório");
                return;
            }

            Produto produto = new()
            {
                Nome_Produto = txtNome.Text,
                Descricao = txtDescricao.Text,
                Laboratorio = laboratorioSelecionadoAdd,
                Margem_Lucro = Convert.ToDouble(txtML.Text),
                Preco_Base = Convert.ToDouble(txtPrecoBase.Text)
            };
            Response response = produtoBLL.Insert(produto);
            if (response.HasSuccess)
            {
                MessageBox.Show(response.Message);
                Limpar();
                lblErros.Text = "";
                lblErros.Visible = false;
                AtualizarGrid();
            }
            else
            {
                lblErros.Text = response.Message;
                lblErros.Visible = true;
            }
        }
        private void Limpar()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtPrecoBase.Clear();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "NOME OU ID")
            {
                txtProcurar.Text = "";
            }
        }

        private void btnAdcionar1_Click_1(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageProdutos);
            TabControl.TabPages.Add(tabPageAdd);
            AtualizarcbLaboratorio();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            int _linhaIndice = e.RowIndex;
            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
            {
                return;
            }
            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dataGridView1.Rows[_linhaIndice];
           
            Produto produtoSelecionado = new()
            {
                ID = Convert.ToInt32(rowData.Cells[0].Value.ToString()),
                Nome_Produto = rowData.Cells[1].Value.ToString(),
                Descricao = rowData.Cells[2].Value.ToString(),
                Qtd_Estoque = Convert.ToInt32(rowData.Cells[4].Value.ToString()),
                Preco_Base = Convert.ToInt32(rowData.Cells[5].Value.ToString()),
                Margem_Lucro = Convert.ToInt32(rowData.Cells[6].Value.ToString()),
                Ativo = Convert.ToBoolean(rowData.Cells[8].Value.ToString()),
            };
            string nomeLab = rowData.Cells[3].Value.ToString();
            laboratorioSelecionadoEdit = laboratorioBLL.GetByValue(nomeLab).Dados[0]; 
            PreencherTxts(produtoSelecionado);
            DesativarAtivarTxts(checkBoxAtivo.Checked);

            if (this.abertoPorOutroForm)
            {
                if (!produtoSelecionado.Ativo)
                {
                    MessageBox.Show("Não pode selecionar um produto que não esta ativo.");
                    return;
                }
                this.ProdutoSelecionado = produtoSelecionado;
                this.Close();
            }
        }

        private void PreencherTxts(Produto produto)
        {
            //exibe os valores no textbox
            txtID.Text = produto.ID.ToString();
            txtNomeEdit.Text = produto.Nome_Produto;
            txtDescEdit.Text = produto.Descricao;
            txtLabEdit.Text = $"{laboratorioSelecionadoEdit.ID} - {laboratorioSelecionadoEdit.Nome}";
            txtEstoqueEdit.Text = produto.Qtd_Estoque.ToString();
            txtPrecoBaseEdit.Text = produto.Preco_Base.ToString();
            txtMLEdit.Text = produto.Margem_Lucro.ToString();
            //Preco_Venda.Text = rowData.Cells[7].Value.ToString();
            checkBoxAtivo.Checked = produto.Ativo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            lblErros.Text = "";
            VoltarTab();
        }
        private void VoltarTab()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            TabControl.TabPages.Add(tabPageProdutos);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Laboratorio laboratorio = new() { ID = (int)cbLabEdit.SelectedValue };

            if (!Double.TryParse(txtPrecoBaseEdit.Text, out _))
            {
                MessageBox.Show("Preço invalido");
                return;
            }
            if (!Double.TryParse(txtEstoqueEdit.Text, out _))
            {
                MessageBox.Show("Estoque invalido");
                return;
            }
            Produto produto = new()
            {
                Nome_Produto = txtNomeEdit.Text,
                Descricao = txtDescEdit.Text,
                Laboratorio = laboratorioSelecionadoEdit,
                Margem_Lucro = Convert.ToDouble(txtMLEdit.Text),
                Qtd_Estoque = Convert.ToDouble(txtEstoqueEdit.Text),
                Preco_Base = Convert.ToDouble(txtPrecoBaseEdit.Text),
                Ativo = checkBoxAtivo.Checked,
                ID = Convert.ToInt32(txtID.Text)
            };
            Response response = produtoBLL.Update(produto);

            if (response.HasSuccess)
            {
                MessageBox.Show(response.Message);
                Limpar();
                lblErrosEdit.ResetText();
                lblErrosEdit.Visible = false;
                AtualizarGrid();
                btnVoltar_Click(sender, EventArgs.Empty);
            }
            else
            {
                lblErrosEdit.Text = response.Message;
                lblErrosEdit.Visible = true;
            }
        }

        private void checkBoxAtivo_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAtivo = checkBoxAtivo.Checked;
            //int produtoID = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
            //produtoBLL.ChangeAtivo(produtoID, checkAtivo);
            DesativarAtivarTxts(checkAtivo);
            //AtualizarGrid();
            //DA PRA CHAMAR O CONFIRMAR CLICK E FAZER O UPDATE PRA TUDO OU SEPARAR NO DAL
            //Que foi o que fiz agora pra produtos, update tudo junto
        }

        /// <summary>
        /// Conferir qual o estado do produto e habilitar ou desabilitar textboxs 
        /// </summary>
        /// <param name="ativoEdit"></param>
        private void DesativarAtivarTxts(bool ativoEdit)
        {
            if (ativoEdit)
            {
                txtNomeEdit.ReadOnly = false;
                txtDescEdit.ReadOnly = false;
                txtPrecoBaseEdit.ReadOnly = false;
                //LAB
                txtMLEdit.ReadOnly = false;
                txtEstoqueEdit.ReadOnly = false;
                return;
            }
            txtNomeEdit.ReadOnly = true;
            txtDescEdit.ReadOnly = true;
            txtPrecoBaseEdit.ReadOnly = true;
            //LAB
            txtMLEdit.ReadOnly = true;
            txtEstoqueEdit.ReadOnly = true;

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //Criar um MessageBox com os botões Sim e Não e deixar o botão 2(Não) selecionado por padrão e comparar o botão apertado
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //rotina de exclusão - confirmar se pode ou não ser excluido; ithk->BLL
                int produtoID = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
                Response response = produtoBLL.Delete(produtoID);
                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarGrid();

        }

        private void txtProcurar_Leave(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "")
            {
                txtProcurar.Text = "NOME OU ID";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            TabControl.TabPages.Remove(tabPageProdutos);
            TabControl.TabPages.Add(tabPageEdit);
            // PEGAR LAB?
        }

        private Laboratorio laboratorioSelecionadoAdd = new();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormLaboratorios formLaboratorio = new(true);
            AbrirForm(formLaboratorio);
            laboratorioSelecionadoAdd = formLaboratorio.LaboratorioSelecionado;
            if (laboratorioSelecionadoAdd != null)
            {
                txtLab.Text = $"{laboratorioSelecionadoAdd.Nome}";
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            FormLaboratorios formLaboratorio = new(true);
            AbrirForm(formLaboratorio);
            laboratorioSelecionadoEdit = formLaboratorio.LaboratorioSelecionado;
            if (laboratorioSelecionadoEdit != null)
            {
                txtLabEdit.Text = $"{laboratorioSelecionadoEdit.Nome}";
            }
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //rotina de exclusão
                //lab selecionado
                int iD = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
                Response response = produtoBLL.Delete(iD);
                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarGrid();
        }
    }
}
