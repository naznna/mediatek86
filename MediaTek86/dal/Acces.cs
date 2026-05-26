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
    internal class Acces
    {
        private static readonly string connectionString = "server=localhost;user id=mediatekuser;password=MediaTek86!;database=mediatek86;SslMode=Disabled;AllowPublicKeyRetrieval=true";
        private readonly BddManager bddManager = null;
        public Acces()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }

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

        public void SupprimerPersonnel(Personnel personnel)
        {
            string req = "DELETE FROM personnel WHERE idpersonnel = @idpersonnel;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idpersonnel", personnel.IdPersonnel }
            };
            bddManager.ReqUpdate(req, parameters);
        }
    }
}