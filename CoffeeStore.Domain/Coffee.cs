
namespace CoffeeStore.Domain
{
    public sealed record Coffee:ProductItem
    {
        private short _strenght;
        public CoffeeType Type { get; }
        public string Origin { get; }
        public string Description { get; }
        public short Strenght
        {
            get => _strenght;

            set
            {
                if (value <= 0) _strenght = 1;
                else if(value > 10) _strenght = 10;
                else _strenght = value;
            }
        }
        public DateTime ExpirationDate { get; }
    }
}
