using Cysharp.Threading.Tasks;

namespace RMC.Core.Interfaces
{
    /// <summary>
    /// Implements API for types which Initialize.
    /// </summary>
    public interface IAuthenticatableAsync
    {
        //  Properties  ------------------------------------
        public bool IsAuthenticated { get; }

        //  General Methods  ------------------------------
        void RequireIsAuthenticated();
        
        //  General Methods  ------------------------------
        UniTask AuthenticateAsync();
        UniTask DeauthenticateAsync();
    }
}