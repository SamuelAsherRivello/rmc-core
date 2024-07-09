using System;

namespace RMC.Core.Exceptions
{
    /// <summary>
    /// Thrown when user must first override subclass and override method  
    /// </summary>
    public class MustOverrideMethodException : Exception
    {
        //  Properties ------------------------------------

        
        //  Fields ----------------------------------------

        
        //  Constructor Methods ---------------------------
        public MustOverrideMethodException(object value) :
            base($"Must Override Method In Subclass of Class: '{value.ToString()}'")
        {
            
        }

        //  Methods ---------------------------------------
        
        
        //  Event Handlers --------------------------------
        
        
    }
}