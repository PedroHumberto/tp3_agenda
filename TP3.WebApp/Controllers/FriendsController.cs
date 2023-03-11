using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TP3.Application.ViewModels;

namespace TP3.WebApp.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly HttpClient _client;

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
             string URL_PATH = "allfriends";

             using HttpResponseMessage response = await _client.GetAsync(URL_PATH);
             response.EnsureSuccessStatusCode();

             var jsonResponse = await response.Content.ReadAsStringAsync();

             List<FriendViewModel> friendsList = JsonConvert.DeserializeObject<List<FriendViewModel>>(jsonResponse);


             return View(friendsList.OrderBy(f => f.FirstName).ToList());

        }

        //POST METHOD
        public IActionResult FriendForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FriendForm(FriendViewModel model)
        {
            if (ModelState.IsValid) 
            {
                string URL_PATH = "addfriend";
                try
                {
                    var response = await _client.PostAsJsonAsync<FriendViewModel>(URL_PATH, model);

                    if (!response.IsSuccessStatusCode) return BadRequest();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.Write("ERRO " + ex.ToString());

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        //END OF POST METHOD

        //UPDATE METHOD
        public async Task<IActionResult> UpdateFriend(Guid id)
        {
            var URL_PATH = $"updatefriend/{id}";
            if (ModelState.IsValid)
            {
                var response = await _client.GetAsync(URL_PATH);
                
                var jsonResponse = await response.Content.ReadAsStringAsync();

                FriendViewModel friend = JsonConvert.DeserializeObject<FriendViewModel>(jsonResponse);

                return View(friend);
            }
            return View(id);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFriend(FriendViewModel updateFriend, Guid id)
        {
            var URL_PATH = $"updatefriend/{id}";
            if (ModelState.IsValid)
            {
                try
                {
                    var postResponse = await _client.PatchAsJsonAsync<FriendViewModel>(URL_PATH, updateFriend);

                    if (!postResponse.IsSuccessStatusCode) return BadRequest();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.Write("ERRO " + ex.ToString());

                    return BadRequest(ex.ToString());
                }
                
            }
            return View(updateFriend);
        }



    }
}
