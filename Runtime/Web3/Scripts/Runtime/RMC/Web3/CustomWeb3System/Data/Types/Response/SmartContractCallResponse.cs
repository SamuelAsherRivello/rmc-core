
namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public class SmartContractCallResponse<T> : ISmartContractCallResponse<T>
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public Transaction Transaction { get; }
        public T Result { get; }
        public bool IsError { get; }
        public string ErrorMessage { get; }

        //  Fields ----------------------------------------


        //  Initialization --------------------------------
        public SmartContractCallResponse(Transaction transaction, T result, bool isError, string errorMessage)
        {
            Transaction = transaction;
            Result = result;
            IsError = isError;
            ErrorMessage = errorMessage;
        }

        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
        

    }
}