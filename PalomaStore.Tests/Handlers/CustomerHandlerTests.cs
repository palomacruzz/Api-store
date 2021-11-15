using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Enums;
using PalomaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalomaStore.Domain.StoreContext.CustomerCommands.Inputs;
using PalomaStore.Domain.StoreContext.Handlers;

namespace PalomaStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Paloma";
            command.LastName = "Cruz";
            command.Document = "28659170377";
            command.Email = "paloma@gmail.com";
            command.Phone = "85999999995";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}