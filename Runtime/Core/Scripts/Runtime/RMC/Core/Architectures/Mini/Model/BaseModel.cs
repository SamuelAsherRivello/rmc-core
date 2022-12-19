using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.MiniMvcs;
using RMC.Core.Architectures.MiniMvcs.Model;
using RMC.Core.Exceptions;

namespace RMC.Core.Architectures.MiniMvcs.Model
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class BaseModel: IModel
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