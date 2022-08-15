
namespace CoffeeStore.Domain
{
    public abstract record ProductItem : IProductItem
    {
        public Guid Id {get;}

        public ProductType productType {get;}

        public string Name {get;} = string.Empty;

        public decimal VendorPrice {get;}

        public decimal SellingPrice {get;}
    }
}
