using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.modele
{
    internal class Service
    {
        public int IdService { get; set; }
        public string Nom { get; set; }

        public Service(int idService, string nom)
        {
            IdService = idService;
            Nom = nom;
        }
    }
}
