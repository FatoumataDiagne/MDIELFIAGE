﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIELFIAGE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cRUDCLASSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClasse formClasse = new FormClasse();
            formClasse.MdiParent = this;
            formClasse.Show();

        }

        private void cRUDETUDIANTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEtudiant formetudiant = new FormEtudiant();
            formetudiant.MdiParent = this;
            formetudiant.Show();

        }
    }
}
