
namespace CoffeeStore.Domain
{
    public sealed record CoffeeMachine:ProductItem
    {
        public string SerialNumber { get; }
        public int GuaranteePeriod { get; }
        public CoffeeMachineType Type { get; }
        public bool Coffeegrinder { get; }
        public bool WorkWithMilk { get; }
    }
}
