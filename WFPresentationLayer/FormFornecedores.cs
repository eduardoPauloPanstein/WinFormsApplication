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
    public partial class FormFornecedores : Form
    {
        public FormFornecedores()
        {
            InitializeComponent();
        }
        FornecedorBLL fornecedorBLL = new();
        bool abertoPorOutroForm = false;
        public Fornecedor FornecedorSelecionado { get; set; }
        public FormFornecedores(bool abertoPorOutroForm)
        {
            InitializeComponent();
            this.abertoPorOutroForm = abertoPorOutroForm;
        }
        private void Fornecedors_Load(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageAdd);
            TabControl.TabPages.Remove(tabPageEdit);
            AtualizarGrid();
        }
        private void AtualizarGrid()
        {

            //dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();
            DataResponse<Fornecedor> dataResponse = fornecedorBLL.GetAll();
            //if (dataResponse.HasSuccess)
                dataGridView1.DataSource = dataResponse.Dados;

            //List<Fornecedor> fornecedores = dataResponse.Dados;
            //if (dataResponse.HasSuccess)
            //{
            //    foreach (var c in fornecedores)
            //    {
            //        int rowIndex = dataGridView1.Rows.Add();
            //        DataGridViewRow row = dataGridView1.Rows[rowIndex];
            //        row.Cells[0].Value = c.ID;
            //        row.Cells[1].Value = c.Razao_Social;
            //        row.Cells[2].Value = c.CNPJ;
            //        row.Cells[3].Value = c.Nome_Contato;
            //        row.Cells[4].Value = c.Telefone;
            //        row.Cells[5].Value = c.Email;
            //        row.Cells[6].Value = c.Ativo;
            //    }

            //    //dataGridView1.DataSource = dataResponse.Dados;
            //}
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            VoltarTab();

            lblErros.Text = "";
            lblErros.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FornecedorBLL fornecedorBLL = new FornecedorBLL();
            Fornecedor fornecedor = new Fornecedor(txtRazaoSocial.Text, txtCNPJ.Text, txtNomeContato.Text, txtTelefone.Text, txtEmail.Text);
            Response response = fornecedorBLL.Insert(fornecedor);

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
            txtRazaoSocial.Clear();
            txtCNPJ.Clear();
            txtNomeContato.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "NOME OU ID")
            {
                txtProcurar.Text = "";
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            string value = txtProcurar.Text;

            if (string.IsNullOrWhiteSpace(value) || value == "NOME OU ID")
            {
                AtualizarGrid(); return;
            }

            DataResponse<Fornecedor> dataResponse = fornecedorBLL.GetByValue(value);
            if(dataResponse.HasSuccess)
                dataGridView1.DataSource = dataResponse.Dados;
            else MessageBox.Show(dataResponse.Message);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //SO ENTRAR AQUI SE o dataGridView1 tiver selecionado uma linha!!!!
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            TabControl.TabPages.Remove(tabPageFornecedores);
            TabControl.TabPages.Add(tabPageEdit);
            //tabPageInfos.Text = "Editar fornecedor";
        }

        private void btnAdcionar1_Click_1(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageFornecedores);
            TabControl.TabPages.Add(tabPageAdd);
            tabPageAdd.Text = "Cadastrar fornecedor";
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

            Fornecedor fornecedorSelecionado = new()
            {
                ID = (int)rowData.Cells[0].Value,
                Razao_Social = rowData.Cells[1].Value.ToString(),
                CNPJ = rowData.Cells[2].Value.ToString(),
                Nome_Contato = rowData.Cells[3].Value.ToString(),
                Telefone = rowData.Cells[4].Value.ToString(),
                Email = rowData.Cells[5].Value.ToString(),
                Ativo = (bool)rowData.Cells[6].Value
            };
            //exibe os valores no textbox
            txtID.Text = rowData.Cells[0].Value.ToString();
            txtRazaoSocialEdit.Text = rowData.Cells[1].Value.ToString();
            txtCNPJEdit.Text = rowData.Cells[2].Value.ToString();
            txtNomeContatoEdit.Text = rowData.Cells[3].Value.ToString();
            txtTelefoneEdit.Text = rowData.Cells[4].Value.ToString();
            txtEmailEdit.Text = rowData.Cells[5].Value.ToString();
            checkBoxAtivo.Checked = (bool)rowData.Cells[6].Value;
            DesativarAtivarTxts(checkBoxAtivo.Checked);

            PreencherTxts(fornecedorSelecionado);
            DesativarAtivarTxts(checkBoxAtivo.Checked);

            if (this.abertoPorOutroForm)
            {
                if (!fornecedorSelecionado.Ativo)
                {
                    MessageBox.Show("Não pode selecionar um fornecedor que não esta ativo.");
                    return;
                }
                this.FornecedorSelecionado = fornecedorSelecionado;
                this.Close();
            }
        }
        private void PreencherTxts(Fornecedor f)
        {
            txtID.Text = f.ID.ToString();
            txtRazaoSocialEdit.Text = f.Razao_Social.ToString();
            txtCNPJEdit.Text = f.CNPJ.ToString();
            txtNomeContatoEdit.Text = f.Nome_Contato.ToString();
            txtTelefoneEdit.Text = f.Telefone.ToString();
            txtEmailEdit.Text = f.Email.ToString();
            checkBoxAtivo.Checked = f.Ativo;
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            lblErrosEdit.Text = "";
            //lblErros.ResetText();
            VoltarTab();
        }
        private void VoltarTab()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            TabControl.TabPages.Add(tabPageFornecedores);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new(txtRazaoSocialEdit.Text, txtCNPJEdit.Text, txtNomeContatoEdit.Text, txtTelefoneEdit.Text, txtEmailEdit.Text);
            fornecedor.ID = Convert.ToInt32(txtID.Text);
            Response response = fornecedorBLL.Update(fornecedor);

            if (response.HasSuccess)
            {
                MessageBox.Show(response.Message);
                Limpar();
                lblErrosEdit.Text = "";
                lblErrosEdit.Visible = false;
                AtualizarGrid();
            }
            else
            {
                lblErrosEdit.Text = response.Message;
                lblErrosEdit.Visible = true;
            }
        }

        /// <summary>
        /// Conferir qual o estado do fornecedor e habilitar ou desabilitar textboxs 
        /// </summary>
        /// <param name="txtAtivoEdit">bool.Parse(txtAtivoEdit.Text)</param>
        private void DesativarAtivarTxts(bool txtAtivoEdit)
        {
            if (txtAtivoEdit)
            {
                txtRazaoSocialEdit.ReadOnly = false;
                txtCNPJEdit.ReadOnly = false;
                txtNomeContatoEdit.ReadOnly = false;
                txtTelefoneEdit.ReadOnly = false;
                txtEmailEdit.ReadOnly = false;
                return;
            }
            txtRazaoSocialEdit.ReadOnly = true;
            txtCNPJEdit.ReadOnly = true;
            txtNomeContatoEdit.ReadOnly = true;
            txtTelefoneEdit.ReadOnly = true;
            txtEmailEdit.ReadOnly = true;
        }


        private void checkBoxAtivo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            int id = Convert.ToInt32(txtID.Text);
            bool checkAtivo = checkBoxAtivo.Checked;
            if (checkAtivo)
                fornecedorBLL.Ativar(id);
            else 
                fornecedorBLL.Desativar(id);
            DesativarAtivarTxts(checkAtivo);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TabControl.TabPages.Remove(tabPageFornecedores);
            TabControl.TabPages.Add(tabPageEdit);
        }

        private void txtProcurar_Leave(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "")
            {
                txtProcurar.Text = "NOME OU ID";
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //rotina de exclusão
                //lab selecionado
                int iD = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
                Response response = fornecedorBLL.Delete(iD);
                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarGrid();
        }
    }
}
