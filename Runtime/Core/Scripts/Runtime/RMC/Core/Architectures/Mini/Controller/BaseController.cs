using RMC.Core.Architectures.MiniMvcs;
using RMC.Core.Architectures.MiniMvcs.Controller;
using RMC.Core.Exceptions;

namespace RMC.Core.Architectures.MiniMvcs.Controller
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class BaseController<M,V,S>: IController
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        //  Fields ----------------------------------------
        private bool _isInitialized = false;
        protected readonly M _model;
        protected readonly V _view;
        protected readonly S _service;
        private IContext _context;

        public BaseController(M model, V view, S service)
        {
            _model = model;
            _view = view;
            _service = service;
        }

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