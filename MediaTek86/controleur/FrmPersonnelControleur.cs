using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.dal;
using MediaTek86.modele;

namespace MediaTek86.controleur
{
    internal class FrmPersonnelControleur
    {
        private readonly Acces acces;

        public FrmPersonnelControleur()
        {
            acces = new Acces();
        }

        public List<Personnel> GetLesPersonnels()
        {
            return acces.GetLesPersonnels();
        }

        public List<Service> GetLesServices()
        {
            return acces.GetLesServices();
        }

        public void AjouterPersonnel(Personnel personnel)
        {
            acces.AjouterPersonnel(personnel);
        }

        public void SupprimerPersonnel(Personnel personnel)
        {
            acces.SupprimerPersonnel(personnel);
        }

        public void ModifierPersonnel(Personnel personnel)
        {
            acces.ModifierPersonnel(personnel);
        }

        public List<Motif> GetLesMotifs()
        {
            return acces.GetLesMotifs();
        }

        public List<Absence> GetLesAbsences(int idPersonnel)
        {
            return acces.GetLesAbsences(idPersonnel);
        }

        public void AjouterAbsence(Absence absence)
        {
            acces.AjouterAbsence(absence);
        }

        public void SupprimerAbsence(Absence absence)
        {
            acces.SupprimerAbsence(absence);
        }

        public void ModifierAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            acces.ModifierAbsence(absence, ancienneDateDebut);
        }
    }
}