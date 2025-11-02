using Microsoft.AspNetCore.Mvc;
using WebApiPD421.BLL.Services;

namespace WebApiPD421.Extentions
{
    public static class ControllersBaseExtentions
    {
        public static IActionResult ToActionResult(this ControllerBase controller, ServiceResponse response)
        {
            return controller.StatusCode((int)response.HttpStatusCode, response);
        }
    }

}
