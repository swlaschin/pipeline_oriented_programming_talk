using System;
using System.Linq;

namespace csharpdemo
{

    /// <summary>
    /// Demonstrates the classic FizzBuzz
    /// </summary>
    static class FizzBuzzExample1
    {
        static public void FizzBuzz()
        {
            for (var i = 1; i <= 30; i++)
            {
                if (i % 15 == 0)
                    Console.Write("FizzBuzz,");
                else if (i % 3 == 0)
                    Console.Write("Fizz,");
                else if (i % 5 == 0)
                    Console.Write("Buzz,");
                else
                    Console.Write($"{i},");
            }
            Console.WriteLine();
        }
    }

    record FizzBuzzData(string Output, int Number);

    /// <summary>
    /// Demonstrates breaking down into steps
    /// </summary>
    static class FizzBuzzExample2
    {

        static FizzBuzzData Handle15(this FizzBuzzData data)
        {
            if (data.Output != "")
                return data; // already processed
            if (data.Number % 15 != 0)
                return data; // not applicable

            return new FizzBuzzData("FizzBuzz", data.Number);
        }

        static FizzBuzzData Handle3(this FizzBuzzData data)
        {
            if (data.Output != "")
                return data; // already processed
            if (data.Number % 3 != 0)
                return data; // not applicable

            return new FizzBuzzData("Fizz", data.Number);
        }

        static string FinalStep(this FizzBuzzData data)
        {
            if (data.Output != "")
                return data.Output; // already processed
            else
                return data.Number.ToString();
        }

        static string FizzBuzzPipeline(int i)
        {
            var result =
                new FizzBuzzData("", i)
                .Handle15()
                .Handle3()
                .FinalStep();
            return result;

        }

        public static void FizzBuzz()
        {
            var words = Enumerable
                .Range(1, 30)
                .Select(FizzBuzzPipeline);

            Console.WriteLine(string.Join(",", words));
        }


    }

    /// <summary>
    /// Demonstrates breaking down into steps
    /// </summary>
    static class FizzBuzzExample3
    {

        static string FinalStep(this FizzBuzzData data)
        {
            if (data.Output != "")
                return data.Output; // already processed
            else
                return data.Number.ToString();
        }

        /// <summary>
        /// A generic step
        /// </summary>
        static FizzBuzzData Handle(
            this FizzBuzzData data, int divisor, string output)
        {
            if (data.Output != "")
                return data; // already processed
            if (data.Number % divisor != 0)
                return data; // not applicable

            return new FizzBuzzData(output, data.Number);
        }

        static string FizzBuzzPipeline(int i)
        {
            return
                new FizzBuzzData("", i)
                .Handle(15, "FizzBuzz")
                .Handle(3, "Fizz")
                .Handle(5, "Buzz")
                .FinalStep();
        }

        public static void FizzBuzz()
        {
            var words = Enumerable
                .Range(1, 30)
                .Select(FizzBuzzPipeline);

            Console.WriteLine(string.Join(",", words));
        }

    }
}
