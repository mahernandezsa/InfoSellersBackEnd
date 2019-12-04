using InfoSellers.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Model.Repository
{
    public class BikeSellerDataRepository : IDataRepository<BikeSeller, int>
    {
        private readonly InfoSellersContext _context;
        public BikeSellerDataRepository(InfoSellersContext context)
        {
            _context = context;
        }

        public async Task<long> Add(BikeSeller bikeSeller)
        {
            _context.BikeSeller.Add(bikeSeller);
            int res = await _context.SaveChangesAsync();
            return res;
        }

        public async Task<long> Delete(int id)
        {
            int res = 0;
            var bikeSeller = await _context.BikeSeller.FindAsync(id);

            if (bikeSeller != null)
            {
                _context.BikeSeller.Remove(bikeSeller);
                res = await _context.SaveChangesAsync();
            }
            return res;
        }

        public IQueryable<BikeSeller> GetAll()
        {
            var bikeSeller = _context.BikeSeller.Include(r => r.Role).AsNoTracking();
            return bikeSeller;
        }

        public async Task<long> Update(int id, BikeSeller bikeSeller)
        {
            int res = 0;
            _context.Entry(bikeSeller).State = EntityState.Modified;
            _context.Entry(bikeSeller).Property(p => p.PenaltyPercentage).IsModified = false;
            try
            {
                res = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BikeSellerExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
            return res;
        }

        private async Task<bool> BikeSellerExists(int id)
        {
            return await _context.BikeSeller.AnyAsync(e => e.Id.Equals(id));
        }
    }
}

