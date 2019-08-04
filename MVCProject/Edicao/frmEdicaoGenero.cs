﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCProject.Edicao
{
    public partial class frmEdicaoGenero : Form
    {
        int X = 0;
        int Y = 0;

        public frmEdicaoGenero()
        {
            InitializeComponent();

            this.MouseDown += new MouseEventHandler(FrmEdicaoGenero_MouseDown);
            this.MouseMove += new MouseEventHandler(FrmEdicaoGenero_MouseMove);
        }

        public MVCProject.SistemaBibliotecaDBDataSet.GenerosRow generosRow;

        private void FrmEdicaoGenero_Load(object sender, EventArgs e)
        {
            tbxTipo.Text = generosRow.Tipo;
            tbxDescricao.Text = generosRow.Descricao;
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            generosRow.Tipo = tbxTipo.Text;
            generosRow.Descricao = tbxDescricao.Text;

            this.Close();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEdicaoGenero_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void FrmEdicaoGenero_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
    }
}
