using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.ValueObjects;

namespace PalomaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Paloma", "Cruz");
            var document = new Document("0289420357802");
            var email = new Email("paloma@alo");
            var c = new Customer(name, document, email, "9084923085");  
            var mouse = new Product("mouse", "rato", "image.png", 59.99M, 10);
            var teclado = new Product("teclado", "branco", "image.png", 159.99M, 2);
            var mesa = new Product("mesa", "grande", "image.png", 959.99M, 5);
            var pente = new Product("pente", "fino", "image.png", 59.99M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 10));
            //order.AddItem(new OrderItem(teclado, 2));
            //order.AddItem(new OrderItem(mesa, 5));
            //order.AddItem(new OrderItem(pente, 10));

            // OrderItem orderItem = new OrderItem();

            // orderItem.TratandoErros();

            // order.Place();

            // order.Pay();

            // order.Ship();
        
            // order.Cancel();
            
        }
    }
}
