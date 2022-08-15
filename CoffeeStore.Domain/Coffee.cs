
namespace CoffeeStore.Domain
{
    internal sealed record Coffee:ProductItem
    {
        public CoffeeType Type { get; }
    }
}
