using Microsoft.AspNetCore.Mvc;
using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Controllers {
    public class DepartmentsController : Controller {
        public IActionResult Index() {
            // lista de departamentos
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Eletronicos" });
            list.Add(new Department { Id = 2, Name = "Fashion" });
            // quando adicionar a view, escolher a lista
            return View(list);
        }
    }
}
