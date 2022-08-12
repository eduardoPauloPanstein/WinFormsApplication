namespace WFPresentationLayer
{
    partial class FormFuncionarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPageFuncionarios = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTELEFONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnderecoCEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnderecoNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnATIVO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pesquisar = new System.Windows.Forms.PictureBox();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblErros = new System.Windows.Forms.Label();
            this.mTxtNumResidencia = new System.Windows.Forms.MaskedTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.mTxtCEP = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.mTxtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.txtCEPEdit = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefoneEdit = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCPFEdit = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.txtNumResidenciaEdit = new System.Windows.Forms.TextBox();
            this.txtSenhaEdit = new System.Windows.Forms.TextBox();
            this.txtEmailEdit = new System.Windows.Forms.TextBox();
            this.txtRGEdit = new System.Windows.Forms.TextBox();
            this.txtNomeEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblErrosEdit = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabPageFuncionarios.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pesquisar)).BeginInit();
            this.tabPageAdd.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(-135, -285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(176, 37);
            this.label13.TabIndex = 0;
            this.label13.Text = "Fornecedores";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPageFuncionarios);
            this.TabControl.Controls.Add(this.tabPageAdd);
            this.TabControl.Controls.Add(this.tabPageEdit);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1141, 652);
            this.TabControl.TabIndex = 6;
            // 
            // tabPageFuncionarios
            // 
            this.tabPageFuncionarios.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageFuncionarios.Controls.Add(this.panel2);
            this.tabPageFuncionarios.Controls.Add(this.panel3);
            this.tabPageFuncionarios.Controls.Add(this.label13);
            this.tabPageFuncionarios.Location = new System.Drawing.Point(4, 34);
            this.tabPageFuncionarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFuncionarios.Name = "tabPageFuncionarios";
            this.tabPageFuncionarios.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFuncionarios.Size = new System.Drawing.Size(1133, 614);
            this.tabPageFuncionarios.TabIndex = 0;
            this.tabPageFuncionarios.Text = "Funcionários";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 567);
            this.panel2.TabIndex = 54;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ColumnNome,
            this.ColumnCPF,
            this.ColumnRG,
            this.ColumnTELEFONE,
            this.ColumnEMAIL,
            this.ColumnEnderecoCEP,
            this.ColumnEnderecoNumero,
            this.ColumnATIVO});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1127, 567);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.FillWeight = 205.2632F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // ColumnNome
            // 
            this.ColumnNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnNome.HeaderText = "Nome";
            this.ColumnNome.Name = "ColumnNome";
            this.ColumnNome.ReadOnly = true;
            this.ColumnNome.Width = 160;
            // 
            // ColumnCPF
            // 
            this.ColumnCPF.HeaderText = "CPF";
            this.ColumnCPF.Name = "ColumnCPF";
            this.ColumnCPF.ReadOnly = true;
            // 
            // ColumnRG
            // 
            this.ColumnRG.HeaderText = "RG";
            this.ColumnRG.Name = "ColumnRG";
            this.ColumnRG.ReadOnly = true;
            // 
            // ColumnTELEFONE
            // 
            this.ColumnTELEFONE.HeaderText = "TELEFONE";
            this.ColumnTELEFONE.Name = "ColumnTELEFONE";
            this.ColumnTELEFONE.ReadOnly = true;
            // 
            // ColumnEMAIL
            // 
            this.ColumnEMAIL.HeaderText = "EMAIL";
            this.ColumnEMAIL.Name = "ColumnEMAIL";
            this.ColumnEMAIL.ReadOnly = true;
            // 
            // ColumnEnderecoCEP
            // 
            this.ColumnEnderecoCEP.HeaderText = "CEP";
            this.ColumnEnderecoCEP.Name = "ColumnEnderecoCEP";
            this.ColumnEnderecoCEP.ReadOnly = true;
            // 
            // ColumnEnderecoNumero
            // 
            this.ColumnEnderecoNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnEnderecoNumero.HeaderText = "Numero";
            this.ColumnEnderecoNumero.Name = "ColumnEnderecoNumero";
            this.ColumnEnderecoNumero.ReadOnly = true;
            // 
            // ColumnATIVO
            // 
            this.ColumnATIVO.HeaderText = "ATIVO";
            this.ColumnATIVO.Name = "ColumnATIVO";
            this.ColumnATIVO.ReadOnly = true;
            this.ColumnATIVO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnATIVO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.Pesquisar);
            this.panel3.Controls.Add(this.txtProcurar);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1127, 43);
            this.panel3.TabIndex = 53;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WFPresentationLayer.Properties.Resources.icons8_adicionar_50;
            this.pictureBox1.Location = new System.Drawing.Point(395, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnAdcionar1_Click_1);
            // 
            // Pesquisar
            // 
            this.Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pesquisar.Image = global::WFPresentationLayer.Properties.Resources.icons8_pesquisar_64;
            this.Pesquisar.Location = new System.Drawing.Point(335, 7);
            this.Pesquisar.Name = "Pesquisar";
            this.Pesquisar.Size = new System.Drawing.Size(44, 32);
            this.Pesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pesquisar.TabIndex = 1;
            this.Pesquisar.TabStop = false;
            this.Pesquisar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // txtProcurar
            // 
            this.txtProcurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtProcurar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcurar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtProcurar.Location = new System.Drawing.Point(88, 10);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(155, 26);
            this.txtProcurar.TabIndex = 0;
            this.txtProcurar.Text = "NOME OU ID";
            this.txtProcurar.Enter += new System.EventHandler(this.txtProcurar_Enter);
            this.txtProcurar.Leave += new System.EventHandler(this.txtProcurar_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(82, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(228, 25);
            this.label26.TabIndex = 49;
            this.label26.Text = "___________________________";
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.BackColor = System.Drawing.Color.Transparent;
            this.tabPageAdd.Controls.Add(this.panel4);
            this.tabPageAdd.ForeColor = System.Drawing.Color.Black;
            this.tabPageAdd.Location = new System.Drawing.Point(4, 34);
            this.tabPageAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAdd.Size = new System.Drawing.Size(1133, 614);
            this.tabPageAdd.TabIndex = 1;
            this.tabPageAdd.Text = "Cadastrar Funcionário";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.panel4.Controls.Add(this.txtCPF);
            this.panel4.Controls.Add(this.lblCPF);
            this.panel4.Controls.Add(this.lblErros);
            this.panel4.Controls.Add(this.mTxtNumResidencia);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.txtSenha);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtNome);
            this.panel4.Controls.Add(this.btnCadastrar);
            this.panel4.Controls.Add(this.txtRG);
            this.panel4.Controls.Add(this.mTxtCEP);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtEmail);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.mTxtTelefone);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(3, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1127, 610);
            this.panel4.TabIndex = 48;
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCPF.ForeColor = System.Drawing.Color.White;
            this.txtCPF.Location = new System.Drawing.Point(29, 164);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(179, 26);
            this.txtCPF.TabIndex = 74;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.BackColor = System.Drawing.Color.Transparent;
            this.lblCPF.Location = new System.Drawing.Point(22, 169);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(188, 25);
            this.lblCPF.TabIndex = 75;
            this.lblCPF.Text = "______________________";
            // 
            // lblErros
            // 
            this.lblErros.AutoSize = true;
            this.lblErros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErros.Location = new System.Drawing.Point(631, 72);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(98, 25);
            this.lblErros.TabIndex = 49;
            this.lblErros.Text = "Erros here";
            this.lblErros.Visible = false;
            // 
            // mTxtNumResidencia
            // 
            this.mTxtNumResidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.mTxtNumResidencia.ForeColor = System.Drawing.Color.White;
            this.mTxtNumResidencia.Location = new System.Drawing.Point(422, 100);
            this.mTxtNumResidencia.Mask = "0000";
            this.mTxtNumResidencia.Name = "mTxtNumResidencia";
            this.mTxtNumResidencia.Size = new System.Drawing.Size(179, 33);
            this.mTxtNumResidencia.TabIndex = 72;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1007, 573);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 32);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Voltar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtSenha.ForeColor = System.Drawing.Color.White;
            this.txtSenha.Location = new System.Drawing.Point(422, 164);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(179, 33);
            this.txtSenha.TabIndex = 70;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 72);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 25);
            this.label19.TabIndex = 55;
            this.label19.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 25);
            this.label4.TabIndex = 69;
            this.label4.Text = "Senha de acesso:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(29, 100);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(179, 33);
            this.txtNome.TabIndex = 56;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Location = new System.Drawing.Point(443, 229);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(149, 32);
            this.btnCadastrar.TabIndex = 68;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtRG
            // 
            this.txtRG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtRG.ForeColor = System.Drawing.Color.White;
            this.txtRG.Location = new System.Drawing.Point(29, 228);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(179, 33);
            this.txtRG.TabIndex = 57;
            // 
            // mTxtCEP
            // 
            this.mTxtCEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.mTxtCEP.ForeColor = System.Drawing.Color.White;
            this.mTxtCEP.Location = new System.Drawing.Point(227, 228);
            this.mTxtCEP.Mask = "00000-000";
            this.mTxtCEP.Name = "mTxtCEP";
            this.mTxtCEP.Size = new System.Drawing.Size(179, 33);
            this.mTxtCEP.TabIndex = 67;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(227, 72);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 25);
            this.label18.TabIndex = 58;
            this.label18.Text = "Telefone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 25);
            this.label5.TabIndex = 66;
            this.label5.Text = "Número da residencia:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(227, 136);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 25);
            this.label17.TabIndex = 59;
            this.label17.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 25);
            this.label6.TabIndex = 65;
            this.label6.Text = "CEP:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(227, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(179, 33);
            this.txtEmail.TabIndex = 60;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 197);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 25);
            this.label15.TabIndex = 64;
            this.label15.Text = "RG:";
            // 
            // mTxtTelefone
            // 
            this.mTxtTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.mTxtTelefone.ForeColor = System.Drawing.Color.White;
            this.mTxtTelefone.Location = new System.Drawing.Point(227, 100);
            this.mTxtTelefone.Mask = "(99) 00000-0000";
            this.mTxtTelefone.Name = "mTxtTelefone";
            this.mTxtTelefone.Size = new System.Drawing.Size(179, 33);
            this.mTxtTelefone.TabIndex = 61;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 133);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 25);
            this.label16.TabIndex = 63;
            this.label16.Text = "CPF:";
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.tabPageEdit.Controls.Add(this.btnDeletar);
            this.tabPageEdit.Controls.Add(this.txtCEPEdit);
            this.tabPageEdit.Controls.Add(this.txtTelefoneEdit);
            this.tabPageEdit.Controls.Add(this.label14);
            this.tabPageEdit.Controls.Add(this.txtCPFEdit);
            this.tabPageEdit.Controls.Add(this.checkBoxAtivo);
            this.tabPageEdit.Controls.Add(this.txtNumResidenciaEdit);
            this.tabPageEdit.Controls.Add(this.txtSenhaEdit);
            this.tabPageEdit.Controls.Add(this.txtEmailEdit);
            this.tabPageEdit.Controls.Add(this.txtRGEdit);
            this.tabPageEdit.Controls.Add(this.txtNomeEdit);
            this.tabPageEdit.Controls.Add(this.label7);
            this.tabPageEdit.Controls.Add(this.label8);
            this.tabPageEdit.Controls.Add(this.label9);
            this.tabPageEdit.Controls.Add(this.label10);
            this.tabPageEdit.Controls.Add(this.label12);
            this.tabPageEdit.Controls.Add(this.label11);
            this.tabPageEdit.Controls.Add(this.label20);
            this.tabPageEdit.Controls.Add(this.label21);
            this.tabPageEdit.Controls.Add(this.txtID);
            this.tabPageEdit.Controls.Add(this.label22);
            this.tabPageEdit.Controls.Add(this.lblErrosEdit);
            this.tabPageEdit.Controls.Add(this.btnConfirmar);
            this.tabPageEdit.Controls.Add(this.btnVoltar);
            this.tabPageEdit.Controls.Add(this.label23);
            this.tabPageEdit.ForeColor = System.Drawing.Color.White;
            this.tabPageEdit.Location = new System.Drawing.Point(4, 24);
            this.tabPageEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageEdit.Size = new System.Drawing.Size(1133, 624);
            this.tabPageEdit.TabIndex = 2;
            this.tabPageEdit.Text = "Editar Funcionario";
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnDeletar.FlatAppearance.BorderSize = 0;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(415, 394);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(265, 28);
            this.btnDeletar.TabIndex = 92;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // txtCEPEdit
            // 
            this.txtCEPEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtCEPEdit.ForeColor = System.Drawing.Color.White;
            this.txtCEPEdit.Location = new System.Drawing.Point(264, 224);
            this.txtCEPEdit.Mask = "00000-000";
            this.txtCEPEdit.Name = "txtCEPEdit";
            this.txtCEPEdit.Size = new System.Drawing.Size(179, 33);
            this.txtCEPEdit.TabIndex = 90;
            // 
            // txtTelefoneEdit
            // 
            this.txtTelefoneEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtTelefoneEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefoneEdit.ForeColor = System.Drawing.Color.White;
            this.txtTelefoneEdit.Location = new System.Drawing.Point(264, 96);
            this.txtTelefoneEdit.Mask = "(99) 00000-0000";
            this.txtTelefoneEdit.Name = "txtTelefoneEdit";
            this.txtTelefoneEdit.Size = new System.Drawing.Size(179, 26);
            this.txtTelefoneEdit.TabIndex = 88;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(255, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 25);
            this.label14.TabIndex = 89;
            this.label14.Text = "______________________";
            // 
            // txtCPFEdit
            // 
            this.txtCPFEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtCPFEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCPFEdit.ForeColor = System.Drawing.Color.White;
            this.txtCPFEdit.Location = new System.Drawing.Point(67, 165);
            this.txtCPFEdit.Mask = "000.000.000-00";
            this.txtCPFEdit.Name = "txtCPFEdit";
            this.txtCPFEdit.Size = new System.Drawing.Size(179, 26);
            this.txtCPFEdit.TabIndex = 87;
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.checkBoxAtivo.ForeColor = System.Drawing.Color.White;
            this.checkBoxAtivo.Location = new System.Drawing.Point(471, 228);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(74, 29);
            this.checkBoxAtivo.TabIndex = 86;
            this.checkBoxAtivo.Text = "Ativo";
            this.checkBoxAtivo.UseVisualStyleBackColor = false;
            this.checkBoxAtivo.Click += new System.EventHandler(this.checkBoxAtivo_CheckedChanged);
            // 
            // txtNumResidenciaEdit
            // 
            this.txtNumResidenciaEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtNumResidenciaEdit.ForeColor = System.Drawing.Color.White;
            this.txtNumResidenciaEdit.Location = new System.Drawing.Point(462, 99);
            this.txtNumResidenciaEdit.Name = "txtNumResidenciaEdit";
            this.txtNumResidenciaEdit.Size = new System.Drawing.Size(171, 33);
            this.txtNumResidenciaEdit.TabIndex = 85;
            // 
            // txtSenhaEdit
            // 
            this.txtSenhaEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtSenhaEdit.ForeColor = System.Drawing.Color.White;
            this.txtSenhaEdit.Location = new System.Drawing.Point(462, 163);
            this.txtSenhaEdit.Name = "txtSenhaEdit";
            this.txtSenhaEdit.Size = new System.Drawing.Size(171, 33);
            this.txtSenhaEdit.TabIndex = 84;
            // 
            // txtEmailEdit
            // 
            this.txtEmailEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtEmailEdit.ForeColor = System.Drawing.Color.White;
            this.txtEmailEdit.Location = new System.Drawing.Point(264, 163);
            this.txtEmailEdit.Name = "txtEmailEdit";
            this.txtEmailEdit.Size = new System.Drawing.Size(171, 33);
            this.txtEmailEdit.TabIndex = 82;
            // 
            // txtRGEdit
            // 
            this.txtRGEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtRGEdit.ForeColor = System.Drawing.Color.White;
            this.txtRGEdit.Location = new System.Drawing.Point(66, 224);
            this.txtRGEdit.Name = "txtRGEdit";
            this.txtRGEdit.Size = new System.Drawing.Size(171, 33);
            this.txtRGEdit.TabIndex = 80;
            // 
            // txtNomeEdit
            // 
            this.txtNomeEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtNomeEdit.ForeColor = System.Drawing.Color.White;
            this.txtNomeEdit.Location = new System.Drawing.Point(66, 99);
            this.txtNomeEdit.Name = "txtNomeEdit";
            this.txtNomeEdit.Size = new System.Drawing.Size(171, 33);
            this.txtNomeEdit.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 25);
            this.label7.TabIndex = 70;
            this.label7.Text = "Nome:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(456, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 25);
            this.label8.TabIndex = 77;
            this.label8.Text = "(opcional) Senha:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 25);
            this.label9.TabIndex = 71;
            this.label9.Text = "Telefone:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(456, 71);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 25);
            this.label10.TabIndex = 76;
            this.label10.Text = "Número residencial:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 135);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 25);
            this.label12.TabIndex = 72;
            this.label12.Text = "Email:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(692, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 25);
            this.label11.TabIndex = 15;
            this.label11.Text = "ID";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(264, 199);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 25);
            this.label20.TabIndex = 75;
            this.label20.Text = "CEP:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(66, 196);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 25);
            this.label21.TabIndex = 74;
            this.label21.Text = "RG:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtID.ForeColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(686, 95);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(96, 33);
            this.txtID.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(66, 137);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 25);
            this.label22.TabIndex = 73;
            this.label22.Text = "CPF:";
            // 
            // lblErrosEdit
            // 
            this.lblErrosEdit.AutoSize = true;
            this.lblErrosEdit.ForeColor = System.Drawing.Color.Maroon;
            this.lblErrosEdit.Location = new System.Drawing.Point(686, 160);
            this.lblErrosEdit.Name = "lblErrosEdit";
            this.lblErrosEdit.Size = new System.Drawing.Size(108, 25);
            this.lblErrosEdit.TabIndex = 8;
            this.lblErrosEdit.Text = "lblErrosEdit";
            this.lblErrosEdit.Visible = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(415, 307);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(265, 28);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(67, 307);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(265, 28);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(61, 171);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(188, 25);
            this.label23.TabIndex = 91;
            this.label23.Text = "______________________";
            // 
            // FormFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1141, 652);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormFuncionarios";
            this.Text = "FormFuncionarios";
            this.Load += new System.EventHandler(this.Funcionarios_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPageFuncionarios.ResumeLayout(false);
            this.tabPageFuncionarios.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pesquisar)).EndInit();
            this.tabPageAdd.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label13;
        private TabControl TabControl;
        private TabPage tabPageFuncionarios;
        private TabPage tabPageAdd;
        private Panel panel4;
        private Label lblErros;
        private Button btnClose;
        private TabPage tabPageEdit;
        private Label label11;
        private TextBox txtID;
        private Label lblErrosEdit;
        private Button btnConfirmar;
        private Button btnVoltar;
        private MaskedTextBox mTxtNumResidencia;
        private TextBox txtSenha;
        private Label label19;
        private Label label4;
        private TextBox txtNome;
        private Button btnCadastrar;
        private TextBox txtRG;
        private MaskedTextBox mTxtCEP;
        private Label label18;
        private Label label5;
        private Label label17;
        private Label label6;
        private TextBox txtEmail;
        private Label label15;
        private MaskedTextBox mTxtTelefone;
        private Label label16;
        private TextBox txtNumResidenciaEdit;
        private TextBox txtSenhaEdit;
        private TextBox txtEmailEdit;
        private TextBox txtRGEdit;
        private TextBox txtNomeEdit;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label12;
        private Label label20;
        private Label label21;
        private Label label22;
        private CheckBox checkBoxAtivo;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox Pesquisar;
        private TextBox txtProcurar;
        private Label label26;
        private MaskedTextBox txtCPF;
        private Label lblCPF;
        private MaskedTextBox txtCPFEdit;
        private MaskedTextBox txtTelefoneEdit;
        private Label label14;
        private MaskedTextBox txtCEPEdit;
        private Label label23;
        private Button btnDeletar;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn ColumnNome;
        private DataGridViewTextBoxColumn ColumnCPF;
        private DataGridViewTextBoxColumn ColumnRG;
        private DataGridViewTextBoxColumn ColumnTELEFONE;
        private DataGridViewTextBoxColumn ColumnEMAIL;
        private DataGridViewTextBoxColumn ColumnEnderecoCEP;
        private DataGridViewTextBoxColumn ColumnEnderecoNumero;
        private DataGridViewCheckBoxColumn ColumnATIVO;
    }
}