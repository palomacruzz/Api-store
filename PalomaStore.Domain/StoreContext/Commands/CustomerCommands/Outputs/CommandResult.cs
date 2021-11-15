using System;
using PalomaStore.Shared.Commands;

namespace PalomaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}