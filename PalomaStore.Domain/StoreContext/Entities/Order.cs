using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using PalomaStore.Domain.StoreContext.Enums;
using PalomaStore.Shared.Entities;

namespace PalomaStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
       

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries  = new List<Delivery>();
        }
        
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        // criar um pedido
        public void Place()
        {
            // gerar o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();

            if(_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
        }

        // pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        // enviar um pedido
        public void Ship()
        {
            // a cada 5 produtos é feito uma entrega
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            // quebra as entregas
            foreach(var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                 
                }
                count++;
            }

            // envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            // adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}