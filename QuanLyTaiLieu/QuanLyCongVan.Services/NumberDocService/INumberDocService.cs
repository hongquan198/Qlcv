using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Services
{
    public interface INumberDocService
    {
        Task<IEnumerable<NumberDoc>> GetAll();
        Task<NumberDoc> GetById(string id);
        Task Create(NumberDoc entity);
        Task<bool> Update(NumberDoc entity);
        Task<bool> Delete(string id);
    }
}
