using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services {
    public class DepartmentService {
        private readonly SalesSystemContext _context;
        public DepartmentService(SalesSystemContext context) {
            _context = context;
        }

        public List<Department> FindAll() {
            // chamar a lista de forma ordenada
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
