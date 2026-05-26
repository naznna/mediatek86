using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    public partial class FrmPersonnel : Form
    {
        private readonly FrmPersonnelControleur controleur;
        private readonly BindingSource bdgPersonnel = new BindingSource();

        public FrmPersonnel()
        {
            InitializeComponent();
            controleur = new FrmPersonnelControleur();
            RemplirListePersonnel();
        }

        private void RemplirListePersonnel()
        {
            List<Personnel> lesPersonnels = controleur.GetLesPersonnels();
            bdgPersonnel.DataSource = lesPersonnels;
            dgvPersonnel.DataSource = bdgPersonnel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPersonnelAjout frmAjout = new FrmPersonnelAjout();
            frmAjout.ShowDialog();
            RemplirListePersonnel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.CurrentRow != null)
            {
                Personnel personnel = (Personnel)bdgPersonnel.Current;
                DialogResult reponse = MessageBox.Show(
                    "Voulez-vous vraiment supprimer " + personnel.Nom + " " + personnel.Prenom + " ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (reponse == DialogResult.Yes)
                {
                    controleur.SupprimerPersonnel(personnel);
                    RemplirListePersonnel();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.CurrentRow != null)
            {
                Personnel personnel = (Personnel)bdgPersonnel.Current;
                FrmPersonnelAjout frmModif = new FrmPersonnelAjout(personnel);
                frmModif.ShowDialog();
                RemplirListePersonnel();
            }
        }

        private void dgvPersonnel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPersonnel.CurrentRow != null)
            {
                Personnel personnel = (Personnel)bdgPersonnel.Current;
                FrmAbsences frmAbsences = new FrmAbsences(personnel);
                frmAbsences.ShowDialog();
            }
        }
    }
}