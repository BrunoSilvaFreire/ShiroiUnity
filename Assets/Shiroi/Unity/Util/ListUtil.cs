using System;
using System.Collections.Generic;

namespace Shiroi.Unity.Util {
    public static class ListUtil {
        public static E RandomElement<E>(this IList<E> list) {
            return list.RandomElement(new Random());
        }

        public static E RandomElement<E>(this IList<E> list, Random random) {
            return list[random.Next(list.Count)];
        }
    }
}