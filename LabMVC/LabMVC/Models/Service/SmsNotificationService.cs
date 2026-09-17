using LabMVC.Models.Service.IService;

namespace LabMVC.Models.Service
{
    public class SmsNotificationService : INotification
    {
        public string SendMessage(string To, string Message)
        {
            return $"用SMS簡訊寄 {Message} 給 {To}";
        }
    }
}
