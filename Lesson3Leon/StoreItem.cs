namespace Lesson3Leon
{
    public abstract class StoreItem
    {
        public abstract string Name { get; }
        ProductType ProductType { get; }
        public abstract string Description { get; }
        public abstract decimal Price { get; }

    }
}