using System;

namespace RMC.Core.Exceptions
{
    /// <summary>
    /// Thrown when authentication is required NOT to happen yet, but has happened.
    /// </summary>
    public class AuthenticatedException : Exception
    {
        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Constructor Methods ---------------------------
        public AuthenticatedException(object obj) :
            base($"Authenticated Exception() class = '{obj.GetType().Name}'")
        {
        }

        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}
