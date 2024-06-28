using CuaHangBanLe.Repository;
using Microsoft.EntityFrameworkCore;
using QuanLyTaiLieu.Domain.Models;
using QuanLyTaiLieu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanLe.Repository
{
    public class RepositoryDocument<Document> : IRepositoryDocument<Document> where Document : class
    {
        private readonly QuanLyCongVanDBContext _context;

        private DbSet<Document> entities;
        public RepositoryDocument(QuanLyCongVanDBContext context)
        {
            _context = context;
            entities = _context.Set<Document>();
        }
        public async Task<Document> Create(Document entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await entities.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Document> Delete(Document entity)
        {
            entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<Document> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

      

        public async Task<Document> Update(Document entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(null, nameof(entity));
            }
            entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Document>> ListByNumber(string numberDocCode)
        {
            return (IEnumerable<Document>)await _context.Document.Where(a => a.NumberDocCode == numberDocCode).ToListAsync();
        }
    }
}
