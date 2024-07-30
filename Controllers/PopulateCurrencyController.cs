
using CurrencyAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PopulateCurrencyController : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> GetCurrency()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.freecurrencyapi.com/");
            var response = await client.GetAsync("v1/latest?apikey=fca_live_vXIpI2R0RPJDMs1LqyX9oLmcBpVdvrgYYCh4Xqza");
            if (response.IsSuccessStatusCode)
            {
                //var result = await response.Content.ReadFromJsonAsync<ResponseCurrency>();
               // var result1 = await response.Content.ReadFromJsonAsync(string,"");
                //var ResponseCurr = JsonSerializer.Deserialize<List<ResponseCurrency>>(jsonString);
                //ResponseCurrency = ResponseCurr.First();
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            return BadRequest();
        }



        
    }
}
