
using CuaHangBanLe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTaiLieu.Domain.Models;
using QuanLyTaiLieu.Services;
using System.Threading.Tasks;
using X.PagedList;

namespace CuaHangBanLe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListAccount()
        {
            return Ok(await _accountService.GetAll());
        }


        [HttpGet]
        [Route("ListPagination")]
        public async Task<IActionResult> ListPagination(int? page, int pageSize = 10)
        {
            var accounts = await _accountService.GetAll(); // Lấy tất cả các account từ service

            // Phân trang dữ liệu
            var pageNumber = page ?? 1; // Nếu page không có giá trị thì mặc định là trang đầu tiên (page = 1)
            var pagedAccounts = accounts.ToPagedList(pageNumber, pageSize);

            return Ok(pagedAccounts); // Trả về danh sách account đã phân trang dưới dạng JSON
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetAccountById(string id)
        {
            var account = await _accountService.GetById(id);
            return Ok(account);
        }

        [HttpPost]
        [Route("Store")]
        public async Task<IActionResult> StoreAccount(Account account)
        {
            await _accountService.Create(account);
            return Ok(account);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAccount(string id, Account account)
        {
            var updateAccount = await _accountService.GetById(id);
            if (updateAccount == null)
            {
                return NotFound();
            }


            updateAccount.FullName = account.FullName;
            updateAccount.Email = account.Email;
            updateAccount.Phone = account.Phone;
            updateAccount.Password = account.Password;


            await _accountService.Update(updateAccount);
            return Ok(updateAccount);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _accountService.Delete(id);
            return Ok();
        }


        [HttpGet]
        [Route("ListByRole")]
        public async Task<IActionResult> ListByRole(string roleId)
        {
            return Ok(await _accountService.ListByRole(roleId));
        }

    }
}
