using System.Threading.Tasks;
using RMC.Core.Interfaces;
using Cysharp.Threading.Tasks;
using RMC.Web3.CustomWeb3System.Data.Types;

namespace RMC.Web3.CustomWeb3System.CustomWeb3Wallet
{
    /// <summary>
    /// Implemented by <see cref="WalletConnectWeb3WalletSystem"/>
    /// </summary>
    public interface ICustomWeb3WalletSystem : IInitializableAsync, IAuthenticatableAsync
    {
        //  Properties ------------------------------------
        SmartContractNetwork SmartContractNetwork { get; } //TODO Remove this?
        bool IsRememberMe { get; set; }

        //  Methods ---------------------------------------
        
        
        //  Async Methods ---------------------------------------
        UniTask<Address> GetUserAddressAsync();
        UniTask<bool> HasUserAddressAsync();
        UniTask<TransactionHash> SendTransactionAsync(
            string chainId, 
            Address toAddress, 
            string value, 
            string data = "",
            string gasLimit = "", 
            string gasPrice = "");

        UniTask<SignatureHash> SignAsync(string message, bool isLogging = false);
    }
}