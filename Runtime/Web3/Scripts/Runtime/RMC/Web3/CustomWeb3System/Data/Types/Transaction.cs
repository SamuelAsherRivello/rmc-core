using RMC.Core.Exceptions;

namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public class Transaction
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public TransactionHash TransactionHash { get; private set; }
        public TransactionStatus TransactionStatus { get; private set; }
        
        //  Fields ----------------------------------------

        //  Initialization --------------------------------
        public Transaction(TransactionHash transactionHash, TransactionStatus transactionStatus)
        {
            TransactionHash = transactionHash;
            TransactionStatus = transactionStatus;
        }

        //  Methods ---------------------------------------
        public static TransactionStatus ConvertStringToStatus(string status)
        {
            status = status.ToLower();
            TransactionStatus transactionStatus;
            switch (status)
            {
                case "pending":
                    transactionStatus = TransactionStatus.Pending;
                    break;
                case "success":
                    transactionStatus = TransactionStatus.Success;
                    break;
                case "fail":
                    transactionStatus = TransactionStatus.Fail;
                    break;
                default:
                    throw new SwitchDefaultException(status);
            }

            return transactionStatus;
        }

        //  Event Handlers --------------------------------
       
    }
    
}