
namespace RMC.Core.Validators
{
    public interface IValidatable 
    {
    }
    
    /// <summary>
    /// 
    /// </summary>
    public interface IValidatable<T> : IValidatable
    {
        // Properties -------------------------------------
        T Value { get; }

        // Fields -----------------------------------------
    }
}