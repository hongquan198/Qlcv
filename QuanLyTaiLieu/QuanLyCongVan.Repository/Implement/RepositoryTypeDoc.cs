using CuaHangBanLe.Repository;
using Microsoft.EntityFrameworkCore;
using QuanLyTaiLieu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanLe.Repository
{
    public class RepositoryTypeDoc<TypeDoc> : IRepositoryTypeDoc<TypeDoc> where TypeDoc : class
    {
        private readonly QuanLyCongVanDBContext _context;

        private DbSet<TypeDoc> entities;
        public RepositoryTypeDoc(QuanLyCongVanDBContext context)
        {
            _context = context;
            entities = _context.Set<TypeDoc>();
        }
        public async Task<TypeDoc> Create(TypeDoc entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await entities.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TypeDoc> Delete(TypeDoc entity)
        {
            entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TypeDoc>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<TypeDoc> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<TypeDoc> Update(TypeDoc entity)
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
