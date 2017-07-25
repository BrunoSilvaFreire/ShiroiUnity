using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shiroi.Unity.Toggleable {
    /// <summary>
    /// Represents a controller for a value 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="S"></typeparam>
    public abstract class Toggleable<S, T> : MonoBehaviour {
        public S Source;

        public T CurrentValue {
            get { return GetValue(Source); }
            set { SetValue(value, Source); }
        }

        protected abstract void SetValue(T value, S source);

        protected abstract T GetValue(S source);

        /// <summary>
        /// The minimum (Off) value.
        /// </summary>
        public T Min;

        /// <summary>
        /// The maximum (On) value.
        /// </summary>
        public T Max;
        
        public abstract bool Play { get; set; }
    }
}