using CuaHangBanLe.Services;
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
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListDocument()
        {
            return Ok(await _documentService.GetAll());
        }

        [HttpGet]
        [Route("ListPagination")]
        public async Task<IActionResult> ListPagination(int? page, int pageSize = 10)
        {
            var accounts = await _documentService.GetAll(); // Lấy tất cả các account từ service

            // Phân trang dữ liệu
            var pageNumber = page ?? 1; // Nếu page không có giá trị thì mặc định là trang đầu tiên (page = 1)
            var pagedAccounts = accounts.ToPagedList(pageNumber, pageSize);

            return Ok(pagedAccounts); // Trả về danh sách account đã phân trang dưới dạng JSON
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var document = await _documentService.GetById(id);
            return Ok(document);
        }

        [HttpPost]
        [Route("Store")]
        public async Task<IActionResult> StoreDocument(Document document)
        {
            await _documentService.Create(document);
            return Ok(document);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateDocument(int id, Document document)
        {
            var documentUpdate = await _documentService.GetById(id);
            if (documentUpdate == null)
            {
                return NotFound();
            }
            documentUpdate.Signer = document.Signer;
            documentUpdate.ApprovedBy = document.ApprovedBy;
            documentUpdate.NumberPage = document.NumberPage;
            documentUpdate.NumberSymbols = document.NumberSymbols;
            documentUpdate.DateTime = document.DateTime;
            documentUpdate.Abstract = document.Abstract;
            documentUpdate.Content = document.Content;
            documentUpdate.Receive = document.Receive;
            documentUpdate.NumberFrom = document.NumberFrom;
            documentUpdate.DateFrom = document.DateFrom;
            documentUpdate.Sender = document.Sender;
            documentUpdate.NumberGo = document.NumberGo;
            documentUpdate.Quantity = document.Quantity;
            documentUpdate.PlaceDocId = document.PlaceDocId;
            documentUpdate.TypeDocId = document.TypeDocId;



            await _documentService.Update(documentUpdate);
            return Ok(documentUpdate);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _documentService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("ListByNumber")]
        public async Task<IActionResult> ListByNumber(string numberDocCode)
        {
            return Ok(await _documentService.ListByNumber(numberDocCode));
        }

    }
}
