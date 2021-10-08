using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Models {
    public class Department {
        public int Id { get; set; }
        public string Name{ get; set; }
        // list of sellers
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
    }
}
