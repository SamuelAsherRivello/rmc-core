using RMC.Core.Architectures.MiniMvcs.Controller.Commands;

namespace RMC.Core.Architectures.Mini.Context
{
    public interface IContext
    {
        ModelLocator ModelLocator { get; }
        CommandManager CommandManager { get; }
    }
}