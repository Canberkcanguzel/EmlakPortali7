using Microsoft.AspNetCore.Mvc;
using EmlakPortali7.Models;

namespace EmlakPortali7.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult LoginAjax([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (model.Username == "canberk" && model.Password == "1234")
                {
                    return Json(new { success = true, redirectUrl = "/Home/Index" });
                }

                return Json(new { success = false, message = "Kullanıcı adı veya şifre hatalı." });
            }

            return Json(new { success = false, message = "Geçersiz giriş bilgileri." });
        }
    }
}
