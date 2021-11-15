using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Enums;
using PalomaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalomaStore.Domain.StoreContext.CustomerCommands.Inputs;

namespace PalomaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Paloma";
            command.LastName = "Cruz";
            command.Document = "28659170377";
            command.Email = "paloma@gmail.com";
            command.Phone = "85999999995";

            Assert.AreEqual(true, command.Valid());
        }
    }
}