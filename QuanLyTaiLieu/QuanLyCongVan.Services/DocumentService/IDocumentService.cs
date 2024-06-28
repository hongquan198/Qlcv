using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetAll();
        Task<Document> GetById(int id);
        Task Create(Document entity);
        Task<bool> Update(Document entity);
        Task<bool> Delete(int id);

        Task<IEnumerable<Document>> ListByNumber(string numberDocCode);
    }
}
