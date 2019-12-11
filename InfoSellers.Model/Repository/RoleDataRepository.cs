using InfoSellers.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Model.Repository
{
    public class RoleDataRepository : IDataRepository<Role, int>
    {
        private readonly InfoSellersContext _context;
        public RoleDataRepository(InfoSellersContext context)
        {
            _context = context;
        }

        public async Task<long> Add(Role role)
        {
            _context.Role.Add(role);
            int res = await _context.SaveChangesAsync();
            return res;
        }

        public async Task<long> Delete(int id)
        {
            int res = 0;
            var role = await _context.Role.FindAsync(id);

            if (role != null)
            {
                _context.Role.Remove(role);
                res = await _context.SaveChangesAsync();
            }
            return res;
        }

        public async Task<Role> GetById(int id)
        {
            var role = await _context.Role.FindAsync(id);
            return role;
        }

        public IQueryable<Role> GetAll()
        {
            var roles = _context.Role.ToList().AsQueryable();
            return roles;
        }

        public async Task<long> Update(int id, Role role)
        {
            int res = 0;
            _context.Entry(role).State = EntityState.Modified;
           
            try
            {
                res = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoleExists(id))
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

        private async Task<bool> RoleExists(int id)
        {
            return await _context.Role.AnyAsync(e => e.Id.Equals(id));
        }
    }
}
