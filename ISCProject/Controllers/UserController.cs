using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ISCProject.Controllers
{
    public class UserController : ModifiedController
    {
        [Route("user/personalPage")]
        public async Task<IActionResult> IndexAsync(int? DesAccountId)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(BaseAPI + "/User?AccountId=" + DesAccountId);
            string apiResponse = await response.Content.ReadAsStringAsync();

            return View("Views/Home/UserPage.cshtml");
        }

        [Route("user/edit-info")]
        public IActionResult Edit()
        {
            return View("Views/Home/EditInformation.cshtml");
        }
    }
}
