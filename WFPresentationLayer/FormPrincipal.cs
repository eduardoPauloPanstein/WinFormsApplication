using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace WFPresentationLayer
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //Estas linhas eliminam a oscilação do formulário ou controles na interface gráfica (mas não 100%)
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            if (FuncionarioLogado.ISADM)
            {
                FuncionarioLogado.Nome = "ADMINISTRADOR";
            }
            else
            {
                btnFuncionarios.Visible = false;
            }
            lblNome.Text = FuncionarioLogado.Nome;
            btnRealizarVenda_Click(sender, e);
        }

        #region Detalhes do form
        //MÉTODO DE REDIMENSIONAMENTO PARA REDIMENSIONAR/RESIZE FORM EM TEMPO DE EXECUÇÃO

        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //Desenhar retangulo 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelPrincipal.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Pegar posição antes de maximizar para poder restaurar
        int lx, ly;
        int sw, sh;
        private void btnMax_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        //Abrir forms
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            //Coleção de Forms + busca para verificar se a instancia de tal formulario já existe
            //Assim, cada form vai ser aberto no maximo uma vez :)
            Form formulario;
            formulario = panelForms.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelForms.Controls.Add(formulario);
                panelForms.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormFuncionarios>();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormFornecedores>();
        }

        private void btnLaboratorios_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormLaboratorios>();
        }
        bool sidebarExpand;
        bool sideprodCollapse;
        private void slidebarTimer_Tick(object sender, EventArgs e)
        {
            //Setar min e max size of sidebar
            if (sidebarExpand)
            {
                panelSideBar.Width -= 10;
                if (panelSideBar.Width == panelSideBar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                panelSideBar.Width += 10;
                if (panelSideBar.Width == panelSideBar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void timerProdutos_Tick(object sender, EventArgs e)
        {

            if (sideprodCollapse)
            {
                produtosContainer.Height += 10;
                if (produtosContainer.Height == produtosContainer.MaximumSize.Height)
                {
                    sideprodCollapse = false;
                    timerProdutos.Stop();
                }
            }
            else
            {
                produtosContainer.Height -= 10;
                if (produtosContainer.Height == produtosContainer.MinimumSize.Height)
                {
                    sideprodCollapse = true;
                    timerProdutos.Stop();
                }
            }
        }

        private void btnProdutos_MouseEnter(object sender, EventArgs e)
        {
            timerProdutos.Start();
        }

        private void btnProdutos_MouseLeave(object sender, EventArgs e)
        {
            //timerProdutos.Start();
        }

        private void btnRealizarVenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormSaidaProdutos>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormEntradaProdutos>();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           Application.Restart();
           
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDashboard>();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormClientes>();
        }
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProdutos>();
        }
    }
}
