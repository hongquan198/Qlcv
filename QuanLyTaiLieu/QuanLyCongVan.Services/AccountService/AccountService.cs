
using CuaHangBanLe.Services;
using Microsoft.EntityFrameworkCore;
using QuanLyTaiLieu.Domain.Models;
using QuanLyTaiLieu.Repository;
using QuanLyTaiLieu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanLe.Services
{
    public class AccountService : IAccountService

    {
        private readonly IRepositoryAccount<Account> _repository;

        public AccountService(IRepositoryAccount<Account> repository)
        {
            _repository = repository;
        }

        public async Task Create(Account account)
        {
            await _repository.Create(account);
        }

        public async Task<bool> Delete(string id)
        {
            var account = await _repository.GetById(id);
            if (account != null)
            {
                await _repository.Delete(account);
            }

            return true;
        }

        public async Task<Account> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> Update(Account account)
        {
            await _repository.Update(account);

            return true;
        }

        public async Task<IEnumerable<Account>> ListByRole(string roleId)
        {
            return await _repository.ListByRole(roleId);
        }

    
    }
}

