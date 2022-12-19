
namespace RMC.Core.Architectures.MiniMvcs.Controller.Commands
{
	/// <summary>
	/// Holds the before and after value during a property change
	/// </summary>
	public abstract class ValueChangedCommand<T> : ICommand
	{
		public T PreviousValue { get { return _previousValue; } }
		public T CurrentValue { get { return _currentValue; } }

		private readonly T _previousValue;
		private readonly T _currentValue;

		public ValueChangedCommand(T previousValue, T currentValue)
		{
			_previousValue = previousValue;
			_currentValue = currentValue;
		}
	}
}