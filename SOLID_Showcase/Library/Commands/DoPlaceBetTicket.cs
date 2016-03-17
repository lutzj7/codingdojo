using System;
using System.Diagnostics;
using Library.Base;

namespace Library.Commands
{
    public class DoPlaceBetTicket : ICommand
    {
        private readonly IDatabase _database;

        public DoPlaceBetTicket(IDatabase database)
        {
            _database = database;
        }

        public int XValue { get; set; }
        public int? TicketId { get; private set; }

        public void Execute()
        {
            TicketId = new Random().Next();

            Debug.WriteLine(_database.ExecuteQuery());

            Debug.WriteLine("Placing ticket...");
        }
    }
}