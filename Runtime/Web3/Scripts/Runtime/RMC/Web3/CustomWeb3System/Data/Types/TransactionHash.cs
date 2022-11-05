using RMC.Core.Interfaces;
using RMC.Core.Validators;

namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public class TransactionHash : IValidatable
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public string Value { get; set; }
        object IValidatable.Value { get { return Value;} }

        //  Fields ----------------------------------------


        //  Initialization --------------------------------
        public static TransactionHash CreateNull()
        {
            return new TransactionHash(NullTransactionHash);
        }
        
        public TransactionHash(string value)
        {
            Value = value;
        }
        

        //  Methods ---------------------------------------
        public override string ToString()
        {
            return $"[{this.GetType().Name}(Value = {Value})]";
        }


        //  Event Handlers --------------------------------

        public const string NullTransactionHash = "0x";
    }
    
}