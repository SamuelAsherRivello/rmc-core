
namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public interface ISmartContractCallRequest
    {
        //  Properties  ------------------------------------
        string FunctionName { get; }
        FunctionAccess FunctionAccess { get; }
        SmartContract SmartContract { get; set; }
        
        //  General Methods  ------------------------------
        public string SerializeArgs();
    }
    
}