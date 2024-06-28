using QuanLyTaiLieu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Repository
{
    public interface IRepositoryDocument<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListByNumber(string numberDocCode);
    }

}
