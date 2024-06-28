using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Services
{
    public interface ITypeDocService
    {
        Task<IEnumerable<TypeDoc>> GetAll();
        Task<TypeDoc> GetById(int id);
        Task Create(TypeDoc entity);
        Task<bool> Update(TypeDoc entity);
        Task<bool> Delete(int id);
    }
}
