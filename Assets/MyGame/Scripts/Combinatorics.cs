using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Combinatorics
{

    private const int RANDOMSEED = 123;
    //public static System.Random rnd = new System.Random(RANDOMSEED);
    public static System.Random rnd = new System.Random(); // declare need Random Object

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count; // take the size of the list and assign the value to n
        while (n > 1)
        {
            n--; // count down one
            int k = rnd.Next(n + 1); // declare integer k, assign a random integer inbetween 0 and n + 1
            T value = list[k]; // declare value with chosen datatype, assign the list k^th value to it
            list[k] = list[n]; // assign the lists n^th value to the lists k^th value
            list[n] = value; // assign the lists n^th value to the varible value
        }
    }
}