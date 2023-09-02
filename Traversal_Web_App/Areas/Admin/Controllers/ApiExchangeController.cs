using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Web_App.Areas.Admin.Models;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ApiExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<BookingExchangeViewModel2> bookingExchangeViewModels = new List<BookingExchangeViewModel2>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/currency/get-exchange-rates?base_currency=TRY&languagecode=en-us"),
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

				var values = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
				return View(values.exchange_rates);
			}
			return View();
		}
	}
}
