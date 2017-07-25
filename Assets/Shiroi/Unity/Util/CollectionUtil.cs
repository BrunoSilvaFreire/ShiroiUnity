using System.Collections.Generic;

namespace Datenshi.Scripts.Util {
    public static class CollectionUtil {
        public static bool IsEmpty<T>(this IList<T> list) {
            return list.Count <= 0;
        }
    }
}