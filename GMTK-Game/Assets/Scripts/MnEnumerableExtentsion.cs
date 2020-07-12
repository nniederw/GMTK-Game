using System;
using System.Collections.Generic;
public static class MnEnumerableExtentsion
{
    public static IEnumerable<T> Foreach<T>(this IEnumerable<T> list, Action<T> action) //where T : notnull
    {
        foreach (T item in list)
        {
            action(item);
        }
        return list;
    }
}