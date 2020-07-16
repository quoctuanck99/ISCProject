using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISCProject.Controllers
{
    [Route("[controller]")]
    public class FavoritePostsController : ModifiedController
    {
        [HttpPost]
        public async Task<IActionResult> FavoriteAsync(int PostId, bool IsAdd)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            HttpClient httpClient = new HttpClient();
            if (IsAdd)
            {
                FavoritePost favorite = new FavoritePost
                {
                    PostId = PostId,
                    AccountId = HttpContext.Session.GetInt32("AccountId").Value
                };

                var json = JsonConvert.SerializeObject(favorite);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                using var response = await httpClient.PostAsync(BaseAPI + "FavoritePosts", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string ApiResponse = await response.Content.ReadAsStringAsync();
                    return Ok(JsonConvert.DeserializeObject<FavoritePost>(ApiResponse));
                }
                else
                    return BadRequest();
            }
            else
            {
                using var response = await httpClient.DeleteAsync(BaseAPI + "FavoritePosts?PostId=" + PostId + "&AccountId=" + HttpContext.Session.GetInt32("AccountId").Value);
                if (response.IsSuccessStatusCode)
                    return Ok();
                else
                    return BadRequest();
            }
        }
    }
}
