using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Services.Exceptions;

namespace SalesSystem.Services {
    public class SellerService {
        private readonly SalesSystemContext _context;
        public SellerService(SalesSystemContext context) {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() {
            return await _context.Seller.ToListAsync();
        }
        public async Task Insert(Seller obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) {
            try {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            } catch(DbUpdateException) {
                throw new IntegrityException("Não pode deletar o vendendor por possuir vendas");
            }
        }
        public async Task UpdateAsync(Seller obj) {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) {
                throw new NotFoundException("Id not found");
            }
            
            try {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException e) {
                throw new DbConcurrencyException(e.Message);
            }
        
        }
    }
}
