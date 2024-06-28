
using CuaHangBanLe.Repository;
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
    public class TypeDocService : ITypeDocService

    {
        private readonly IRepositoryTypeDoc<TypeDoc> _repository;

        public TypeDocService(IRepositoryTypeDoc<TypeDoc> repository)
        {
            _repository = repository;
        }

        public async Task Create(TypeDoc typeDoc)
        {
            await _repository.Create(typeDoc);
        }

        public async Task<bool> Delete(int id)
        {
            var typeDoc = await _repository.GetById(id);

            if (typeDoc != null)
            {
                await _repository.Delete(typeDoc);
            }

            return true;
        }

        public async Task<TypeDoc> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<TypeDoc>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> Update(TypeDoc typeDoc)
        {
            await _repository.Update(typeDoc);

            return true;
        }
    }
}

