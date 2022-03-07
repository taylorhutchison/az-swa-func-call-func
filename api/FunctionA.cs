using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace TaylorHutchison.Function
{
    public static class FunctionA
    {
        [FunctionName("FunctionA")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var random = new Random();
            var number = random.Next(1, 100);
            using var client = new HttpClient();
            var content = JsonSerializer.Serialize(new RandomNumberPayload { Number = number });
            var response = await client.PostAsync("https://orange-wave-0f9ac760f.1.azurestaticapps.net/api/FunctionB", new StringContent(content));
            var result = await response.Content.ReadAsStringAsync();

            return new OkObjectResult(result);
        }
    }
}
