using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesSystem.Models;
namespace SalesSystem.Data {
    public class SeedingService {
        private SalesSystemContext _context;
        public SeedingService(SalesSystemContext context) {
            _context = context;
        }
        // popular o banco de dados dinamicamente
        public void Seed() {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return;
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Charles Almeida", "charlin@gmail.com", 1000.0, new DateTime(1998, 4, 21), d1);
            Seller s2 = new Seller(2, "Charles Almeidinha", "charlin2@gmail.com", 2000.0, new DateTime(1979, 12, 31), d2);
            Seller s3 = new Seller(3, "Charles Almeidasso", "charlin3@gmail.com", 4000.0, new DateTime(1988, 1, 15), d3);
            Seller s4 = new Seller(4, "Charles Almeidaassos", "charlinsss@gmail.com", 8000.0, new DateTime(1918, 4, 11), d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 12000.0, Models.Enums.SalesStatus.Billed, s1);
            // adicionar dinamicamento no banco de dados

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(r1);


            _context.SaveChanges();
        }
    }
}
