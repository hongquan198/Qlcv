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
    public class PlaceDocController : ControllerBase
    {
        private readonly IPlaceDocService _placeDocService;
        public PlaceDocController(IPlaceDocService placeDocService)
        {
            this._placeDocService = placeDocService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListPlaceDoc()
        {
            return Ok(await _placeDocService.GetAll());
        }

        [HttpGet]
        [Route("ListPagination")]
        public async Task<IActionResult> ListPagination(int? page, int pageSize = 10)
        {
            var accounts = await _placeDocService.GetAll(); // Lấy tất cả các account từ service

            // Phân trang dữ liệu
            var pageNumber = page ?? 1; // Nếu page không có giá trị thì mặc định là trang đầu tiên (page = 1)
            var pagedAccounts = accounts.ToPagedList(pageNumber, pageSize);

            return Ok(pagedAccounts); // Trả về danh sách account đã phân trang dưới dạng JSON
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetPlaceDocById(int id)
        {
            var placeDoc = await _placeDocService.GetById(id);
            return Ok(placeDoc);
        }

        [HttpPost]
        [Route("Store")]
        public async Task<IActionResult> StorePlaceDoc(PlaceDoc placeDoc)
        {
            await _placeDocService.Create(placeDoc);
            return Ok(placeDoc);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdatePlaceDoc(int id, PlaceDoc placeDoc)
        {
            var placeDocUpdate = await _placeDocService.GetById(id);
            if (placeDocUpdate == null)
            {
                return NotFound();
            }
            placeDocUpdate.PlaceDocName = placeDoc.PlaceDocName;
            placeDocUpdate.Description = placeDoc.Description;

            await _placeDocService.Update(placeDocUpdate);
            return Ok(placeDocUpdate);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _placeDocService.Delete(id);
            return Ok();
        }

    }
}
