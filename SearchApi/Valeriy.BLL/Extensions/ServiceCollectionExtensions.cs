using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Valeriy.BLL.Services;
using Valeriy.DAL;
using Valeriy.Domain.Contracts.Services;

namespace Valeriy.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection collection,Action<DbContextOptionsBuilder> builder)
        {
            return collection.AddDbContext<ValeriyDbContext>(builder);
        }

        public static IServiceCollection AddServices(this IServiceCollection collection)
        {
            collection.TryAddTransient<IProductsService, ProductsService>();
            return collection;
        }
    }
}