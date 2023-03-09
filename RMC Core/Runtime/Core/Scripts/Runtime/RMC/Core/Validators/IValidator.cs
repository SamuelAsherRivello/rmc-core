
namespace RMC.Core.Validators
{
    public interface IValidator 
    {
    }
    
    /// <summary>
    /// 
    /// </summary>
    public interface IValidator<T> : IValidator where T : IValidatable
    {
        // Properties -------------------------------------
        

        // Fields -----------------------------------------
        bool Validate(T validatable);
        void RequireIsValid(T validatable);
    }
}