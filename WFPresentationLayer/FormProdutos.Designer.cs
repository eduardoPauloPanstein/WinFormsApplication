namespace WFPresentationLayer
{
    partial class FormProdutos
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPageProdutos = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQtdEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrecoBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMargemLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAtivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pesquisar = new System.Windows.Forms.PictureBox();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtLab = new System.Windows.Forms.TextBox();
            this.txtML = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecoBase = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblErros = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtLabEdit = new System.Windows.Forms.TextBox();
            this.txtMLEdit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecoBaseEdit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEstoqueEdit = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtDescEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeEdit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblErrosEdit = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabPageProdutos.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pesquisar)).BeginInit();
            this.tabPageAdd.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtML)).BeginInit();
            this.tabPageEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMLEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPageProdutos);
            this.TabControl.Controls.Add(this.tabPageAdd);
            this.TabControl.Controls.Add(this.tabPageEdit);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1141, 652);
            this.TabControl.TabIndex = 8;
            // 
            // tabPageProdutos
            // 
            this.tabPageProdutos.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageProdutos.Controls.Add(this.panel2);
            this.tabPageProdutos.Controls.Add(this.panel3);
            this.tabPageProdutos.Location = new System.Drawing.Point(4, 34);
            this.tabPageProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageProdutos.Name = "tabPageProdutos";
            this.tabPageProdutos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageProdutos.Size = new System.Drawing.Size(1133, 614);
            this.tabPageProdutos.TabIndex = 0;
            this.tabPageProdutos.Text = "Produtos";
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
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
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
            this.ColumnDescricao,
            this.ColumnLaboratorio,
            this.ColumnQtdEstoque,
            this.ColumnPrecoBase,
            this.ColumnMargemLucro,
            this.ColumnPrecoVenda,
            this.ColumnAtivo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
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
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // ColumnNome
            // 
            this.ColumnNome.HeaderText = "Nome";
            this.ColumnNome.Name = "ColumnNome";
            this.ColumnNome.ReadOnly = true;
            // 
            // ColumnDescricao
            // 
            this.ColumnDescricao.HeaderText = "Descrição";
            this.ColumnDescricao.Name = "ColumnDescricao";
            this.ColumnDescricao.ReadOnly = true;
            // 
            // ColumnLaboratorio
            // 
            this.ColumnLaboratorio.HeaderText = "Laboratório";
            this.ColumnLaboratorio.Name = "ColumnLaboratorio";
            this.ColumnLaboratorio.ReadOnly = true;
            // 
            // ColumnQtdEstoque
            // 
            this.ColumnQtdEstoque.HeaderText = "Estoque";
            this.ColumnQtdEstoque.Name = "ColumnQtdEstoque";
            this.ColumnQtdEstoque.ReadOnly = true;
            // 
            // ColumnPrecoBase
            // 
            this.ColumnPrecoBase.HeaderText = "Base";
            this.ColumnPrecoBase.Name = "ColumnPrecoBase";
            this.ColumnPrecoBase.ReadOnly = true;
            // 
            // ColumnMargemLucro
            // 
            this.ColumnMargemLucro.HeaderText = "ML";
            this.ColumnMargemLucro.Name = "ColumnMargemLucro";
            this.ColumnMargemLucro.ReadOnly = true;
            // 
            // ColumnPrecoVenda
            // 
            this.ColumnPrecoVenda.HeaderText = "Venda";
            this.ColumnPrecoVenda.Name = "ColumnPrecoVenda";
            this.ColumnPrecoVenda.ReadOnly = true;
            // 
            // ColumnAtivo
            // 
            this.ColumnAtivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAtivo.HeaderText = "Ativo";
            this.ColumnAtivo.Name = "ColumnAtivo";
            this.ColumnAtivo.ReadOnly = true;
            this.ColumnAtivo.Width = 70;
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
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pictureBox1.TabIndex = 54;
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
            this.Pesquisar.TabIndex = 52;
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
            this.txtProcurar.Size = new System.Drawing.Size(156, 26);
            this.txtProcurar.TabIndex = 51;
            this.txtProcurar.Text = "NOME OU ID";
            this.txtProcurar.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtProcurar.Leave += new System.EventHandler(this.txtProcurar_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(82, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(228, 25);
            this.label26.TabIndex = 53;
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
            this.tabPageAdd.Text = "Cadastrar produto";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.txtLab);
            this.panel4.Controls.Add(this.txtML);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtPrecoBase);
            this.panel4.Controls.Add(this.txtDescricao);
            this.panel4.Controls.Add(this.lblErros);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.txtNome);
            this.panel4.Controls.Add(this.btnCadastrar);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(3, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1127, 610);
            this.panel4.TabIndex = 48;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WFPresentationLayer.Properties.Resources.icons8_reticências_30;
            this.pictureBox2.Location = new System.Drawing.Point(562, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 85;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txtLab
            // 
            this.txtLab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtLab.ForeColor = System.Drawing.Color.White;
            this.txtLab.Location = new System.Drawing.Point(363, 75);
            this.txtLab.Name = "txtLab";
            this.txtLab.ReadOnly = true;
            this.txtLab.Size = new System.Drawing.Size(193, 33);
            this.txtLab.TabIndex = 84;
            // 
            // txtML
            // 
            this.txtML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtML.ForeColor = System.Drawing.Color.White;
            this.txtML.Location = new System.Drawing.Point(407, 173);
            this.txtML.Name = "txtML";
            this.txtML.Size = new System.Drawing.Size(135, 29);
            this.txtML.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 77;
            this.label2.Text = "Preço base:";
            // 
            // txtPrecoBase
            // 
            this.txtPrecoBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtPrecoBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecoBase.ForeColor = System.Drawing.Color.White;
            this.txtPrecoBase.Location = new System.Drawing.Point(363, 279);
            this.txtPrecoBase.Name = "txtPrecoBase";
            this.txtPrecoBase.Size = new System.Drawing.Size(179, 26);
            this.txtPrecoBase.TabIndex = 78;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtDescricao.ForeColor = System.Drawing.Color.White;
            this.txtDescricao.Location = new System.Drawing.Point(29, 161);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(271, 151);
            this.txtDescricao.TabIndex = 74;
            // 
            // lblErros
            // 
            this.lblErros.AutoSize = true;
            this.lblErros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErros.Location = new System.Drawing.Point(562, 133);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(98, 25);
            this.lblErros.TabIndex = 49;
            this.lblErros.Text = "Erros here";
            this.lblErros.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(932, 446);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 43);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Voltar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 44);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 25);
            this.label19.TabIndex = 55;
            this.label19.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(29, 72);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(188, 26);
            this.txtNome.TabIndex = 56;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCadastrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCadastrar.Location = new System.Drawing.Point(308, 349);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(234, 32);
            this.btnCadastrar.TabIndex = 68;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(363, 44);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 25);
            this.label18.TabIndex = 58;
            this.label18.Text = "Laboratorio:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(363, 145);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 25);
            this.label17.TabIndex = 59;
            this.label17.Text = "% Margem lucro:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 133);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 25);
            this.label16.TabIndex = 63;
            this.label16.Text = "Descrição:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(358, 287);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(188, 25);
            this.label20.TabIndex = 80;
            this.label20.Text = "______________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 25);
            this.label9.TabIndex = 81;
            this.label9.Text = "______________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 25);
            this.label10.TabIndex = 82;
            this.label10.Text = "______________________";
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.tabPageEdit.Controls.Add(this.btnDeletar);
            this.tabPageEdit.Controls.Add(this.pictureBox3);
            this.tabPageEdit.Controls.Add(this.txtLabEdit);
            this.tabPageEdit.Controls.Add(this.txtMLEdit);
            this.tabPageEdit.Controls.Add(this.label3);
            this.tabPageEdit.Controls.Add(this.txtPrecoBaseEdit);
            this.tabPageEdit.Controls.Add(this.label8);
            this.tabPageEdit.Controls.Add(this.txtEstoqueEdit);
            this.tabPageEdit.Controls.Add(this.btnVoltar);
            this.tabPageEdit.Controls.Add(this.txtDescEdit);
            this.tabPageEdit.Controls.Add(this.label4);
            this.tabPageEdit.Controls.Add(this.txtNomeEdit);
            this.tabPageEdit.Controls.Add(this.label5);
            this.tabPageEdit.Controls.Add(this.label6);
            this.tabPageEdit.Controls.Add(this.label7);
            this.tabPageEdit.Controls.Add(this.checkBoxAtivo);
            this.tabPageEdit.Controls.Add(this.label11);
            this.tabPageEdit.Controls.Add(this.txtID);
            this.tabPageEdit.Controls.Add(this.lblErrosEdit);
            this.tabPageEdit.Controls.Add(this.btnConfirmar);
            this.tabPageEdit.Controls.Add(this.label12);
            this.tabPageEdit.Controls.Add(this.label13);
            this.tabPageEdit.Controls.Add(this.label14);
            this.tabPageEdit.Controls.Add(this.label15);
            this.tabPageEdit.Controls.Add(this.label21);
            this.tabPageEdit.Controls.Add(this.label22);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 34);
            this.tabPageEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageEdit.Size = new System.Drawing.Size(1133, 614);
            this.tabPageEdit.TabIndex = 2;
            this.tabPageEdit.Text = "Editar produto";
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnDeletar.FlatAppearance.BorderSize = 0;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(348, 477);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(265, 28);
            this.btnDeletar.TabIndex = 114;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WFPresentationLayer.Properties.Resources.icons8_reticências_30;
            this.pictureBox3.Location = new System.Drawing.Point(579, 101);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 113;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // txtLabEdit
            // 
            this.txtLabEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtLabEdit.ForeColor = System.Drawing.Color.White;
            this.txtLabEdit.Location = new System.Drawing.Point(384, 95);
            this.txtLabEdit.Name = "txtLabEdit";
            this.txtLabEdit.ReadOnly = true;
            this.txtLabEdit.Size = new System.Drawing.Size(193, 33);
            this.txtLabEdit.TabIndex = 112;
            // 
            // txtMLEdit
            // 
            this.txtMLEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtMLEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMLEdit.ForeColor = System.Drawing.Color.White;
            this.txtMLEdit.Location = new System.Drawing.Point(409, 202);
            this.txtMLEdit.Name = "txtMLEdit";
            this.txtMLEdit.Size = new System.Drawing.Size(154, 29);
            this.txtMLEdit.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 275);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 103;
            this.label3.Text = "Preço base:";
            // 
            // txtPrecoBaseEdit
            // 
            this.txtPrecoBaseEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtPrecoBaseEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecoBaseEdit.ForeColor = System.Drawing.Color.White;
            this.txtPrecoBaseEdit.Location = new System.Drawing.Point(384, 303);
            this.txtPrecoBaseEdit.Name = "txtPrecoBaseEdit";
            this.txtPrecoBaseEdit.Size = new System.Drawing.Size(179, 26);
            this.txtPrecoBaseEdit.TabIndex = 104;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(645, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 100;
            this.label8.Text = "Estoque:";
            // 
            // txtEstoqueEdit
            // 
            this.txtEstoqueEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtEstoqueEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstoqueEdit.ForeColor = System.Drawing.Color.White;
            this.txtEstoqueEdit.Location = new System.Drawing.Point(645, 205);
            this.txtEstoqueEdit.Name = "txtEstoqueEdit";
            this.txtEstoqueEdit.Size = new System.Drawing.Size(96, 26);
            this.txtEstoqueEdit.TabIndex = 101;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Location = new System.Drawing.Point(348, 404);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(265, 28);
            this.btnVoltar.TabIndex = 99;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtDescEdit
            // 
            this.txtDescEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtDescEdit.ForeColor = System.Drawing.Color.White;
            this.txtDescEdit.Location = new System.Drawing.Point(50, 185);
            this.txtDescEdit.Multiline = true;
            this.txtDescEdit.Name = "txtDescEdit";
            this.txtDescEdit.Size = new System.Drawing.Size(271, 151);
            this.txtDescEdit.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 89;
            this.label4.Text = "Nome:";
            // 
            // txtNomeEdit
            // 
            this.txtNomeEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtNomeEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNomeEdit.ForeColor = System.Drawing.Color.White;
            this.txtNomeEdit.Location = new System.Drawing.Point(50, 96);
            this.txtNomeEdit.Name = "txtNomeEdit";
            this.txtNomeEdit.Size = new System.Drawing.Size(187, 26);
            this.txtNomeEdit.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 91;
            this.label5.Text = "Laboratorio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 25);
            this.label6.TabIndex = 92;
            this.label6.Text = "% Margem lucro:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 157);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 93;
            this.label7.Text = "Descrição:";
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Location = new System.Drawing.Point(668, 305);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(74, 29);
            this.checkBoxAtivo.TabIndex = 86;
            this.checkBoxAtivo.Text = "Ativo";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(649, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 25);
            this.label11.TabIndex = 15;
            this.label11.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.ForeColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(646, 95);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(96, 26);
            this.txtID.TabIndex = 9;
            // 
            // lblErrosEdit
            // 
            this.lblErrosEdit.AutoSize = true;
            this.lblErrosEdit.ForeColor = System.Drawing.Color.Maroon;
            this.lblErrosEdit.Location = new System.Drawing.Point(748, 99);
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
            this.btnConfirmar.Location = new System.Drawing.Point(50, 404);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(265, 28);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(380, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 25);
            this.label12.TabIndex = 105;
            this.label12.Text = "______________________";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(380, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 25);
            this.label13.TabIndex = 106;
            this.label13.Text = "______________________";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 25);
            this.label14.TabIndex = 107;
            this.label14.Text = "______________________";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(645, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 25);
            this.label15.TabIndex = 108;
            this.label15.Text = "___________";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(642, 217);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 25);
            this.label21.TabIndex = 109;
            this.label21.Text = "___________";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(645, 314);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 25);
            this.label22.TabIndex = 110;
            this.label22.Text = "___________";
            // 
            // FormProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1141, 652);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormProdutos";
            this.Text = "FormProdutos";
            this.Load += new System.EventHandler(this.FormProdutos_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPageProdutos.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pesquisar)).EndInit();
            this.tabPageAdd.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtML)).EndInit();
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMLEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl TabControl;
        private TabPage tabPageProdutos;
        private TabPage tabPageAdd;
        private Panel panel4;
        private TextBox txtDescricao;
        private Label lblErros;
        private Button btnClose;
        private Label label19;
        private TextBox txtNome;
        private Button btnCadastrar;
        private Label label18;
        private Label label17;
        private Label label16;
        private TabPage tabPageEdit;
        private CheckBox checkBoxAtivo;
        private Label label11;
        private TextBox txtID;
        private Label lblErrosEdit;
        private Button btnConfirmar;
        private Label label2;
        private TextBox txtPrecoBase;
        private Button btnVoltar;
        private TextBox txtDescEdit;
        private Label label4;
        private TextBox txtNomeEdit;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtEstoqueEdit;
        private Label label3;
        private TextBox txtPrecoBaseEdit;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox Pesquisar;
        private TextBox txtProcurar;
        private Label label26;
        private Label label20;
        private Label label9;
        private Label label10;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label21;
        private Label label22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn ColumnNome;
        private DataGridViewTextBoxColumn ColumnDescricao;
        private DataGridViewTextBoxColumn ColumnLaboratorio;
        private DataGridViewTextBoxColumn ColumnQtdEstoque;
        private DataGridViewTextBoxColumn ColumnPrecoBase;
        private DataGridViewTextBoxColumn ColumnMargemLucro;
        private DataGridViewTextBoxColumn ColumnPrecoVenda;
        private DataGridViewTextBoxColumn ColumnAtivo;
        private NumericUpDown txtML;
        private NumericUpDown txtMLEdit;
        private PictureBox pictureBox2;
        private TextBox txtLab;
        private PictureBox pictureBox3;
        private TextBox txtLabEdit;
        private Button btnDeletar;
    }
}