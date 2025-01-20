using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MDIELFIAGE
{
    public partial class FormClasse : Form

    {
        Classe classeselected = null;
        public FormClasse()
        {
            InitializeComponent();
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            using (var db = new DBScolaire())
            {
                Classe classe = new Classe();
                classe.Libelle = txtLibelle.Text;
                db.Classe.Add(classe);
                db.SaveChanges();
                    MessageBox.Show("données insérées avec succés","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Actualiser();

            }
        }
            private void Actualiser()
            {
            dataGridView1.DataSource = null;
            using (var db = new DBScolaire())
            {
                dataGridView1.DataSource = db.Classe.ToList();
            }
            }
      

        private void effacer()
        {
            txtLibelle.Text = String.Empty;
            classeselected = null;

        }

        private void FormClasse_Load(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (classeselected == null)
            {
                MessageBox.Show("Veuillez sélectionner une classe à modifier", "Avertissement", MessageBoxButtons.OK);
                return;
            }

            using (var db = new DBScolaire())
            {
                var classe = db.Classe.FirstOrDefault(p => p.Id == classeselected.Id);
                if (classe != null)
                {
                    classe.Libelle = txtLibelle.Text;
                    db.SaveChanges();
                    MessageBox.Show("Données modifiées avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualiser();
                    effacer();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (classeselected == null)
            {
                MessageBox.Show("Veuillez sélectionner une classe pour la supprimer", "Avertissement", MessageBoxButtons.OK);

            }

            using (var db = new DBScolaire())
            {
                var classe = db.Classe.FirstOrDefault(p=>p.Id == classeselected.Id);
                if (classe != null)
                {
                    db.Classe.Remove(classe);
                    db.SaveChanges();
                    MessageBox.Show("Données supprimées avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualiser();
                    effacer();
                }
            }
    }
    }
}
