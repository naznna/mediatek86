using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.bddmanager;
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
    }
}
