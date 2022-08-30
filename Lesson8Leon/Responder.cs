
using System.Diagnostics.Metrics;
using System.IO;

namespace Lesson8Leon
{
    class Responder
    {
        private readonly AddressBuilder _addressBuilder;
        public Address Bake(AddressBuilder AddressBuilder)
        {
            AddressBuilder.DeliveryAddress();
            AddressBuilder.SetCountry();
            AddressBuilder.SetCity();
            AddressBuilder.SetPostalCode();
            AddressBuilder.SetStreet();
            AddressBuilder.SetHouse();
            AddressBuilder.SetApartmentNumber();
            return AddressBuilder.Address;
        }

        public Responder(AddressBuilder AddressBuilder)
        {
            _addressBuilder=AddressBuilder;
        }
                
    }
}
