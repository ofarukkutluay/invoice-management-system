using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class BaseController : Controller
    {
        public void SuccessAlert(string message)
        {
            TempData["alertType"] = "success";
            TempData["alertMessage"] = message;
        }

        public void DangerAlert(string message)
        {
            TempData["alertType"] = "danger";
            TempData["alertMessage"] = message;
        }

    }
}
