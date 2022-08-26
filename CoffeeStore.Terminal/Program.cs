using CoffeeStore.DataAccess.Context;
using CoffeeStore.DataAccess.Models;

var dbContext = new CoffeeStoreContext();
var products = dbContext.Products;

// Fetch data with filter
var prodTypeID = Guid.Parse("0C57276D-022F-4983-A175-550E19B17318");
var coffeeBeeanProducts = products.Where(prod=>prod.ProductTypeId == prodTypeID);

foreach ( var product in coffeeBeeanProducts)
{
    Console.WriteLine($"Name:{product.Name}, Description: {product.Description}");
}

// Joined data from two tables
var orders = dbContext.Orders;
var orderDetails = dbContext.OrderDetails;

var ordersWithDetails = orders.Join(
    orderDetails, 
    order => order.Id, 
    orderDetail => orderDetail.OrderId, 
    (order, orderDetail) => new 
{ 
    OrderId = order.Id,
    Amount = orderDetail.Amount,
    Sum = orderDetail.Sum,
}

);
foreach (var orderRow in ordersWithDetails)
{
    Console.WriteLine($"ID: {orderRow.OrderId}, Amount: {orderRow.Amount}, Sum: {orderRow.Sum} ");
}


// Add new product

var productType = dbContext.ProductTypes.FirstOrDefault(type => type.Name == "Coffee (ground)")
?? throw new InvalidOperationException("Type 'Coffee (ground)' should be placed in ProductTypes!");

var javaCoffee = new Product
{
    Id = Guid.NewGuid(),
    Name = "Java Coffee",
    Description = "The best coffee (much better than programming language)",
    NomenclatureNumber = "0015-4326",
    ProductTypeId = productType.Id

};

await dbContext.Products.AddAsync(javaCoffee);
await dbContext.SaveChangesAsync();

var javaCoffeeStored = products.SingleOrDefault(prod=>prod.Id==javaCoffee.Id);
Console.WriteLine(javaCoffeeStored?.Name ?? "NOT FOUND");
