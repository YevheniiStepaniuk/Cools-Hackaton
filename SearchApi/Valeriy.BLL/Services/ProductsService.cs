using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Valeriy.DAL;
using Valeriy.Domain.Contracts.Services;
using Valeriy.Domain.Dtos;
using Valeriy.Domain.Entities;
using Valeriy.Domain.Extensions;
using Valeriy.Domain.Utils;

namespace Valeriy.BLL.Services
{
    public class ProductsService: IProductsService
    {
        private readonly ValeriyDbContext _context;
        private const int COUNT_ON_PAGE = 5;
        private const int PRICE_INTERVAL = 10;
        public ProductsService(ValeriyDbContext context)
        {
            _context = context;
        }

        public async Task<PagedCollection<ProductDto>> Search(SearchProductsModel model)
        {
            var productsQuery = _context.Products.AsQueryable();
            var page = model.Page == 0 ? 1 : model.Page;
            if (!model.Name.IsNullOrWhiteSpace())
            {
                productsQuery = productsQuery.Where(x => x.ProductName.Contains(model.Name));
            }
            if (!model.Category.IsNullOrWhiteSpace())
            {
                productsQuery = productsQuery.Where(x => x.CoolsSecondaryCategory.Contains(model.Category));
            }
            if (!model.Color.IsNullOrWhiteSpace())
            {
                productsQuery = productsQuery.Where(x => x.CoolsColors.Contains(model.Color));
            }
            if (!model.Gender.IsNullOrWhiteSpace())
            {
                productsQuery = productsQuery.Where(x => x.Gender.ToLower().Contains(model.Gender) || x.Gender == "n/a");
            }
            if (!model.Size.IsNullOrWhiteSpace())
            {
                productsQuery = productsQuery.Where(x => x.CoolsSizes.Contains(model.Size) || x.CoolsColors == "[]");
            }
            if (model.Price.HasValue)
            {
                productsQuery = productsQuery
                    .Where(x => x.RetailPrice > model.Price - PRICE_INTERVAL && x.RetailPrice < model.Price + PRICE_INTERVAL);
            }

            var products = await productsQuery.Take(COUNT_ON_PAGE)
                .Select(x => new ProductDto()
                {
                    Name = x.ProductName,
                    Price = x.RetailPrice,
                    Brand = x.Brand,
                    ImageUrl = x.ProductImageUrl,
                    ProductUrl   = x.ProductUrl,
                    Colors = x.CoolsColors,
                    Category = x.CoolsSecondaryCategory,
                    Size = x.CoolsSizes,
                    Gender = x.Gender,
                    Description = x.LongProductDescription
                })
                .ToListAsync();
            return products.ToPagedCollection(page:model.Page,count: COUNT_ON_PAGE);
        }
    }
}