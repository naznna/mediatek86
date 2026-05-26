using MediaTek86.controleur;
using MediaTek86.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    internal partial class FrmPersonnelAjout : Form
    {
        private FrmPersonnelControleur controleur;
        private Personnel personnel = null;

        public FrmPersonnelAjout(Personnel personnel = null)
        {
            InitializeComponent();
            controleur = new FrmPersonnelControleur();
            this.personnel = personnel;
        }

        private void FrmPersonnelAjout_Load(object sender, EventArgs e)
        {
            List<Service> lesServices = controleur.GetLesServices();
            cboService.DataSource = lesServices;
            cboService.DisplayMember = "Nom";

            if (personnel != null)
            {
                this.Text = "Modifier un personnel";
                txtNom.Text = personnel.Nom;
                txtPrenom.Text = personnel.Prenom;
                txtTel.Text = personnel.Tel;
                txtMail.Text = personnel.Mail;
                foreach (Service s in lesServices)
                {
                    if (s.IdService == personnel.IdService)
                    {
                        cboService.SelectedItem = s;
                    }
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string tel = txtTel.Text;
            string mail = txtMail.Text;
            Service service = (Service)cboService.SelectedItem;
            int idService = service.IdService;

            if (personnel == null)
            {
                Personnel nouveau = new Personnel(0, nom, prenom, tel, mail, idService);
                controleur.AjouterPersonnel(nouveau);
            }
            else
            {
                Personnel modifie = new Personnel(personnel.IdPersonnel, nom, prenom, tel, mail, idService);
                controleur.ModifierPersonnel(modifie);
            }
            this.Close();
        }
    }
}