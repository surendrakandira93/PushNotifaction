using Microsoft.AspNetCore.Mvc;
using PushNotifaction.Models;
using PushNotifaction.Service;
using System.Diagnostics;

namespace PushNotifaction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPushNotificationService _pushNotificationService;
        public HomeController(ILogger<HomeController> logger, IPushNotificationService pushNotificationService)
        {
            _logger = logger;
            _pushNotificationService = pushNotificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PushNotification()
        {
            var noti = new PushNotificationItemDto()
            {
                Token = "cUbVwVBb3ro:APA91bHrGCSGw0bWhm2bXsts3MxwMRC_cj1b4wG3I-EvI43-l9qMXGaUI5jtmIegxMP4dBS0tco7vbontIFK8QFhRSBbSlY1TvNGIZ9Mxde4oqHm1SYUo1CyixsNNvfa42cWNC6HL8rQ",
                Description = "Test description",
                Text = "Test title",
                click_action = "https://staging.peoplepro.online/Company/ManageStaff"
            };
            await _pushNotificationService.PushNotifications(noti);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}