using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.bddmanager;
using MediaTek86.modele;
using MySql.Data.MySqlClient;

namespace MediaTek86.dal
{
    /// <summary>
    /// classe d'acces aux donnees (toutes les requetes sql)
    /// </summary>
    internal class Acces
    {
        /// <summary>
        /// chaine de connexion mysql
        /// </summary>
        private static readonly string connectionString = "server=localhost;user id=mediatekuser;password=MediaTek86!;database=mediatek86;SslMode=Disabled;AllowPublicKeyRetrieval=true";
        private readonly BddManager bddManager = null;

        /// <summary>
        /// constructeur, recupere l'instance du bddmanager
        /// </summary>
        public Acces()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }

        /// <summary>
        /// verifie login et mdp du responsable
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="pwd">mot de passe</param>
        /// <returns>true si ok</returns>
        public bool ControleAuthentification(string login, string pwd)
        {
            string req = "SELECT * FROM responsable WHERE login = @login AND pwd = SHA2(@pwd, 256);";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@login", login },
                { "@pwd", pwd }
            };
            MySqlDataReader reader = bddManager.ReqSelect(req, parameters);
            bool authentifie = reader.Read();
            reader.Close();
            return authentifie;
        }

        /// <summary>
        /// recupere tous les personnels
        /// </summary>
        /// <returns>liste personnels</returns>
        public List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            string req = "SELECT p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, p.idservice ";
            req += "FROM personnel p ORDER BY p.nom, p.prenom;";
            MySqlDataReader reader = bddManager.ReqSelect(req);
            while (reader.Read())
            {
                int idpersonnel = (int)reader["idpersonnel"];
                string nom = reader["nom"].ToString();
                string prenom = reader["prenom"].ToString();
                string tel = reader["tel"].ToString();
                string mail = reader["mail"].ToString();
                int idservice = (int)reader["idservice"];
                Personnel personnel = new Personnel(idpersonnel, nom, prenom, tel, mail, idservice);
                lesPersonnels.Add(personnel);
            }
            reader.Close();
            return lesPersonnels;
        }

        /// <summary>
        /// recupere tous les services
        /// </summary>
        /// <returns>liste services</returns>
        public List<Service> GetLesServices()
        {
            List<Service> lesServices = new List<Service>();
            string req = "SELECT s.idservice, s.nom FROM service s ORDER BY s.nom;";
            MySqlDataReader reader = bddManager.ReqSelect(req);
            while (reader.Read())
            {
                int idservice = (int)reader["idservice"];
                string nom = reader["nom"].ToString();
                Service service = new Service(idservice, nom);
                lesServices.Add(service);
            }
            reader.Close();
            return lesServices;
        }

        /// <summary>
        /// ajoute un personnel
        /// </summary>
        /// <param name="personnel">le personnel</param>
        public void AjouterPersonnel(Personnel personnel)
        {
            string req = "INSERT INTO personnel(nom, prenom, tel, mail, idservice) ";
            req += "VALUES (@nom, @prenom, @tel, @mail, @idservice);";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@nom", personnel.Nom },
                { "@prenom", personnel.Prenom },
                { "@tel", personnel.Tel },
                { "@mail", personnel.Mail },
                { "@idservice", personnel.IdService }
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// supprime un personnel
        /// </summary>
        /// <param name="personnel">le personnel</param>
        public void SupprimerPersonnel(Personnel personnel)
        {
            string req = "DELETE FROM personnel WHERE idpersonnel = @idpersonnel;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", personnel.IdPersonnel }
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// modifie un personnel
        /// </summary>
        /// <param name="personnel">le personnel</param>
        public void ModifierPersonnel(Personnel personnel)
        {
            string req = "UPDATE personnel SET nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idservice = @idservice ";
            req += "WHERE idpersonnel = @idpersonnel;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", personnel.IdPersonnel },
                { "@nom", personnel.Nom },
                { "@prenom", personnel.Prenom },
                { "@tel", personnel.Tel },
                { "@mail", personnel.Mail },
                { "@idservice", personnel.IdService }
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// recupere tous les motifs
        /// </summary>
        /// <returns>liste motifs</returns>
        public List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            string req = "SELECT m.idmotif, m.libelle FROM motif m ORDER BY m.libelle;";
            MySqlDataReader reader = bddManager.ReqSelect(req);
            while (reader.Read())
            {
                int idmotif = (int)reader["idmotif"];
                string libelle = reader["libelle"].ToString();
                Motif motif = new Motif(idmotif, libelle);
                lesMotifs.Add(motif);
            }
            reader.Close();
            return lesMotifs;
        }

        /// <summary>
        /// recupere les absences d'un personnel
        /// </summary>
        /// <param name="idPersonnel">id du personnel</param>
        /// <returns>liste absences</returns>
        public List<Absence> GetLesAbsences(int idPersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            string req = "SELECT a.idpersonnel, a.datedebut, a.datefin, a.idmotif ";
            req += "FROM absence a WHERE a.idpersonnel = @idpersonnel ";
            req += "ORDER BY a.datedebut DESC;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", idPersonnel }
            };
            MySqlDataReader reader = bddManager.ReqSelect(req, parameters);
            while (reader.Read())
            {
                int idpersonnel = (int)reader["idpersonnel"];
                DateTime datedebut = (DateTime)reader["datedebut"];
                DateTime datefin = (DateTime)reader["datefin"];
                int idmotif = (int)reader["idmotif"];
                Absence absence = new Absence(idpersonnel, datedebut, datefin, idmotif);
                lesAbsences.Add(absence);
            }
            reader.Close();
            return lesAbsences;
        }

        /// <summary>
        /// ajoute une absence
        /// </summary>
        /// <param name="absence">l'absence</param>
        public void AjouterAbsence(Absence absence)
        {
            string req = "INSERT INTO absence(idpersonnel, datedebut, datefin, idmotif) ";
            req += "VALUES (@idpersonnel, @datedebut, @datefin, @idmotif);";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", absence.IdPersonnel },
                { "@datedebut", absence.DateDebut },
                { "@datefin", absence.DateFin },
                { "@idmotif", absence.IdMotif }
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// supprime une absence
        /// </summary>
        /// <param name="absence">l'absence</param>
        public void SupprimerAbsence(Absence absence)
        {
            string req = "DELETE FROM absence WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", absence.IdPersonnel },
                { "@datedebut", absence.DateDebut }
            };
            bddManager.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// modifie une absence
        /// </summary>
        /// <param name="absence">l'absence modifiee</param>
        /// <param name="ancienneDateDebut">ancienne date debut</param>
        public void ModifierAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            string req = "UPDATE absence SET datedebut = @datedebut, datefin = @datefin, idmotif = @idmotif ";
            req += "WHERE idpersonnel = @idpersonnel AND datedebut = @anciennedatedebut;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", absence.IdPersonnel },
                { "@datedebut", absence.DateDebut },
                { "@datefin", absence.DateFin },
                { "@idmotif", absence.IdMotif },
                { "@anciennedatedebut", ancienneDateDebut }
            };
            bddManager.ReqUpdate(req, parameters);
        }
    }
}