using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    internal class Acces
    {
        private static readonly string connectionString = "server=localhost;user id=mediatekuser;password=MediaTek86!;database=mediatek86;SslMode=none";
        private readonly BddManager bddManager = null;
        public Acces()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }
    }
}
