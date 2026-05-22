using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.dal;

namespace MediaTek86.controleur
{
    internal class FrmLoginControleur
    {
        private readonly Acces acces;

        public FrmLoginControleur()
        {
            acces = new Acces();
        }

        public bool ControleAuthentification(string login, string pwd)
        {
            return acces.ControleAuthentification(login, pwd);
        }
    }
}
