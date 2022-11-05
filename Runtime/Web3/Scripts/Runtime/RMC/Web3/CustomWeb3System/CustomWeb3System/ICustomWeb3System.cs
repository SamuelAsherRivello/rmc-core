using Cysharp.Threading.Tasks;
using RMC.Core.Interfaces;
using RMC.Web3.CustomWeb3System.Data.Types;

namespace RMC.Web3.CustomWeb3System.CustomWeb3System
{
    /// <summary>
    /// </summary>
    public interface ICustomWeb3System : IInitializableAsync, IAuthenticatableAsync, IWeb3Calls, IWeb3TransactionStatusCalls
    {
        //  Properties ------------------------------------
        int ChainId { get; }
        bool IsRememberMe { get; set; }

        //  Methods ---------------------------------------

        //  Async Methods ---------------------------------------
        UniTask<Address> GetUserAddressAsync();//todo: Remove "web3" from all signatures?
        UniTask<bool> HasUserAddressAsync();
        UniTask<SignatureHash> SignAsync(string message, bool isLogging = false);
    }
}