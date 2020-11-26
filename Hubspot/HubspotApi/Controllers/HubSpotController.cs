using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HubSpot.Company;
using HubSpot.NET.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HubspotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HubSpotController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HubSpotController> _logger;

        public HubSpotController(ILogger<HubSpotController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public void GetCompanies(string id)
        {
            
            string url = "https://api.hubapi.com/companies/v2/companies/" + id + "?hapikey=02b331ee-e5a8-44ac-b9db-c26007ea916e";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Response.WriteAsync("Response: " + result);
            }

        }

        [HttpGet("[action]")]
        public void GetContacts(string id)
        {

            string url = "https://api.hubapi.com/contacts/v1/contact/vid/"+ id +"/profile?" + "hapikey=02b331ee-e5a8-44ac-b9db-c26007ea916e";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Response.WriteAsync("Response: " + result);
            }

        }
    }
}
