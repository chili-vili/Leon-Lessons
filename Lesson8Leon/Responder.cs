namespace Lesson8Leon
{
    class Responder
    {
        private readonly AddressBuilder _addressBuilder;
        public Address Bake()
        {
            _addressBuilder.DeliveryAddress();
            _addressBuilder.SetCountry();
            _addressBuilder.SetCity();
            _addressBuilder.SetPostalCode();
            _addressBuilder.SetStreet();
            _addressBuilder.SetHouse();
            _addressBuilder.SetApartmentNumber();
            return _addressBuilder.Address;
        }

        public Responder(AddressBuilder AddressBuilder)
        {
            _addressBuilder=AddressBuilder;
        }
    }
}
