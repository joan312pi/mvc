using LabMVC.Models.Service.IService;

namespace LabMVC.Models.Service
{
    public class EmailNotificationService : INotification
    {
        public string SendMessage(string To, string Message)
        {
            return $"用email寄 {Message} 給 {To}";
        }
    }
}
