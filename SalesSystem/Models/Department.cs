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

        public Department() {

        }

        public Department(int id, string name) {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller) {
            Sellers.Add(seller);
        }

        // para pegar os ganho do departamento é preciso pegar os vendedores
        public double TotalSales(DateTime initial, DateTime final) {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
