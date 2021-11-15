using PalomaStore.Domain.StoreContext.Entities;

namespace PalomaStore.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void Send (string to, string from, string subject, string body);
    }
}