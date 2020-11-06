using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Treely_2020.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class APISearchController : ControllerBase
    {

        // Enter a valid subscription key.
        const string accessKey = "58d95594c28f497d842d4d29b4db999d";
        /*
         * If you encounter unexpected authorization errors, double-check this value
         * against the endpoint for your Bing Web search instance in your Azure
         * dashboard.
         */
        //const string uriBase = "https://searchapi.cognitiveservices.azure.com/";

        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";

        const string searchTerm = "Microsoft Cognitive Services";

        private readonly ILogger<APISearchController> _logger;

        public APISearchController(ILogger<APISearchController> logger)
        {
            _logger = logger;

        }

        //[HttpGet]
        //[Produces("application/json")]
        //public IActionResult Get()
        //{

        //    var result = "********************** search result passed back **********************";
        //    return Ok(result);
        //}

        [HttpGet]
        [Produces("application/json")]
        public string Get(string query, int count, int offset)
        {

            // https://localhost:44356/apisearch?query=united&mkt=en-gb&count=1&offset=80

          // SearchResult result = BingWebSearch(query); //TODO  + "&mkt=en-gb&count=" + count + "&offset=" + offset);



            var myquery = query + "&count=" + count + "&offset=" + offset + "&mkt=en-gb";

            SearchResult result2 = BingWebSearch(myquery);  //TODO  + " & mkt=en-gb&count=" + count + "&offset=" + offset);

            //return Ok(result);
            return result2.jsonResult;


        }

        // Returns search results with headers.
        public struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }

        /// <summary>
        /// Makes a request to the Bing Web Search API and returns data as a SearchResult.
        /// </summary>
        private SearchResult BingWebSearch(string searchQuery)
        {
            var searchResult = new SearchResult();

            try
            {

                // Construct the search request URI.
                //var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);
                var uriQuery = uriBase + "?q=" + searchQuery  ;

                // Perform request and get a response.
                WebRequest request = HttpWebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();


                searchResult.jsonResult = json;
                searchResult.relevantHeaders = new Dictionary<String, String>();

                // Extract Bing HTTP headers.
                foreach (String header in response.Headers)
                {
                    if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                        searchResult.relevantHeaders[header] = response.Headers[header];
                }
            }
            catch (Exception ex)
            {
                var exceptionMsg = ex.Message;
                //log it!
            }

            return searchResult;
        }

        /// <summary>
        /// Formats the JSON string by adding line breaks and indents.
        /// </summary>
        /// <param name="json">The raw JSON string.</param>
        /// <returns>The formatted JSON string.</returns>
        private string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            char last = ' ';
            int offset = 0;
            int indentLength = 2;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\\':
                        if (quote && last != '\\') ignore = true;
                        break;
                }

                if (quote)
                {
                    sb.Append(ch);
                    if (last == '\\' && ignore) ignore = false;
                }
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case ']':
                        case '}':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (quote || ch != ' ') sb.Append(ch);
                            break;
                    }
                }
                last = ch;
            }
            return sb.ToString().Trim();
        }
    }
}
