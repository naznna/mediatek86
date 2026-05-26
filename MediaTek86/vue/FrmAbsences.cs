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
    internal partial class FrmAbsences : Form
    {
        private readonly FrmPersonnelControleur controleur;
        private readonly BindingSource bdgAbsences = new BindingSource();
        private readonly Personnel personnel;
        private List<Motif> lesMotifs;
        private Absence absenceEnCours = null;

        public FrmAbsences(Personnel personnel)
        {
            InitializeComponent();
            controleur = new FrmPersonnelControleur();
            this.personnel = personnel;
        }

        private void FrmAbsences_Load(object sender, EventArgs e)
        {
            this.Text = "Absences de " + personnel.Nom + " " + personnel.Prenom;
            lesMotifs = controleur.GetLesMotifs();
            cboMotif.DataSource = lesMotifs;
            cboMotif.DisplayMember = "Libelle";
            RemplirListeAbsences();
        }

        private void RemplirListeAbsences()
        {
            List<Absence> lesAbsences = controleur.GetLesAbsences(personnel.IdPersonnel);
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsences.DataSource = bdgAbsences;
        }

        private bool ControleSaisie()
        {
            DateTime debut = dtpDateDebut.Value.Date;
            DateTime fin = dtpDateFin.Value.Date;
            if (fin < debut)
            {
                MessageBox.Show("La date de fin est anterieure a la date de debut.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            List<Absence> lesAbsences = controleur.GetLesAbsences(personnel.IdPersonnel);
            foreach (Absence a in lesAbsences)
            {
                if (absenceEnCours != null && a.DateDebut == absenceEnCours.DateDebut)
                {
                    continue;
                }
                if (debut <= a.DateFin.Date && fin >= a.DateDebut.Date)
                {
                    MessageBox.Show("Une absence est deja programmee sur ce creneau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ControleSaisie())
            {
                Motif motif = (Motif)cboMotif.SelectedItem;
                Absence absence = new Absence(personnel.IdPersonnel, dtpDateDebut.Value.Date, dtpDateFin.Value.Date, motif.IdMotif);
                controleur.AjouterAbsence(absence);
                absenceEnCours = null;
                RemplirListeAbsences();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.CurrentRow != null && absenceEnCours != null)
            {
                if (ControleSaisie())
                {
                    Motif motif = (Motif)cboMotif.SelectedItem;
                    Absence absence = new Absence(personnel.IdPersonnel, dtpDateDebut.Value.Date, dtpDateFin.Value.Date, motif.IdMotif);
                    controleur.ModifierAbsence(absence, absenceEnCours.DateDebut);
                    absenceEnCours = null;
                    RemplirListeAbsences();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.CurrentRow != null)
            {
                Absence absence = (Absence)bdgAbsences.Current;
                DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer cette absence ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reponse == DialogResult.Yes)
                {
                    controleur.SupprimerAbsence(absence);
                    RemplirListeAbsences();
                }
            }
        }

        private void dgvAbsences_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAbsences.CurrentRow != null && bdgAbsences.Current != null)
            {
                absenceEnCours = (Absence)bdgAbsences.Current;
                dtpDateDebut.Value = absenceEnCours.DateDebut;
                dtpDateFin.Value = absenceEnCours.DateFin;
                foreach (Motif m in lesMotifs)
                {
                    if (m.IdMotif == absenceEnCours.IdMotif)
                    {
                        cboMotif.SelectedItem = m;
                    }
                }
            }
        }
    }
}