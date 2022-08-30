
namespace Lesson8Leon
{
    class DeliveryAddressBuilder : AddressBuilder
    {

        public DeliveryAddressBuilder() : base()
        {

        }
        public override void SetApartmentNumber()
        {
            Console.WriteLine("Введите номер квартиры: ");
            Address.ApartmentNumber = Console.ReadLine();
        }

        public override void SetCity()
        {
            Console.WriteLine("Введите город: ");
            Address.City = Console.ReadLine();
        }

        public override void SetCountry()
        {
            Console.WriteLine("Введите страну: ");
            Address.Country = Console.ReadLine();
        }

        public override void SetHouse()
        {
            Console.WriteLine("Введите номер дома: ");
            Address.House = Console.ReadLine();
        }

        public override void SetPostalCode()
        {
            Console.WriteLine("Введите почтовый индекс: ");
            Address.PostalCode = Console.ReadLine();
        }

        public override void SetStreet()
        {
            Console.WriteLine("Введите улицу: ");
            Address.Street = Console.ReadLine();
        }
    }
}
