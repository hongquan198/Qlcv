using Microsoft.EntityFrameworkCore;
using QuanLyTaiLieu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Repository
{
    public class RepositoryAccount<Account> : IRepositoryAccount<Account> where Account : class
    {
        private readonly QuanLyCongVanDBContext _context;

        private DbSet<Account> entities;
        public RepositoryAccount(QuanLyCongVanDBContext context)
        {
            _context = context;
            entities = _context.Set<Account>();
        }
        public async Task<Account> Create(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await entities.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Account> Delete(Account entity)
        {
            entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<Account> GetById(string id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<Account> Update(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(null, nameof(entity));
            }
            entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Account>> ListByRole(string roleId)
        {
            return (IEnumerable<Account>)await _context.Account.Where(a => a.RoleId == roleId).ToListAsync();
        }

    }
}
