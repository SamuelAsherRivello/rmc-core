namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public abstract class SmartContract
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public string Abi { get { return _abi;} }
        public Address Address { get { return _address;} }
        public SmartContractNetwork SmartContractNetwork { get { return _smartContractNetwork; }}

        //  Fields ----------------------------------------
        protected string _abi;
        protected Address _address;
        protected SmartContractNetwork _smartContractNetwork;
        
        //  Initialization --------------------------------


        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
    }
    
}