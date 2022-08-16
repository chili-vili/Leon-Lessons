
namespace Lesson3Leon
{
    internal class Wear : StoreItem
    {
        public override string Name => throw new NotImplementedException();

        public override string Description => throw new NotImplementedException();

        public override decimal Price => throw new NotImplementedException();
        public string? Seasonality { get; }
        WearType wearType { get; }

    }
}
