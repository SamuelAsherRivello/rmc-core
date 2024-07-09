using RMC.Core.Exceptions;

namespace RMC.Core.Validators
{
    /// <summary>
    /// Parent for a validator class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericValidator<T> : IValidator<T> where T : IValidatable
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Initialization --------------------------------

        //  Methods ---------------------------------------
        
        
        /// <summary>
        /// Call explicitly to determine IsValid
        /// </summary>
        /// <param name="validatable"></param>
        /// <returns></returns>
        public virtual bool Validate(T validatable)
        {
            return false; //override
        }
        
        /// <summary>
        /// Convenience method. Call when you assume
        /// the data is valid, so it will throw an exception
        /// in the unexpected case of IsValid==false.
        /// </summary>
        /// <param name="validatable"></param>
        /// <exception cref="IsNotValidException"></exception>
        public void RequireIsValid(T validatable)
        {
            if (!Validate(validatable))
            {
                throw new IsNotValidException(this);
            }
        }
        //  Event Handlers --------------------------------
    }
    
}