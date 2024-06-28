using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Services
{
    public interface IPlaceDocService
    {
        Task<IEnumerable<PlaceDoc>> GetAll();
        Task<PlaceDoc> GetById(int id);
        Task Create(PlaceDoc entity);
        Task<bool> Update(PlaceDoc entity);
        Task<bool> Delete(int id);
    }
}
