using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTaiLieu.Domain.Models;
using QuanLyTaiLieu.Services;
using System.Threading.Tasks;
using X.PagedList;

namespace QuanLyTaiLieu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocController : ControllerBase
    {
        private readonly ITypeDocService _typeDocService;
        public TypeDocController(ITypeDocService typeDocService)
        {
            this._typeDocService = typeDocService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListTypeDoc()
        {
            return Ok(await _typeDocService.GetAll());
        }

        [HttpGet]
        [Route("ListPagination")]
        public async Task<IActionResult> ListPagination(int? page, int pageSize = 10)
        {
            var accounts = await _typeDocService.GetAll(); // Lấy tất cả các account từ service

            // Phân trang dữ liệu
            var pageNumber = page ?? 1; // Nếu page không có giá trị thì mặc định là trang đầu tiên (page = 1)
            var pagedAccounts = accounts.ToPagedList(pageNumber, pageSize);

            return Ok(pagedAccounts); // Trả về danh sách account đã phân trang dưới dạng JSON
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetTypeDocById(int id)
        {
            var typeDoc = await _typeDocService.GetById(id);
            return Ok(typeDoc);
        }

        [HttpPost]
        [Route("Store")]
        public async Task<IActionResult> StoreTypeDoc(TypeDoc typeDoc)
        {
            await _typeDocService.Create(typeDoc);
            return Ok(typeDoc);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateTypeDoc(int id, TypeDoc typeDoc)
        {
            var typeDocUpdate = await _typeDocService.GetById(id);
            if (typeDocUpdate == null)
            {
                return NotFound();
            }
            typeDocUpdate.TypeDocName = typeDoc.TypeDocName;
            typeDocUpdate.Description = typeDoc.Description;

            await _typeDocService.Update(typeDocUpdate);
            return Ok(typeDocUpdate);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _typeDocService.Delete(id);
            return Ok();
        }

    }
}
