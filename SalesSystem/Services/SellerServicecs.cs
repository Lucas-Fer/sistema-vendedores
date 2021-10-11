﻿using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services {
    public class SellerServicecs {
        private readonly SalesSystemContext _context;
        public SellerServicecs(SalesSystemContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
    }
}
