﻿using System;
using System.Text;

namespace StringBuilderSubstring
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder input, int start, int lenght)
        {
            //Checking Index out of range:
            if (start < 0 || start >= input.Length || start + lenght > input.Length)
            {
                throw new IndexOutOfRangeException("The index is out of range!");
            }
            else
            {
                ////Returning the StringBuilder as Substring of the input
                StringBuilder output = new StringBuilder();

                for (int i = start; i < start + lenght; i++)
                {
                    output.Append(input[i]);
                }
                return output;
            }
        }
    }
}
