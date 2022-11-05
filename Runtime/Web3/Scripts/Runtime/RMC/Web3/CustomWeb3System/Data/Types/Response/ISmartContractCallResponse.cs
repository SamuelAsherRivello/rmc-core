namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public interface ISmartContractCallResponse<T>
    {
        //  Properties  ------------------------------------
        Transaction Transaction { get; }
        T Result { get; }
        bool IsError { get; }
        string ErrorMessage { get; }

        //  General Methods  ------------------------------
    }
}