using QuanLyTaiLieu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiLieu.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetById(string id);
        Task Create(Account entity);
        Task<bool> Update(Account entity);
        Task<bool> Delete(string id);

        Task<IEnumerable<Account>> ListByRole(string roleId);

    }
}
