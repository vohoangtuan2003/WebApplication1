using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Constants;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ManageUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Hành động Index để hiển thị danh sách người dùng
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // Các hành động khác như Create, Edit, Delete, ...

        // Ví dụ hành động Delete
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    // Xử lý khi xóa thành công
                    return RedirectToAction(nameof(Index));
                }
                // Xử lý khi có lỗi xóa
                ModelState.AddModelError("", "Delete failed. " + string.Join(" ", result.Errors.Select(e => e.Description)));
            }
            // Xử lý khi người dùng không tồn tại
            return NotFound();
        }
    }
}
