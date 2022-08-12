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
    public partial class FormLaboratorios : Form
    {
        public FormLaboratorios()
        {
            InitializeComponent();
        }

        bool abertoPorOutroForm = false;
        public Laboratorio LaboratorioSelecionado { get; set; }
        public FormLaboratorios(bool abertoPorOutroForm)
        {
            InitializeComponent();
            this.abertoPorOutroForm = abertoPorOutroForm;
        }
        private void FormLaboratorios_Load(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(tabPageCadastrarLab);
            TabControl.TabPages.Remove(tabPageEdit);
            AtualizarGrid();
        }
        LaboratorioBLL laboratorioBLL = new();
        Validator validator = new();
        private void DoGrid(List<Laboratorio> laboratorios)
        {
            foreach (var c in laboratorios)
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                row.Cells[0].Value = c.ID;
                row.Cells[1].Value = c.Nome;
                row.Cells[2].Value = c.CNPJ;
                row.Cells[3].Value = c.Ativo;
            }
        }
        private void AtualizarGrid()
        {
            dataGridView1.Rows.Clear();
            DataResponse<Laboratorio> dataResponse = laboratorioBLL.GetAllView();
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

            DataResponse<Laboratorio> dataResponse = laboratorioBLL.GetByValue(txtProcurar.Text);
            List<Laboratorio> laboratorios = dataResponse.Dados;

            if (dataResponse.HasSuccess)
                DoGrid(laboratorios);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            lblErros.Text = "";
            lblErros.Visible = false;
            VoltarTab();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Laboratorio laboratorio = new()
            {
                Nome = txtNome.Text, 
                CNPJ = txtCNPJ.Text
            };
            Response response = laboratorioBLL.Insert(laboratorio);
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
            txtCNPJ.Clear();

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
            TabControl.TabPages.Remove(tabPageLista);
            TabControl.TabPages.Add(tabPageCadastrarLab);
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
            Laboratorio laboratorioSelecionado = new()
            {
                ID = (int)rowData.Cells[0].Value,
                Nome = rowData.Cells[1].Value.ToString(),
                CNPJ = rowData.Cells[2].Value.ToString(),
                Ativo = (bool)rowData.Cells[3].Value
            };
            PreencherTxts(laboratorioSelecionado);
            DesativarAtivarTxts(laboratorioSelecionado.Ativo);
            if (this.abertoPorOutroForm)
            {
                if (!laboratorioSelecionado.Ativo)
                {
                    MessageBox.Show("Não pode selecionar um laboratorio que não esta ativo.");
                    return;
                }
                this.LaboratorioSelecionado = laboratorioSelecionado;
                this.Close();
            }
        }
        private void PreencherTxts(Laboratorio l)
        {
            txtID.Text = l.ID.ToString();
            txtNomeEdit.Text = l.Nome.ToString();
            txtCNPJEdit.Text = l.CNPJ.ToString();
            checkBoxAtivo.Checked = l.Ativo;
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            lblErros.Text = "";
            VoltarTab();
        }
        private void VoltarTab()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            TabControl.TabPages.Add(tabPageLista);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Laboratorio laboratorio = new()
            {
                Nome = txtNomeEdit.Text,
                CNPJ = txtCNPJEdit.Text,
                Ativo = checkBoxAtivo.Checked,
                ID = Convert.ToInt32(txtID.Text)
            };
            Response response = laboratorioBLL.Update(laboratorio);

            if (response.HasSuccess)
            {
                MessageBox.Show(response.Message);
                Limpar();
                lblErrosEdit.ResetText();
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
            //int laboratorioID = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
            //laboratorioBLL.ChangeAtivo(laboratorioID, checkAtivo);
            DesativarAtivarTxts(checkAtivo);
            //AtualizarGrid();
            //DA PRA CHAMAR O CONFIRMAR CLICK E FAZER O UPDATE PRA TUDO OU SEPARAR NO DAL
            //Que foi o que fiz agora pra laboratorios, update tudo junto
        }

        /// <summary>
        /// Conferir qual o estado do laboratorio e habilitar ou desabilitar textboxs 
        /// </summary>
        /// <param name="ativoEdit"></param>
        private void DesativarAtivarTxts(bool ativoEdit)
        {
            if (ativoEdit)
            {
                txtNomeEdit.ReadOnly = false;
                txtCNPJEdit.ReadOnly = false;
                return;
            }
            txtNomeEdit.ReadOnly = true;
            txtCNPJEdit.ReadOnly = true;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //Criar um MessageBox com os botões Sim e Não e deixar o botão 2(Não) selecionado por padrão e comparar o botão apertado
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?","Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //rotina de exclusão
                //lab selecionado
                int laboratorioID = int.TryParse(txtID.Text, out _) ? Convert.ToInt32(txtID.Text) : 0;
                Response response = laboratorioBLL.Delete(laboratorioID);
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
            TabControl.TabPages.Remove(tabPageLista);
            TabControl.TabPages.Add(tabPageEdit);
        }

        private void tabPageEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
