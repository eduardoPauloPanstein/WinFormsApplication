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
    public partial class FormFuncionarios : Form
    {
        public FormFuncionarios()
        {
            InitializeComponent();
        }
        FuncionarioBLL funcionarioBLL = new();
        Validator validator = new();
        private void Funcionarios_Load(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageAdd);
            TabControl.TabPages.Remove(tabPageEdit);
            AtualizarGrid();

        }
        private void DoGrid(List<Funcionario> funcionarios)
        {
            foreach (var c in funcionarios)
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                row.Cells[0].Value = c.ID;
                row.Cells[1].Value = c.Nome;
                row.Cells[2].Value = c.CPF;
                row.Cells[3].Value = c.RG;
                row.Cells[4].Value = c.Telefone;
                row.Cells[5].Value = c.Email;
                row.Cells[6].Value = c.Endereco.CEP;
                row.Cells[7].Value = c.Endereco.Numero;
                row.Cells[8].Value = c.Ativo;
            }
        }
        private void AtualizarGrid()
        {
            dataGridView1.Rows.Clear();
            DataResponse<Funcionario> dataResponse = funcionarioBLL.GetAllView();
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

            DataResponse<Funcionario> dataResponse = funcionarioBLL.GetByValue(procurar);
            List<Funcionario> funcionarios = dataResponse.Dados;

            if (dataResponse.HasSuccess)
                DoGrid(funcionarios);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            VoltarTab();
            lblErros.Text = "";
            lblErros.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Endereco endereco = new (mTxtCEP.Text, mTxtNumResidencia.Text);
            Response response = validator.ValidateEndereco(endereco);
            if (response.HasSuccess)
            {
                Funcionario funcionario = new(txtNome.Text, txtCPF.Text, txtRG.Text,
                    mTxtTelefone.Text, txtEmail.Text, endereco, txtSenha.Text);
                response = funcionarioBLL.Insert(funcionario);
            }
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
            txtCPF.Clear();
            txtRG.Clear();
            mTxtTelefone.Clear();
            txtEmail.Clear();
            mTxtCEP.Clear();
            mTxtNumResidencia.Clear();
            txtSenha.Clear();

        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            if (txtNome.Text == "Nome")
            {
                txtNome.Text = "";
                //txtNome.ForeColor = Color.LightGray;
            }
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                txtNome.Text = "Nome";
                //txtNome.ForeColor = Color.LightGray;
            }
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
            TabControl.TabPages.Remove(tabPageFuncionarios);
            TabControl.TabPages.Add(tabPageAdd);
            tabPageAdd.Text = "Cadastrar funcionário";
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

            //exibe os valores no textbox
            txtID.Text = rowData.Cells[0].Value.ToString();
            txtNomeEdit.Text = rowData.Cells[1].Value.ToString();
            txtCPFEdit.Text = rowData.Cells[2].Value.ToString();
            txtRGEdit.Text = rowData.Cells[3].Value.ToString();
            txtTelefoneEdit.Text = rowData.Cells[4].Value.ToString();
            txtEmailEdit.Text = rowData.Cells[5].Value.ToString();
            txtCEPEdit.Text = rowData.Cells[6].Value.ToString();
            txtNumResidenciaEdit.Text = rowData.Cells[7].Value.ToString();
            //txtSenhaEdit.Text = rowData.Cells[8].Value.ToString();                       
            checkBoxAtivo.Checked = (bool)rowData.Cells[8].Value;
            DesativarAtivarTxts(checkBoxAtivo.Checked);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            lblErrosEdit.Text = "";
            VoltarTab();
        }
        private void VoltarTab()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            TabControl.TabPages.Add(tabPageFuncionarios);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Endereco endereco = new(txtCEPEdit.Text, txtNumResidenciaEdit.Text);
            Funcionario funcionario = new()
            {
                Nome = txtNomeEdit.Text,
                CPF = txtCPFEdit.Text,
                RG = txtRGEdit.Text,
                Telefone = txtTelefoneEdit.Text,
                Email = txtEmailEdit.Text,
                Endereco = endereco,
                Senha = txtSenhaEdit.Text,
                ID = Convert.ToInt32(txtID.Text)
            };
            Response response = funcionarioBLL.Update(funcionario);
            txtSenhaEdit.Text = "";
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

        private void checkBoxAtivo_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAtivo = checkBoxAtivo.Checked;
            int funcionarioID = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
            funcionarioBLL.ChangeAtivo(funcionarioID, checkAtivo);
            DesativarAtivarTxts(checkAtivo);
            AtualizarGrid();
            //DA PRA CHAMAR O CONFIRMAR CLICK E FAZER O UPDATE PRA TUDO OU SEPARAR NO DAL

        }

        /// <summary>
        /// Conferir qual o estado do funcionario e habilitar ou desabilitar textboxs 
        /// </summary>
        /// <param name="ativoEdit"></param>
        private void DesativarAtivarTxts(bool ativoEdit)
        {
            if (ativoEdit)
            {
                txtNomeEdit.ReadOnly = false;
                txtCPFEdit.ReadOnly = false;
                txtRGEdit.ReadOnly = false;
                txtTelefoneEdit.ReadOnly = false;
                txtEmailEdit.ReadOnly = false;
                txtCEPEdit.ReadOnly = false;
                txtNumResidenciaEdit.ReadOnly = false;
                txtSenhaEdit.ReadOnly = false;
                return;
            }
            txtNomeEdit.ReadOnly = true;
            txtCPFEdit.ReadOnly = true;
            txtRGEdit.ReadOnly = true;
            txtTelefoneEdit.ReadOnly = true;
            txtEmailEdit.ReadOnly = true;
            txtCEPEdit.ReadOnly = true;
            txtNumResidenciaEdit.ReadOnly = true;
            txtSenhaEdit.ReadOnly = true;
        }

        private void txtProcurar_Enter(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "NOME OU ID")
            {
                txtProcurar.Text = "";
            }
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
            TabControl.TabPages.Remove(tabPageFuncionarios);
            TabControl.TabPages.Add(tabPageEdit);
            tabPageAdd.Text = "Editar funcionario";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //rotina de exclusão
                //lab selecionado
                int iD = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
                Response response = funcionarioBLL.Delete(iD);
                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarGrid();
        }

    }
}
