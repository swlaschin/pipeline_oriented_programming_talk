using System;

namespace csharpdemo
{
    class Program
    {
        static void Main()
        {
            FizzBuzzExample1.FizzBuzz();
            FizzBuzzExample2.FizzBuzz();
            FizzBuzzExample3.FizzBuzz();

            var i = CalculationExample.NestedCalls();
            Console.WriteLine($"NestedCalls {i}");

            i = CalculationExample.HorizontalPipeline();
            Console.WriteLine($"Pipeline {i}");

            i = CalculationExample.VerticalPipeline();
            Console.WriteLine($"Pipeline2 {i}");

            i = CalculationExample.PipelineWithParams();
            Console.Write($"Pipeline3 {i}");
        }
    }
}


