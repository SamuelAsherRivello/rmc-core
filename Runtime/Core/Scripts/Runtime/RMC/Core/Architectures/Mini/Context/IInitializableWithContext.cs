namespace RMC.Core.Architectures.Mini.Context
{
    /// <summary>
    /// Implements API for types which Initialize.
    /// </summary>
    public interface IInitializableWithContext
    {
        //  Properties  ------------------------------------
        public bool IsInitialized { get; }
        public IContext Context { get; }

        //  General Methods  ------------------------------
        public void Initialize(IContext context);
        void RequireIsInitialized();
    }
}