using System;

namespace csharpdemo
{
    class Program
    {
        static void Main()
        {
            FizzBuzzClassicExample.FizzBuzz();
            FizzBuzzPipelineExample.FizzBuzz();

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


