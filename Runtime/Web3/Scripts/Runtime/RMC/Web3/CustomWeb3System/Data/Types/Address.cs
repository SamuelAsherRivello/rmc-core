using RMC.Core.Validators;

// ReSharper disable NonReadonlyMemberInGetHashCode
namespace RMC.Web3.CustomWeb3System.Data.Types
{
    public class Address : IValidatable
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public string Value { get; set; }
        object IValidatable.Value { get { return Value;} }
        
        //  Fields ----------------------------------------


        //  Initialization --------------------------------
        public Address(string value)
        {
            Value = value;
        }
        

        //  Methods ---------------------------------------
        public override string ToString()
        {
            return $"[{this.GetType().Name}(Value = {Value})]";
        }
        
        public string ToShortFormat()
        {
            const int n = 6;
            if (string.IsNullOrEmpty(Value))
            {
                return string.Empty;
            }
        
            if (Value.Length < n)
            {
                return Value;
            }

            return $"{Value.Substring(0, n)}...{Value.Substring(Value.Length - n)}";
        }

        public override bool Equals(object obj) => Equals(obj as Address);
        private bool Equals(Address obj)
        {
            if (obj == null)
            {
                return false;
            }
            return (Value == obj.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }


        //  Event Handlers --------------------------------
    }
    
}