
namespace RMC.Core.Data.Types.Observables
{
    /// <summary>
    /// Wrapper so a type can be observable via events
    /// </summary>
    public class Observable<T> 
    {
        //  Events ----------------------------------------
        public readonly ObservableUnityEvent<T,T> OnValueChanged = new ObservableUnityEvent<T,T>();

        //  Properties ------------------------------------
        
        /// <summary>
        /// Keep this property name as "Value"
        /// </summary>
        public T Value
        {
            set
            {
                _currentValue = OnValueChanging(_currentValue, value);
                OnValueChanged.Invoke(_previousValue, _currentValue);
            }
            get
            {
                return _currentValue;
            }
        }

        //  Fields ----------------------------------------
        private T _currentValue;
        private T _previousValue;

        //  Constructor Methods ---------------------------
        static Observable()
        {
            //Debug.LogWarning("Observable static called. FYI to me");
        }

        public Observable()
        {
            //This gets called on scenes start. Cool. Useful?
            //Debug.LogWarning("Observable constr called. FYI to me");
        }

        //  Methods ---------------------------------------
        protected virtual T OnValueChanging(T previousValue, T newValue)
        {
            //Optional: Override method to gate/police the value changes
            _previousValue = previousValue;
            return newValue;
        }

        //  Event Handlers --------------------------------
    }

}
