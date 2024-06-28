using Microsoft.EntityFrameworkCore;
using QuanLyTaiLieu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Repository
{
    public class RepositoryNumberDoc<NumberDoc> : IRepositoryNumberDoc<NumberDoc> where NumberDoc : class
    {
        private readonly QuanLyCongVanDBContext _context;

        private DbSet<NumberDoc> entities;
        public RepositoryNumberDoc(QuanLyCongVanDBContext context)
        {
            _context = context;
            entities = _context.Set<NumberDoc>();
        }
        public async Task<NumberDoc> Create(NumberDoc entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await entities.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<NumberDoc> Delete(NumberDoc entity)
        {
            entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<NumberDoc>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<NumberDoc> GetById(string id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<NumberDoc> Update(NumberDoc entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(null, nameof(entity));
            }
            entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
