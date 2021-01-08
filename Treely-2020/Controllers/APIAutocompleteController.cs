using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using System.Net.Http;
using System.Net.Http.Headers;


namespace Treely_2020.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class APIAutocompleteController : ControllerBase
    {
        static string host = "https://api.cognitive.microsoft.com";
        static string path = "/bing/v7.0/Suggestions";
        static string market = "en-US";
        static string key = "a7ee36643e85472bbf6b01a12cea2605";
       

        private string BingAutoSuggest(string query)
        {


            try
            {
                // Construct the search request URI.
                string uriQuery = host + path + "?mkt=" + market + "&query=" + System.Net.WebUtility.UrlEncode(query);

                // Perform request and get a response.
                WebRequest request = HttpWebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = key;

                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return json;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public string Get(string query)
        {

            var result = BingAutoSuggest(query);


            //return Ok(result);
            //return result.jsonResult;
            return result;

        }

        // Returns search results with headers.
        public struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }

    }
}