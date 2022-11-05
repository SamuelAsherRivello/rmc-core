namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public class SmartContractNetwork
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public string Network { get { return _network; }}
        public string Chain { get { return _chain;} }
        public int ChainId { get { return _chainId;} }
        public string Rpc { get { return _rpc;} }

        
        //  Fields ----------------------------------------
        private string _network;
        private string _chain;
        private int _chainId;
        private string _rpc;
        
        
        //  Initialization --------------------------------
        public SmartContractNetwork(string network, string chain, int chainId, string rpc = "")
        {
            _network = network;
            _chain = chain;
            _chainId = chainId;
            _rpc = rpc;
        }

        
        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
    }
    
}