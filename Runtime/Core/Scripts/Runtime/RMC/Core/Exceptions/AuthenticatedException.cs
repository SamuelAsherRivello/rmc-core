using System;

namespace RMC.Core.Exceptions
{
    /// <summary>
    /// Thrown when initialization is required but not complete.
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
