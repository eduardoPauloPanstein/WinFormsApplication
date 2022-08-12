using BusinessLogicalLayer;
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
using Entities;

namespace WFPresentationLayer
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }
        ClienteBLL clienteBLL = new ClienteBLL();
        bool abertoPorOutroForm = false;

        public FormClientes(bool abertoPorOutroForm)
        {
            InitializeComponent();
            this.abertoPorOutroForm = abertoPorOutroForm;
        }
        
        private void Clientes_Load(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageInfos);
            TabControl.TabPages.Remove(tabPageEdit);
            AtualizarGrid();

        }
        private void DoGrid(List<Cliente> clientes)
        {
            foreach (var c in clientes)
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                row.Cells[0].Value = c.ID;
                row.Cells[1].Value = c.Nome;
                row.Cells[2].Value = c.Pontos;
                row.Cells[3].Value = c.Telefone_Um;
                row.Cells[4].Value = c.Telefone_Dois;
                row.Cells[5].Value = c.Email;
                row.Cells[6].Value = c.CPF;
                row.Cells[7].Value = c.RG;
                row.Cells[8].Value = c.Ativo;

            }
        }
        private void AtualizarGrid()
        {
            dataGridView1.Rows.Clear();
            DataResponse<Cliente> dataResponse = clienteBLL.GetAll();
            if (dataResponse.HasSuccess) DoGrid(dataResponse.Dados);           
        }
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (string.IsNullOrWhiteSpace(txtProcurar.Text) || txtProcurar.Text == "NOME OU ID")
            {
                AtualizarGrid(); return;
            }
            DataResponse<Cliente> dataResponse = clienteBLL.GetByValue(txtProcurar.Text);
            List<Cliente> clientes = dataResponse.Dados;
            if (dataResponse.HasSuccess)
                DoGrid(clientes);
            txtProcurar.Text = null;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            VoltarTab();
            lblErros.Text = "";
            lblErros.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            Cliente cliente = new Cliente(txtNome.Text, mTxtCPF.Text, txtRG.Text, mTxtTelefone_Um.Text, mTxtTelefone_Dois.Text, txtEmail.Text);
            Response response = clienteBLL.Insert(cliente);

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
            mTxtCPF.Clear();
            txtRG.Clear();
            mTxtTelefone_Um.Clear();
            mTxtTelefone_Dois.Clear();
            txtEmail.Clear();
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            if (txtNome.Text == "Nome")
                txtNome.Text = "";
            lblNome.ForeColor = Color.Blue;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
                txtNome.Text = "Nome";
            lblNome.ForeColor = Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "NOME OU ID")
            {
                txtProcurar.Text = "";
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //SO ENTRAR AQUI SE o dataGridView1 tiver selecionado uma linha!!!!
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            TabControl.TabPages.Remove(tabPageClientes);
            TabControl.TabPages.Add(tabPageEdit);
            tabPageInfos.Text = "Editar cliente";

        }

        private void btnAdcionar1_Click_1(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageClientes);
            TabControl.TabPages.Add(tabPageInfos);
            tabPageInfos.Text = "Cadastrar cliente";
        }

        public Cliente ClienteSelecionado { get; set; }
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
            Cliente clienteSelecionado = new()
            {
                ID = Convert.ToInt32(rowData.Cells[0].Value.ToString()),
                Nome = rowData.Cells[1].Value.ToString(),
                Pontos = Convert.ToInt32(rowData.Cells[2].Value.ToString()),
                Telefone_Um = rowData.Cells[3].Value.ToString(),
                Telefone_Dois = rowData.Cells[4].Value.ToString(),
                Email = rowData.Cells[5].Value.ToString(),
                CPF = rowData.Cells[6].Value.ToString(),
                RG = rowData.Cells[7].Value.ToString(),
                Ativo = Convert.ToBoolean(rowData.Cells[8].Value.ToString())
            };
            PreencherTxts(clienteSelecionado);
            DesativarAtivarTxts(bool.Parse(txtAtivoEdit.Text));

            if (this.abertoPorOutroForm)
            {
                if (!clienteSelecionado.Ativo)
                {
                    MessageBox.Show("Não pode selecionar um cliente que não esta ativo.");
                    return;
                }
                this.ClienteSelecionado = clienteSelecionado;
                this.Close();
            }
        }
        private void PreencherTxts(Cliente cliente)
        {
            txtID.Text = cliente.ID.ToString();
            txtNomeEdit.Text = cliente.Nome;
            txtPontosEdit.Text = cliente.Pontos.ToString();
            txtTelefoneUmEdit.Text = cliente.Telefone_Um;
            txtTelefoneDoisEdit.Text = cliente.Telefone_Dois;
            txtEmailEdit.Text = cliente.Email;
            txtCpfEdit.Text = cliente.CPF;
            txtRGEdit.Text = cliente.RG;
            txtAtivoEdit.Text = cliente.Ativo.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //lblErrosEdit.Text = "";
            lblErros.ResetText();
            VoltarTab();
        }
        private void VoltarTab()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            TabControl.TabPages.Add(tabPageClientes);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            Cliente cliente = new Cliente(txtNomeEdit.Text, txtCpfEdit.Text, txtRGEdit.Text, txtTelefoneUmEdit.Text, txtTelefoneDoisEdit.Text, txtEmailEdit.Text);
            cliente.ID = Convert.ToInt32(txtID.Text);
            Response response = clienteBLL.Update(cliente);

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

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;

            Response response = clienteBLL.Desativar(Convert.ToInt32(txtID.Text));
            if (response.HasSuccess)
            {
                txtAtivoEdit.Text = "False";
                DesativarAtivarTxts(bool.Parse(txtAtivoEdit.Text));
                AtualizarGrid();
                return;
            }
            lblErrosEdit.Text = response.Message.ToString();
        }

        /// <summary>
        /// Conferir qual o estado do cliente e habilitar ou desabilitar textboxs 
        /// </summary>
        /// <param name="txtAtivoEdit">bool.Parse(txtAtivoEdit.Text)</param>
        private void DesativarAtivarTxts(bool txtAtivoEdit)
        {
            if (txtAtivoEdit)
            {
                txtNomeEdit.ReadOnly = false;
                txtTelefoneUmEdit.ReadOnly = false;
                txtTelefoneDoisEdit.ReadOnly = false;
                txtEmailEdit.ReadOnly = false;
                txtCpfEdit.ReadOnly = false;
                txtRGEdit.ReadOnly = false;
                return;
            }
            txtNomeEdit.ReadOnly = true;
            txtTelefoneUmEdit.ReadOnly = true;
            txtTelefoneDoisEdit.ReadOnly = true;
            txtEmailEdit.ReadOnly = true;
            txtCpfEdit.ReadOnly = true;
            txtRGEdit.ReadOnly = true;
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;
            Response response = clienteBLL.Ativar(Convert.ToInt32(txtID.Text));
            if (response.HasSuccess)
            {
                txtAtivoEdit.Text = "True";
                DesativarAtivarTxts(bool.Parse(txtAtivoEdit.Text));
                AtualizarGrid();
                return;
            }
            lblErrosEdit.Text = response.Message.ToString();
        }


        private void txtRG_Enter(object sender, EventArgs e)
        {
            if (txtRG.Text == "RG")
            {
                txtRG.Text = "";
                //txtNome.ForeColor = Color.LightGray;
            }
            lblRG.ForeColor = Color.Blue;
        }

        private void txtRG_Leave(object sender, EventArgs e)
        {
            if (txtRG.Text == "")
            {
                txtRG.Text = "RG";
                //txtNome.ForeColor = Color.LightGray;
            }
            lblRG.ForeColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                //txtNome.ForeColor = Color.LightGray;
            }
            lblEmail.ForeColor = Color.Blue;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                //txtNome.ForeColor = Color.LightGray;
            }
            lblEmail.ForeColor = Color.White;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void mTxtCPF_Enter(object sender, EventArgs e)
        {
            lblCPF.ForeColor = Color.Blue;
        }

        private void mTxtCPF_Leave(object sender, EventArgs e)
        {
            lblCPF.ForeColor = Color.White;
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
            TabControl.TabPages.Remove(tabPageClientes);
            TabControl.TabPages.Add(tabPageEdit);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //rotina de exclusão
                //lab selecionado
                int iD = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
                Response response = clienteBLL.Delete(iD);
                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarGrid();
        }

        private void mTxtTelefone_Um_Enter(object sender, EventArgs e)
        {
            lblTelefone1.ForeColor = Color.Blue;
        }

        private void mTxtTelefone_Um_Leave(object sender, EventArgs e)
        {
            lblTelefone1.ForeColor = Color.White;
        }

        private void mTxtTelefone_Dois_Leave(object sender, EventArgs e)
        {
            lblTelefone2.ForeColor = Color.White;
        }

        private void mTxtTelefone_Dois_Enter(object sender, EventArgs e)
        {
            lblTelefone2.ForeColor = Color.Blue;
        }
    }
}
