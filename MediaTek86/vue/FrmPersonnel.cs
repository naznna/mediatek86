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
    }
}