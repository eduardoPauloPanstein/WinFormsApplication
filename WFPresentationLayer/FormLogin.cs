using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Utilidades;

namespace WFPresentationLayer
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtEmail.Text, txtSenha.Text);
            BusinessLogicalLayer.Utilidades.LoginBLL acessar = new();
            acessar.ConferirDefault();
            if (txtEmail.Text != "Email" && txtEmail.TextLength > 2)
            {
                if (txtSenha.Text != "Senha")
                {
                    //Passar o ADM para o banco de dados como um cargo nos funcionarios
                    var validLogin = acessar.Login(usuario);

                    if (validLogin.HasSuccess)
                    {
                        FormPrincipal formPrincipal = new();
                        //MessageBox.Show("Bem vindo " + FuncionarioLogado.Nome);
                        formPrincipal.Show();
                        formPrincipal.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Credenciais de login invalidas. Por favor confira");
                        txtSenha.Text = "Senha";
                        txtSenha.UseSystemPasswordChar = false;
                        txtEmail.Focus();
                    }
                }
                else msgError("Por favor insira uma senha.");
            }
            else msgError("Por favor insira um email.");
        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "" + msg;
            lblErrorMessage.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtSenha.Text = "Senha";
            txtSenha.UseSystemPasswordChar = false;
            txtEmail.Text = "Email";
            lblErrorMessage.Visible = false;
            this.Show();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.LightGray;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void txtSenha_Enter_1(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.White;
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void txtSenha_Leave_1(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "Senha";
                txtSenha.ForeColor = Color.LightGray;
                txtSenha.UseSystemPasswordChar = false;
            }
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
