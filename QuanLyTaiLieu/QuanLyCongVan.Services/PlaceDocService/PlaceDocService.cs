
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
    public class PlaceDocService : IPlaceDocService

    {
        private readonly IRepositoryPlaceDoc<PlaceDoc> _repository;

        public PlaceDocService(IRepositoryPlaceDoc<PlaceDoc> repository)
        {
            _repository = repository;
        }

        public async Task Create(PlaceDoc placeDoc)
        {
            await _repository.Create(placeDoc);
        }

        public async Task<bool> Delete(int id)
        {
            var placeDoc = await _repository.GetById(id);

            if (placeDoc != null)
            {
                await _repository.Delete(placeDoc);
            }

            return true;
        }

        public async Task<PlaceDoc> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<PlaceDoc>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> Update(PlaceDoc placeDoc)
        {
            await _repository.Update(placeDoc);

            return true;
        }
    }
}

