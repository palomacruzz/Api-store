using FluentValidator;
using PalomaStore.Domain.StoreContext.CustomerCommands.Inputs;
using PalomaStore.Domain.StoreContext.Entities;
using PalomaStore.Domain.StoreContext.Repositories;
using PalomaStore.Domain.StoreContext.Services;
using PalomaStore.Domain.StoreContext.ValueObjects;
using PalomaStore.Shared.Commands;

namespace PalomaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : 
        Notifiable, 
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {     
            _repository = repository;
            _emailService = emailService;       
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
            AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");

             // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CreateCustomerCommandResult (false, "Por favor, corrija os campos abaixo.", Notifications);

             // Persistir o cliente
            _repository.Save(customer);

             // Enviar um E-mail de boas vindas
        _emailService.Send(email.Address, "paloma@gmail.com", "Bem vindo", "Seja bem vindo à Paloma Store!");

              // Retornar o resultado para tela
             return new CreateCustomerCommandResult(true, "Bem vindo à PalomaStore!", new{
                 Id = customer.Id,
                 Name = name.ToString(),
                 Email = email.Address
             });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}