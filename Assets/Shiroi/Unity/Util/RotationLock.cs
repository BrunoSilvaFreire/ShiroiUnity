using UnityEngine;

namespace Shiroi.Unity.Util {
    public class RotationLock : MonoBehaviour {
        public Quaternion Rotation = Quaternion.identity;

        private void Update() {
            transform.rotation = Rotation;
        }
    }
}