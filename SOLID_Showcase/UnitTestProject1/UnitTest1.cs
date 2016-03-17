using Library.Base;
using Library.CommandAspects;
using Library.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod] 
        public void TestMethod1()
        {
            int xValue = 2;

            DoPlaceBetTicket command = new DoPlaceBetTicket(new MockDatabase()) {
                XValue = xValue
            };

            ExecuteCommand(command);

            int ticketId = command.TicketId.Value;

            //test
        }

        private static void ExecuteCommand(ICommand command)
        {
            command = new LogAspect(command);
            command = new LogAspect(command);
            command.Execute();
        }

    }

}
