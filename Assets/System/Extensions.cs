using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T[] GetRange<T>(this T[] arr, int fromIndex, int toIndex)
    {
        if (fromIndex > toIndex)
        {
            int i = fromIndex;
            fromIndex = toIndex;
            toIndex = i;
        }

        if (fromIndex > arr.Length || toIndex > arr.Length)
            throw new IndexOutOfRangeException();

        T[] newArr = new T[toIndex - fromIndex];

        for (int i = fromIndex; i < toIndex + 1; i++)
        {
            newArr[i - fromIndex] = arr[i];
        }

        return newArr;
    }

}
