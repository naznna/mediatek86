using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// classe singleton pour la connexion mysql
    /// </summary>
    public class BddManager
    {
        private static BddManager instance = null;
        private readonly MySqlConnection connection;

        /// <summary>
        /// constructeur privé, ouvre la co
        /// </summary>
        /// <param name="stringConnect">chaine de connexion</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// récupère l'instance unique (singleton)
        /// </summary>
        /// <param name="stringConnect">chaine de connexion</param>
        /// <returns>instance de BddManager</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }

        /// <summary>
        /// exécute insert/update/delete
        /// </summary>
        /// <param name="stringQuery">requete sql</param>
        /// <param name="parameters">paramètres</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// exécute un select et renvoie le reader
        /// </summary>
        /// <param name="stringQuery">requete sql</param>
        /// <param name="parameters">paramètres</param>
        /// <returns>le MySqlDataReader</returns>
        public MySqlDataReader ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            return command.ExecuteReader();
        }
    }
}