using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SCA.Gateway.Controllers
{

    public class BaseController : ControllerBase
    {
        protected new async Task<IActionResult> GetListAsync<T>(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var assets = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T[]>(assets);
                return Ok(result);
            }

            return BadRequest("Ocorreu algum erro.");
        }

        protected new async Task<IActionResult> GetAsync<T>(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var asset = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(asset);
                return Ok(result);
            }

            return BadRequest("Ocorreu algum erro.");
        }

        protected new async Task<IActionResult> PostAsync<T>(string url, T value)
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest("Ocorreu algum erro.");
        }

        protected new async Task<IActionResult> PutAsync<T>(string url, T value)
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest("Ocorreu algum erro.");
        }

        protected new async Task<IActionResult> DeleteAsync(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest("Ocorreu algum erro.");
        }

    }
}
