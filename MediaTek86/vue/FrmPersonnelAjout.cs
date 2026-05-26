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
    public partial class FrmPersonnelAjout : Form
    {
        private FrmPersonnelControleur controleur;

        public FrmPersonnelAjout()
        {
            InitializeComponent();
            controleur = new FrmPersonnelControleur();
        }

        private void FrmPersonnelAjout_Load(object sender, EventArgs e)
        {
            List<Service> lesServices = controleur.GetLesServices();
            cboService.DataSource = lesServices;
            cboService.DisplayMember = "Nom";
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
            Personnel personnel = new Personnel(0, nom, prenom, tel, mail, idService);
            controleur.AjouterPersonnel(personnel);
            this.Close();
        }
    }
}