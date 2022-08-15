namespace CoffeeStore.Domain
{
    internal interface IProductItem
    { 
    
        Guid Id { get; }
        ProductType productType { get; }
        string Name { get; }
        decimal VendorPrice { get; }
        decimal SellingPrice { get; }
    }
}