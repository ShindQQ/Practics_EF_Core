using System;
using System.Collections.Generic;

namespace Practic1
{
    public partial class BuildingCompany
    {
        public BuildingCompany()
        {
            Brigades = new HashSet<Brigade>();
            Orders = new HashSet<Order>();
        }

        public int BuildingCompanyId { get; set; }
        public int WorkersAmmount { get; set; }
        public string? Name { get; set; }
        public int ProjectsAmmount { get; set; }
        public int BrigadesAmmount { get; set; }

        public virtual ICollection<Brigade> Brigades { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
