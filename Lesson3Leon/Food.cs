
namespace Lesson3Leon
{
    internal class Food : StoreItem
    {
        public override string Name => throw new NotImplementedException();

        public override string Description => throw new NotImplementedException();

        public override decimal Price => throw new NotImplementedException();

        public DateTime ExpirationDate { get; }
        FoodType foodType { get; }
    }
}
