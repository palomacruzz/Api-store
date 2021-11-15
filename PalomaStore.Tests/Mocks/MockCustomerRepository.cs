using System;
using System.Collections.Generic;
using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Queries;
using PalomaStore.Domain.StoreContext.Repositories;

namespace PalomaStore.Tests
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
           return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrderCountResult(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
        }
    }
}