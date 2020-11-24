using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenManagement
{
    /// <summary>
    ///     Some extension methods to make life easier...
    /// </summary>
    public static class Utilities
    {
        public static readonly Random Random = new Random();

        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable as T[] ?? enumerable.ToArray();
            var index = Random.Next(0, array.Length);

            return array[index];
        }

        public static bool RandomBool()
        {
            return Random.Next(101) >= 50;
        }
    }
}