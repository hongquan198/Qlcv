
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
    public class DocumentService : IDocumentService

    {
        private readonly IRepositoryDocument<Document> _repository;

        public DocumentService(IRepositoryDocument<Document> repository)
        {
            _repository = repository;
        }

        public async Task Create(Document document)
        {
            await _repository.Create(document);
        }

        public async Task<bool> Delete(int id)
        {
            var document = await _repository.GetById(id);

            if (document != null)
            {
                await _repository.Delete(document);
            }

            return true;
        }

        public async Task<Document> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> Update(Document document)
        {
            await _repository.Update(document);

            return true;
        }

        public async Task<IEnumerable<Document>> ListByNumber(string numberDocCode)
        {
            return await _repository.ListByNumber(numberDocCode);
        }
    }
}

