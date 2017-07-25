using UnityEngine;

namespace Shiroi.Unity.Toggleable {
    /// <summary>
    /// A toggleable controller that slowly linearly interpolates (Lerp) between on and off states.
    /// When the current value is close enough to the target. The interpolation stops and the value 
    /// snaps to the selected target.
    /// </summary>
    /// <typeparam name="T">The type of the value that is lerped</typeparam>
    /// <typeparam name="S">The source of the <see cref="Toggleable{S,T}.CurrentValue"/></typeparam>
    public abstract class LerpToggleable<S, T> : Toggleable<S, T> {
        public delegate void LerpEvent();

        public delegate void LerpEvent<in TV>(TV value);

        /// <summary>
        /// Called when the current state (<see cref="Play"/>) of the controller is changed.
        /// </summary>
        public event LerpEvent<bool> ToggleChange;

        /// <summary>
        /// Called when an interpolation is completed and the <see cref="CurrentTarget"/> snaps to 
        /// the <see cref="CurrentThreshold"/>
        /// </summary>
        public event LerpEvent LerpCompleted;

        [SerializeField]
        private bool play;

        /// <summary>
        /// Pretty self explanatory. 
        /// If set to true, the lerping is put to a pause.
        /// </summary>
        public bool Ignore;

        /// <summary>
        /// The threshold that when exceeded, will stop the interpolation and snap the
        /// <see cref="Toggleable{S,T}.CurrentValue"/> to <see cref="Toggleable{S,T}.Max"/>.
        /// </summary>
        public abstract T OnThreshold { get; }

        /// <summary>
        /// The threshold that when deceeded, will stop the interpolation and snap the
        /// <see cref="Toggleable{S,T}.CurrentValue"/> to <see cref="Toggleable{S,T}.Min"/>.
        /// </summary>
        public abstract T OffThreshold { get; }

        /// <summary>
        /// The speed of the interpolation.
        /// </summary>
        public float ChangeSpeed = 10;


        private bool shouldUpdate;

        /// <summary>
        /// The value that the <see cref="Toggleable{S,T}.CurrentValue"/> is interpolated towards.
        /// </summary>
        public T CurrentTarget {
            get { return Play ? Max : Min; }
        }

        /// <summary>
        /// Determines the current target.
        /// 
        /// When set to true (On), the <see cref="CurrentTarget"/> becomes <see cref="Toggleable{S,T}.Max"/>, and when set 
        /// to false (Off), it becomes <see cref="Toggleable{S,T}.Min"/>.
        /// 
        /// Interpolation will automatically occour when changing this value.
        /// </summary>
        public override bool Play {
            get { return play; }
            set {
                play = value;
                OnToggleChange(value);
                shouldUpdate = true;
            }
        }

        public T CurrentThreshold {
            get { return Play ? OnThreshold : OffThreshold; }
        }

        private void Update() {
            if (!shouldUpdate && !Equals(CurrentValue, CurrentTarget)) {
                shouldUpdate = true;
            }
            if (!shouldUpdate || Ignore) {
                return;
            }
            CurrentValue = Lerp(CurrentValue, CurrentTarget, ChangeSpeed * Time.deltaTime);

            if (Play) {
                if (IsOverThreshold(CurrentValue, CurrentThreshold)) {
                    StopUpdating();
                }
            } else {
                if (IsUnderThreshold(CurrentValue, CurrentThreshold)) {
                    StopUpdating();
                }
            }
            if (!shouldUpdate) {
                OnLerpCompleted();
            }
        }


        private void StopUpdating() {
            shouldUpdate = false;
            CurrentValue = CurrentTarget;
        }

        protected abstract bool IsUnderThreshold(T value, T threshold);

        protected abstract bool IsOverThreshold(T value, T threshold);

        protected abstract T Lerp(T a, T b, float alpha);

        protected virtual void OnLerpCompleted() {
            var handler = LerpCompleted;
            if (handler != null)
                handler();
        }

        protected virtual void OnToggleChange(bool value) {
            var handler = ToggleChange;
            if (handler != null)
                handler(value);
        }
    }
}