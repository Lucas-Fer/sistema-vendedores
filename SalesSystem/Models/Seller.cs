using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Models {
    public class Seller {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public double BaseSalary{ get; set; }
        public DateTime BirthDate{ get; set; }
        // possui um departamento
        public Department Department{ get; set; }
        // possui varias vendas
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        

        public Seller() {

        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department) {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        // adicionar a venda ao vendedor
        public void AddSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        // removendo a venda
        public void RemoveSales(SalesRecord sr) {
            Sales.Remove(sr);
        }
        
        public double TotalSales(DateTime initial, DateTime final) {
            // filtrar as vendas                                             // realizar a soma pelos ganhos
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
