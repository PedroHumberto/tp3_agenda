using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web;
using TP3.Application.ViewModels;

namespace TP3.FriendsWeb.Controllers
{
    public class FriendsController : Controller
    {
        HttpClient _client;


        public FriendsController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("FriendsAPI");
        }

        #region private_methods

        private void SetSession(List<Guid> Selected)
        {
            HttpContext.Session.SetString("Selected", JsonConvert.SerializeObject(Selected));
        }
        private List<Guid> GetSession()
        {
            var selectedList = HttpContext.Session.GetString("Selected");
            if (!string.IsNullOrEmpty(selectedList))
            {
                return JsonConvert.DeserializeObject<List<Guid>>(HttpContext.Session.GetString("Selected"));
            }
            return new List<Guid>();
        }
        #endregion


        public async Task<IActionResult> Index()
        {
            string URL_PATH = "addfriend";

            using HttpResponseMessage response = await _client.GetAsync(URL_PATH);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            List<FriendViewModel> friendsList = JsonConvert.DeserializeObject<List<FriendViewModel>>(jsonResponse);

            return View(friendsList.OrderBy(f => f.FirstName).ToList());

        }

      

    }
}
