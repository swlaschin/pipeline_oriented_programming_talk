using System;

namespace csharpdemo
{
    public class RomanNumeralExample
    {
        /// <summary>
        /// Roman numeral without special cases
        /// </summary>
        static public string ToRomanNumerals(int n)
        {
            return new String('I', n)
                .Replace("IIIII", "V")
                .Replace("VV", "X")
                .Replace("XXXXX", "L")
                .Replace("LL", "C");
        }

        /// <summary>
        /// Roman numeral with special cases
        /// </summary>
        static public string ToRomanNumerals2(int n)
        {
            return new String('I', n)
                .Replace("IIIII", "V")
                .Replace("VV", "X")
                .Replace("XXXXX", "L")
                .Replace("LL", "C")
                // with special cases
                .Replace("VIIII", "IX")
                .Replace("IIII", "IV")
                .Replace("LXXXX", "XC")
                .Replace("XXXX", "XL");
        }
    }
}
