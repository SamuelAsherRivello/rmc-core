using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.MiniMvcs.Controller;
using RMC.Core.Architectures.MiniMvcs.Model;
using RMC.Core.Architectures.MiniMvcs.Service;
using RMC.Core.Architectures.MiniMvcs.View;
using RMC.Core.Exceptions;
using RMC.Core.Interfaces;

namespace RMC.Core.Architectures.MiniMvcs
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class Mini<X,M,V,C,S> : IInitializable 
        where X : IContext 
        where M : IModel 
        where V : IView
        where C : IController 
        where S : IService 
    
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        
        protected X _context;
        protected M _model;
        protected V _view;
        protected C _controller;
        protected S _service;
        
        //  Fields ----------------------------------------
        protected bool _isInitialized = false;

        //  Initialization --------------------------------
        public virtual void Initialize()
        {
            throw new MustOverrideMethodException(this);
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