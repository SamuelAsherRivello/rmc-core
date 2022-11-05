
using Newtonsoft.Json;
using UnityEngine;

namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public class SmartContractCallRequest: ISmartContractCallRequest
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public string FunctionName { get { return _functionName;} } 
        public FunctionAccess FunctionAccess { get { return _functionAccess;} } 
        public SmartContract SmartContract { get { return _smartContract;} set { _smartContract = value;} }
        
        //  Fields ----------------------------------------
        private string _functionName = "";
        private FunctionAccess _functionAccess;
        private SmartContract _smartContract;
        private string[] _argsObject;

        //  Initialization --------------------------------
        public SmartContractCallRequest(string functionName, FunctionAccess functionAccess)
        {
            InitializeInternal(functionName, functionAccess, null, null);
        }
        
        public SmartContractCallRequest(string functionName, FunctionAccess functionAccess, SmartContract smartContract)
        {
            InitializeInternal(functionName, functionAccess, smartContract, null);
        }
        
        public SmartContractCallRequest(string functionName, FunctionAccess functionAccess, SmartContract smartContract, string[] argsObject)
        {
            InitializeInternal(functionName, functionAccess, smartContract, argsObject);
        }
        
        private void InitializeInternal (string functionName, FunctionAccess functionAccess, SmartContract smartContract, string[] argsObject)
        {
            _functionName = functionName;
            _functionAccess = functionAccess;
            _smartContract = smartContract;
      
            if (argsObject == null)
            {
                _argsObject = new string[]{};
            }
            else
            {
                _argsObject = argsObject;
            }
        }

        //  Methods ---------------------------------------
        public virtual string SerializeArgs()
        {
            // Populate obj with anything?
            // _argsObject ...

            // Serialize
            return JsonConvert.SerializeObject(_argsObject);
        }

        //  Event Handlers --------------------------------
    }   
}