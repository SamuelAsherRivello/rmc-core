using Cysharp.Threading.Tasks;

namespace RMC.Core.Interfaces
{
    /// <summary>
    /// Implements API for types which Initialize.
    /// </summary>
    public interface IInitializableAsync
    {
        //  Properties  ------------------------------------
        public bool IsInitialized { get; }

        //  General Methods  ------------------------------
        public UniTask InitializeAsync();
        void RequireIsInitialized();
    }
}