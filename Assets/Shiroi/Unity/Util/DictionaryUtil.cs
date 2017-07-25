using System;
using System.Collections.Generic;

namespace Shiroi.Unity.Util {
    public static class DictionaryUtil {
        public static V GetOrDefault<K, V>(this Dictionary<K, V> dict, K key) {
            if (dict == null) {
                return default(V);
            }
            return dict.ContainsKey(key) ? dict[key] : default(V);
        }

        public static V GetOrPut<K, V>(this Dictionary<K, V> dict, K key, Func<V> creator) {
            if (dict.ContainsKey(key)) {
                return dict[key];
            }
            var value = creator();
            dict[key] = value;
            return value;
        }
    }
}