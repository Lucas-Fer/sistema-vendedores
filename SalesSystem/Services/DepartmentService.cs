using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesSystem.Services {
    public class DepartmentService {
        private readonly SalesSystemContext _context;
        public DepartmentService(SalesSystemContext context) {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() {
            // chamar a lista de forma ordenada
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
