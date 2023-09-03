using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Web_App.Areas.Admin.Models;
using System.Net.Http.Headers;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BookingHotelSearchController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/properties/list?offset=0&arrival_date=2023-09-03&departure_date=2023-09-04&guest_qty=1&dest_ids=-3712125&room_qty=1&search_type=city&children_qty=2&children_age=5%2C7&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=tr&travel_purpose=leisure"),
				Headers =
				{
					{ "X-RapidAPI-Key", "55b0ca13f1msh16e7987099d2522p1800bfjsnb141b2e7d073" },
					{ "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
				return View(values.result);
			}
			return View();
		}

		[HttpGet]
        public IActionResult GetCityDestID()
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> GetCityDestID(string p)
		{
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://apidojo-booking-v1.p.rapidapi.com/locations/auto-complete?text={p}&languagecode=en-us"),
                Headers =
			{
				{ "X-RapidAPI-Key", "55b0ca13f1msh16e7987099d2522p1800bfjsnb141b2e7d073" },
				{ "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
			},
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
			return View();
        }
	}
}
