namespace Lesson8Leon
{
    abstract class AddressBuilder
    {
        public Address? Address { get; private set; }
        public void DeliveryAddress()
        {
            Address = new Address();
        }
        public abstract void SetCountry();
        public abstract void SetCity();
        public abstract void SetPostalCode();
        public abstract void SetStreet();
        public abstract void SetHouse();
        public abstract void SetApartmentNumber();
    }
}
