using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Valeriy.Domain.Contracts.Services;

namespace Valeriy.Web.Controllers
{
    public class Products : Controller
    {
        private readonly IProductsService _productsService;

        public Products(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> Search(SearchProductsModel model)
        {
            var products = await _productsService.Search(model);
            return Ok(products);
        }
    }
}