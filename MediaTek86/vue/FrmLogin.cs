using MediaTek86.controleur;
using MediaTek86.vue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86
{
    public partial class FrmLogin : Form
    {
        private readonly FrmLoginControleur controleur;
        public FrmLogin()
        {
            InitializeComponent();
            controleur = new FrmLoginControleur();
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string pwd = txtPwd.Text;
            if (login == "" || pwd == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Information");
            }
            else if (controleur.ControleAuthentification(login, pwd))
            {
                FrmPersonnel frmPersonnel = new FrmPersonnel();
                frmPersonnel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.", "Erreur");
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
