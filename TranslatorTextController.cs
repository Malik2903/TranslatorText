using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace ContentMGR.Controllers
{
    public class TranslatorTextController : Controller
    {
        // GET: TranslatorText
        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> Translate(string text)
        {
            string key = "f18454e6276547169a81daac71ab706f";
            string uri = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=it&to=de&to=es&to=zh-Hans&to=ar";
            System.Object[] body = new System.Object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);
                //var result = requestBody;
                return result;
            }
        }
    }
}