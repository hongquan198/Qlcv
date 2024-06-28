
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
    public class NumberDocService : INumberDocService

    {
        private readonly IRepositoryNumberDoc<NumberDoc> _repository;

        public NumberDocService(IRepositoryNumberDoc<NumberDoc> repository)
        {
            _repository = repository;
        }

        public async Task Create(NumberDoc numberDoc)
        {
            await _repository.Create(numberDoc);
        }

        public async Task<bool> Delete(string id)
        {
            var numberDoc = await _repository.GetById(id);

            if (numberDoc != null)
            {
                await _repository.Delete(numberDoc);
            }

            return true;
        }

        public async Task<NumberDoc> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<NumberDoc>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> Update(NumberDoc numberDoc)
        {
            await _repository.Update(numberDoc);

            return true;
        }

    }
}

