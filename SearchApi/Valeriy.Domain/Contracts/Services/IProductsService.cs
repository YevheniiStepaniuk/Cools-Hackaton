using System.Collections.Generic;
using System.Threading.Tasks;
using Valeriy.Domain.Dtos;
using Valeriy.Domain.Utils;

namespace Valeriy.Domain.Contracts.Services
{
    public interface IProductsService
    {
        Task<PagedCollection<ProductDto>> Search(SearchProductsModel model);
    }
}