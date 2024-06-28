
using CuaHangBanLe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTaiLieu.Domain.Models;
using QuanLyTaiLieu.Services;
using System.Security.Principal;
using System.Threading.Tasks;
using X.PagedList;

namespace CuaHangBanLe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberDocController : ControllerBase
    {
        private readonly INumberDocService _numberDocService;
        public NumberDocController(INumberDocService numberDocService)
        {
            this._numberDocService = numberDocService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListNumberDoc()
        {
            return Ok(await _numberDocService.GetAll());
        }


        [HttpGet]
        [Route("ListPagination")]
        public async Task<IActionResult> ListPagination(int? page, int pageSize = 10)
        {
            var numberDocs = await _numberDocService.GetAll(); // Lấy tất cả các numberDoc từ service

            // Phân trang dữ liệu
            var pageNumber = page ?? 1; // Nếu page không có giá trị thì mặc định là trang đầu tiên (page = 1)
            var pagedNumberDocs = numberDocs.ToPagedList(pageNumber, pageSize);

            return Ok(pagedNumberDocs); // Trả về danh sách numberDoc đã phân trang dưới dạng JSON
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetNumberDocById(string id)
        {
            var numberDoc = await _numberDocService.GetById(id);
            return Ok(numberDoc);
        }

        [HttpPost]
        [Route("Store")]
        public async Task<IActionResult> StoreNumberDoc(NumberDoc numberDoc)
        {
            await _numberDocService.Create(numberDoc);
            return Ok(numberDoc);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateNumberDoc(string id, NumberDoc numberDoc)
        {
            var updateNumberDoc = await _numberDocService.GetById(id);
            if (updateNumberDoc == null)
            {
                return NotFound();
            }

            updateNumberDoc.NumberDocName = numberDoc.NumberDocName;
            updateNumberDoc.Description = numberDoc.Description;


            await _numberDocService.Update(updateNumberDoc);
            return Ok(updateNumberDoc);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _numberDocService.Delete(id);
            return Ok();
        }


      
    }
}
