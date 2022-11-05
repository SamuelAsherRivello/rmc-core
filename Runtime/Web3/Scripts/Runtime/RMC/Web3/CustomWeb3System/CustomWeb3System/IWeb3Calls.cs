using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using RMC.Web3.CustomWeb3System.Data.Types;

namespace RMC.Web3.CustomWeb3System.CustomWeb3System
{
    /// <summary>
    /// </summary>
    public interface IWeb3Calls 
    {
        //  Properties ------------------------------------

        //  Methods ---------------------------------------
        
        //  Async Methods ---------------------------------------
        UniTask<Address> VerifyAsync(string message, SignatureHash signatureHash, bool isLogging = false);
        
        UniTask<ISmartContractCallResponse<T>> SmartContractCallAsync<T>( ISmartContractCallRequest smartContractCallRequest, bool isLogging = false);
        UniTask<ISmartContractCallResponse<T>> SmartContractCallRawAsync<T>(string functionName, FunctionAccess functionAccess, SmartContract smartContract, string[] argsObject, bool isLogging = false);
        
        UniTask<List<Nft>> GetNFTsForContractAsync       (Address contractAddress, bool isLogging = false);
    
    }
}