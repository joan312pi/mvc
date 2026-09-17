using LabMVC.Models.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class NotificationController : Controller
    {
        private INotification _notification;
        public NotificationController(INotification notification)
        { 
            _notification = notification;        
        }


        public async Task< IActionResult> Index()
        {
            string result =  _notification.SendMessage("abc@abc.com.tw", 
                "這是正在執行DI套用的類別");
            return Json(result);
        }
    }
}
