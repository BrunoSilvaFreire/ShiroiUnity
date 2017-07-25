using System.Collections.Generic;
using UnityEngine;

namespace Shiroi.Unity.Util {
    public static class TransformUtil {
        
        public static List<Transform> GetChildren(this Transform behaviour) {
            var children = new List<Transform>();
            for (var i = 0; i < behaviour.childCount; i++) {
                children.Add(behaviour.GetChild(i));
            }
            return children;
        }

        public static void ClearChildren(this Transform transform) {
            var children = transform.GetChildren();
            foreach (var child in children) {
                Object.Destroy(child);
            }
        }
    }
}