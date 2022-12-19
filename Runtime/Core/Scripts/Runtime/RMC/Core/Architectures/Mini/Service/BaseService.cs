using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Exceptions;

namespace RMC.Core.Architectures.MiniMvcs.Service
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class BaseSerice : IService
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        //  Fields ----------------------------------------
        private bool _isInitialized = false;
        private IContext _context;

        //  Initialization  -------------------------------
        public virtual void Initialize(IContext context)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                _context = context;
            }
        }

        public void RequireIsInitialized()
        {
            if (!_isInitialized)
            {
                throw new NotInitializedException(this);
            }
        }
        
        //  Methods ---------------------------------------
        
        //  Event Handlers --------------------------------

    }
}