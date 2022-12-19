using RMC.Core.Architectures.MiniMvcs.Controller.Commands;

namespace RMC.Core.Architectures.MiniMvcs
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class Context : IContext
	{
		public ModelLocator ModelLocator { get { return _modelLocator; } }
		public CommandManager CommandManager { get { return _commandManager; } }

		private readonly ModelLocator _modelLocator;
		private readonly CommandManager _commandManager;

		public Context()
		{
			_modelLocator = new ModelLocator();
			_commandManager = new CommandManager();
		}
	}
}