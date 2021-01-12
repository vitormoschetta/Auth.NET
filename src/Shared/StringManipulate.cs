using System;

namespace Shared
{
    public class StringManipulate
    {
        public static string OnlyNumbers(string value)
        {            
            return String.Join("", System.Text.RegularExpressions.Regex.Split(value, @"[^\d]"));
        }
    }
}