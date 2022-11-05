using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using RMC.Web3.CustomWeb3System.Data.Types;

namespace RMC.Web3.CustomWeb3System.CustomWeb3System
{
    /// <summary>
    /// </summary>
    public interface IWeb3TransactionStatusCalls 
    {
        //  Properties ------------------------------------

        //  Methods ---------------------------------------
        
        //  Async Methods ---------------------------------------
        UniTask<Transaction> WaitTransactionStatusSuccessAsync(Transaction transaction);
        UniTask<Transaction> GetTransactionStatusAsync(Transaction transaction);
    }
}