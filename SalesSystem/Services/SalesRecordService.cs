using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesSystem.Services {
    public class SalesRecordService {
        private readonly SalesSystemContext _context;
        public SalesRecordService(SalesSystemContext context) {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) {
            var results = from obj in _context.SalesRecord select obj;

            if(minDate.HasValue) {
                results = results.Where(x => x.Date >= minDate.Value);
            }

            if( maxDate.HasValue) {
                results = results.Where(x => x.Date <= maxDate.Value);
            }

            return await results
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate) {
            var results = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue) {
                results = results.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue) {
                results = results.Where(x => x.Date <= maxDate.Value);
            }

            return await results
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
