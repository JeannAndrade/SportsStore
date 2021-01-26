using System;
using System.Linq;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public EFStoreRepository(StoreDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Product> Products => context.Products;

        public void CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }
    }
}