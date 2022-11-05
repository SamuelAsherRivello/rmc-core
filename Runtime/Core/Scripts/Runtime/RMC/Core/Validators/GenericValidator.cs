using RMC.Core.Exceptions;

namespace RMC.Core.Validators
{
    public class GenericValidator<T> : IValidator<T> where T : IValidatable
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Initialization --------------------------------

        //  Methods ---------------------------------------
        public virtual bool Validate(T validatable)
        {
            return false; //override
        }
        
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