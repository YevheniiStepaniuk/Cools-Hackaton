using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Valeriy.Domain.Contracts.Services
{
    public class SearchProductsModel
    {
        public string Name { get; set; }
        [DefaultValue(1)]
        public int Page { get; set; }

        [FromQuery(Name = "colorEnd")]
        public string Color { get; set; }
        [FromQuery(Name = "clothesEnd")]
        public string Category { get; set; }
        [FromQuery(Name = "unit-currency")]
        public double? Price { get; set; }
        [FromQuery(Name = "sizeEnd")]
        public string Size { get; set; }
        [FromQuery(Name = "genderEnd")]

        public string Gender { get; set; }
    }
}