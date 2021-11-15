using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PalomaStore.Domain.StoreContext.CustomerCommands.Inputs;
using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Handlers;
using PalomaStore.Domain.StoreContext.Queries;
using PalomaStore.Domain.StoreContext.Repositories;
using PalomaStore.Domain.StoreContext.ValueObjects;
using PalomaStore.Shared.Commands;

namespace PalomaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public CustomerOrdersCountResult GetByDocument(string document)
        {
            return _repository.GetCustomerOrderCountResult(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetByOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

    // Preciso implementar essa parte, fazer queries para update e delete.

        // [HttpPut]
        // [Route("customer/{id}")]
        // public Customer Put([FromBody]Customer customer)
        // {
        //     return null;
        // }

        // [HttpDelete]
        // [Route("customer/{id}")]
        // public string Delete()
        // {
        //     return null;
        // }
    }
}