using QuanLyTaiLieu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Repository
{
    public interface IRepositoryTypeDoc<T> : IRepository<T> where T : class
    {
    }

}
