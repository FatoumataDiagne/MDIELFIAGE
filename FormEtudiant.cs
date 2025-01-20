using System;
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
    public partial class FormEtudiant : Form
    {
        Etudiant etudiantselected = null;
        public FormEtudiant()
        {
            InitializeComponent();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                Etudiant etudiant = new Etudiant();
                etudiant.Prenom = txtPrenom.Text;
                etudiant.Nom = txtNom.Text;
                etudiant.IdClasse = (int)comboBox1.SelectedValue;
                etudiant.classe = db.Classe.FirstOrDefault(c => c.Id == etudiant.IdClasse);
                db.Etudiant.Add(etudiant);
                db.SaveChanges(); 
                MessageBox.Show("données insérées avec succés", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualiser();
            }
        }
        private void Actualiser()
        {
            dataGridView1.DataSource = null;
            using (var db = new DBScolaire())
            {
                dataGridView1.DataSource = db.Etudiant.Select(e => new ViewEtudiant { Id = e.Id, Prenom = e.Prenom, Nom = e.Nom, Libelle = e.classe.Libelle }).ToList();

            }

        }
        private void FormEtudiant_Load(object sender, EventArgs e)
        {
            using (var db = new DBScolaire())
            {
                comboBox1.DataSource= db.Classe.ToList();
                comboBox1.DisplayMember = "Libelle";
                comboBox1.ValueMember = "Id";
            }
            Actualiser();
            
        }
      

        private void effacer()
        {
            txtPrenom.Text = String.Empty;
            txtNom.Text = String.Empty;
            comboBox1.Text = "selectionner";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (etudiantselected == null)
            {
                MessageBox.Show("Veuillez sélectionner un etudiant à supprimer", "Avertissement", MessageBoxButtons.OK);
                
            }

            using (var db = new DBScolaire())
            {
                var etudiant = db.Etudiant.FirstOrDefault(p=>p.Id == etudiantselected.Id);
                if (etudiant != null)
                {
                    db.Etudiant.Remove(etudiant);
                    db.SaveChanges();
                    MessageBox.Show("Données supprimées avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualiser();
                    effacer();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (etudiantselected == null)
            {
                MessageBox.Show("Veuillez sélectionner un etudiant pour le modifier", "Avertissement", MessageBoxButtons.OK);
                return;
            }

            using (var db = new DBScolaire())
            {
                var etudiant = db.Etudiant.FirstOrDefault(p=>p.Id == etudiantselected.Id);
                if (etudiant != null)
                {
                    etudiant.Prenom = txtPrenom.Text;
                    etudiant.Nom = txtNom.Text;
                    etudiant.IdClasse = (int)comboBox1.SelectedValue;
                    etudiant.classe = db.Classe.FirstOrDefault(c=>c.Id == etudiant.IdClasse);
                    db.SaveChanges();
                    MessageBox.Show("Données modifiées avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualiser();
                    effacer();
                }
            }
        }
    }
}
