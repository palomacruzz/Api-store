using System;

namespace PalomaStore.Domain.StoreContext.Queries
{
    public class ListCustomerOrderQueryResult
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Documet { get; set; } 
        public string Email { get; set; }
        public string Number { get; set; }
        public decimal Total { get; set; }
    }
}