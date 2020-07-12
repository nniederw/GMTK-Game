using System;
using System.Collections.Generic;
public static class MnExtentsion
{
    public static IEnumerable<T> Foreach<T>(this IEnumerable<T> list, Action<T> action) //where T : notnull
    {
        foreach (T item in list)
        {
            action(item);
        }
        return list;
    }
    public static T DoThrow<T>(string msg = "")
    {
        throw new Exception(msg);
    }
}