using System;

namespace RMC.Core.Exceptions
{
    /// <summary>
    /// Thrown when initialization is required but not complete.
    /// </summary>
    public class NotInitializedException : Exception
    {
        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Constructor Methods ---------------------------
        public NotInitializedException(object obj) :
            base($"Not Initialized Exception() class = '{obj.GetType().Name}'")
        {
        }

        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
    }
}
