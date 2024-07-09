using System;
using RMC.Core.Validators;

namespace RMC.Core.Exceptions
{
    /// <summary>
    /// Thrown when IsValid==true is required but not complete.
    /// </summary>
    public class IsNotValidException : Exception
    {
        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Constructor Methods ---------------------------
        public IsNotValidException(IValidator obj) :
            base($"Is Not Valid Exception() class = '{obj.GetType().Name}'")
        {
        }

        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}
