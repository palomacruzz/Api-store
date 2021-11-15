using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using PalomaStore.Domain.StoreContext.ValueObjects;
using PalomaStore.Shared.Entities;

namespace PalomaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone) 
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>(); // ao instanciar uma lista precisa sempre inicializa-lá         
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }    
        public Email Email { get; private set; }
        public string Phone { get; private set; }    
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            //validar o endereço
            //adicionar o endereço
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}