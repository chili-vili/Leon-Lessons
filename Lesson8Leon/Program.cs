using Lesson8Leon;

class Program
{
    static void Main(string[] args)
    {
        Responder responder = new Responder(new DeliveryAddressBuilder());

        Address address = responder.Bake();

        Console.WriteLine($"Contry: {address.Country}\nCity: {address.City}\nPostalCode: {address.PostalCode}\nStreet: {address.Street}\nHouse: {address.House}\nApartmentNumber: {address.ApartmentNumber}");
        Console.Read();
    }
}