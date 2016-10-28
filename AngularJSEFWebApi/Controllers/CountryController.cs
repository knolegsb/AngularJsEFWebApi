using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AngularJSEFWebApi.Controllers
{
    public class CountryController : ApiController
    {
        // GET api/country
        public IEnumerable<SelectListItem> Get()
        {
            List<SelectListItem> countries = new List<SelectListItem>()
            {
                new SelectListItem { Text = "United States", Value = "US" },
                new SelectListItem { Text = "United Kingdom", Value = "UK" },
                new SelectListItem { Text = "South Korea", Value = "KO" },
                new SelectListItem { Text =  "China", Value = "CN" }
            };
            return countries; 
        }

        // GET api/country/5
        public IEnumerable<SelectListItem> Get(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "US":
                    states.Add(new SelectListItem
                    {
                        Text = "California",
                        Value = "CA"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Washington",
                        Value = "WA"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Oregon",
                        Value = "OR"
                    });
                    break;
                case "UK":
                    states.Add(new SelectListItem
                    {
                        Text = "Yorkshire",
                        Value = "YK"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Crenshire",
                        Value = "CR"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "OregonShire",
                        Value = "OS"
                    });
                    break;
                case "KO":
                    states.Add(new SelectListItem
                    {
                        Text = "Kyungkido",
                        Value = "KK"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Jonrado",
                        Value = "JR"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Kyungsangdo",
                        Value = "KS"
                    });
                    break;
                case "CN":
                    states.Add(new SelectListItem
                    {
                        Text = "California",
                        Value = "CA"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Washington",
                        Value = "WA"
                    });
                    states.Add(new SelectListItem
                    {
                        Text = "Oregon",
                        Value = "OR"
                    });
                    break;
            }
            return states;
        }
    }
}
