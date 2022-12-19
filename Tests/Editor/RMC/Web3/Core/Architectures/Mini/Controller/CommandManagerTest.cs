using NUnit.Framework;
using RMC.Core.Architectures.MiniMvcs.Controller.Commands;
using RMC.Core.Architectures.MiniMvcs.Model;

namespace RMC.Core.Architectures.Mini.Controller
{
    public class CommandManagerTest
    {
        public class TestCommand : ICommand
        {
        }
        
        [Test]
        public void CommandWasCalled_IsTrue_WhenInvokeCommand()
        {
            // Arrange
            CommandManager commandManager = new CommandManager();
            bool commandWasCalled = false;
            commandManager.AddCommandListener<TestCommand>(
                delegate(TestCommand command)
                {
                    commandWasCalled = true;
                });
            
            // Act
            commandManager.InvokeCommand(new TestCommand());

            // Assert
            Assert.That(commandWasCalled, Is.True);
        }
    }
}
