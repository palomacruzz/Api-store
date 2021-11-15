using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Services;

namespace PalomaStore.Tests
{
    public class MockEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
        }
    }
}