using System.Linq;
using UnityEngine;

namespace Shiroi.Unity.Util {
    public static class AnimatorUtil {
        public static bool HasParameter(this Animator animator, string paramName) {
            return animator.parameters.Any(param => param.name == paramName);
        }
    }
}