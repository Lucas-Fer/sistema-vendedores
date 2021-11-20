using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Models {
    public class Seller {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} é entre {2} e {1}")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "informe um capo de email válido")]
        public string Email{ get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser atendido entre: {1} e {2}")]
        public double BaseSalary{ get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime BirthDate{ get; set; }

        // possui um departamento
        public Department Department{ get; set; }
        // chave estrangeira para inserir o departamento
        public int DepartmentId { get; set; }
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
