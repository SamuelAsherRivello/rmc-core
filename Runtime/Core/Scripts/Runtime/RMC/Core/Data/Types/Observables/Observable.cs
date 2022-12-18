using UnityEngine;

namespace RMC.Core.Data.Types.Observables
{
    /// <summary>
    /// Wrapper so a type can be observable via events
    /// </summary>
    public class Observable<T> 
    {
        //  Events ----------------------------------------
        public ObservableUnityEvent<T> OnValueChanged = new ObservableUnityEvent<T>();

        //  Properties ------------------------------------
        public T Value
        {
            set
            {
                _value = OnValueChanging(_value, value);
                OnValueChanged.Invoke(_value);
            }
            get
            {
                return _value;

            }
        }

        //  Fields ----------------------------------------
        private T _value;

        //  Constructor Methods ---------------------------
        static Observable()
        {
            Debug.LogWarning("Observable static called. FYI to me");
        }

        public Observable()
        {
            //This gets called on scenes start. Cool. Useful?
            //Debug.LogWarning("Observable constr called. FYI to me");
        }

        //  Methods ---------------------------------------
        protected virtual T OnValueChanging(T oldValue, T newValue)
        {
            return newValue;
        }

        //  Event Handlers --------------------------------
    }

}
