using RMC.Core.Validators;
using RMC.Web3.CustomWeb3System.Data.Types;

namespace RMC.Web3.CustomWeb3System.Validators
{
    public class TransactionHashValidator : GenericValidator<TransactionHash>
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Initialization --------------------------------

        //  Methods ---------------------------------------
        public override bool Validate(TransactionHash validatable)
        {
            // TODO: More testing. Works well with polygon mumbai transactions for limited trials
            if (validatable == null ||
                validatable.Value == null ||
                validatable.Value.ToString().Length != 66 ||
                !validatable.Value.ToString().StartsWith("0x"))
            {
                return false;
            }

            return true;
        }
        //  Event Handlers --------------------------------

    }
    
}