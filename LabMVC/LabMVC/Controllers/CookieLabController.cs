using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class CookieLabController : Controller
    {
        public async Task< IActionResult> SetCookie()
        {
            Response.Cookies.Append( "theme"  ,"dark" , new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7),
                Secure = true,
                SameSite = SameSiteMode.Lax
            });

            return Ok("Cookie設定完成");
        }

        public async Task<IActionResult> GetCookie()
        {
             string theme =   Request.Cookies["theme"];

            return Ok(theme);
        }



    }
}
