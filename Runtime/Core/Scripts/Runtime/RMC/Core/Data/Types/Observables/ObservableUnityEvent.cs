using System;
using UnityEngine.Events;

namespace RMC.Core.Data.Types.Observables
{
    /// <summary>
    /// The main event for <see cref="Observable{t}"/>.
    /// </summary>
    public class ObservableUnityEvent<T> : UnityEvent<T> 
    {
    }
}
