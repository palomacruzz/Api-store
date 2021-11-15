using System;
using System.Collections.Generic;
using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Queries;

namespace PalomaStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrderCountResult(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id);
    }
}