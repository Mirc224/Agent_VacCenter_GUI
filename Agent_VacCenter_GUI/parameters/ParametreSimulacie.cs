using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parameters
{
    public class ParametreSimulacie
    {
        public int Replikacie { get; set; }
        public double CasSimulacie { get; set; }
        public bool SpecialnePrichody { get; set; }
        public int ReplikaciiNaUpdate { get; set; }
        public bool ZobrazenieZavislosti { get; set; }
        public int PocetPacientov { get; set; }

        public int MinDoktorov { get; set; }
        public int MaxDoktorov { get; set; }
        public int MinSestriciek { get; set; }
        public int MaxSestriciek { get; set; }
        public int MinAdminov { get; set; }
        public int MaxAdminov { get; set; }

    }
}
