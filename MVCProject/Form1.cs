﻿using MVCProject.Model;
using MVCProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCProject
{
    public partial class Form1 : Form
    {
        int X = 0;
        int Y = 0;

        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }

        private bool Logado = false;

        private void Button1_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal();
            frmPrincipal2 principal2 = new frmPrincipal2();

            bool resultado = VerificaLogin();

            Logado = resultado;

            if (resultado)
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaBibliotecaDB;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand("select Id from Usuarios where Login = '" + tbxLogin.Text + "' and Senha = '" + tbxSenha.Text + "';", cn);
                    cn.Open();
                    var userId = (int)cmd.ExecuteScalar();
                }

                tbxLogin.Text = "";
                tbxSenha.Text = "";

                principal2.ShowDialog();
            }
            else
                MessageBox.Show("Usuário ou senha incorreto!");
        }

        bool VerificaLogin()
        {
            var result = false;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaBibliotecaDB;Integrated Security=True";
                SqlCommand cmd = new SqlCommand("select * from Usuarios where Login = '" + tbxLogin.Text + "'and Senha = '" + tbxSenha.Text + "' and Ativo = 1;", cn);
                cn.Open();
                SqlDataReader dados = cmd.ExecuteReader();
                result = dados.HasRows;
                cn.Close();
            }
            
            return result;
        }



        private void TbxLogin_Enter(object sender, EventArgs e)
        {
            if (tbxLogin.Text == "LOGIN")
            {
                tbxLogin.Text = "";
                tbxLogin.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void TbxLogin_Leave(object sender, EventArgs e)
        {
            if (tbxLogin.Text == "")
            {
                tbxLogin.Text = "LOGIN";
                tbxLogin.ForeColor = Color.Gray;
            }
        }

        private void TbxSenha_Enter(object sender, EventArgs e)
        {
            if (tbxSenha.Text == "SENHA")
            {
                tbxSenha.Text = "";
                tbxSenha.ForeColor = Color.FromArgb(64, 64, 64);
                tbxSenha.UseSystemPasswordChar = true;
            }
        }

        private void TbxSenha_Leave(object sender, EventArgs e)
        {
            if (tbxSenha.Text == "")
            {
                tbxSenha.Text = "SENHA";
                tbxSenha.ForeColor = Color.Gray;
                tbxSenha.UseSystemPasswordChar = false;
            }
        }

        private void TbxLogin_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
    }
}
