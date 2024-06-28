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
    public class RepositoryPlaceDoc<PlaceDoc> : IRepositoryPlaceDoc<PlaceDoc> where PlaceDoc : class
    {
        private readonly QuanLyCongVanDBContext _context;

        private DbSet<PlaceDoc> entities;
        public RepositoryPlaceDoc(QuanLyCongVanDBContext context)
        {
            _context = context;
            entities = _context.Set<PlaceDoc>();
        }
        public async Task<PlaceDoc> Create(PlaceDoc entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await entities.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PlaceDoc> Delete(PlaceDoc entity)
        {
            entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<PlaceDoc>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<PlaceDoc> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<PlaceDoc> Update(PlaceDoc entity)
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
