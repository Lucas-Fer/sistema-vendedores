using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Models {
    public class Seller {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public double baseSalary{ get; set; }
        public DateTime BirthDate{ get; set; }
        // possui um departamento
        public Department Department{ get; set; }
        // possui varias vendas
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
    }
}
