using csharpdemo.ExtensionMethods;

namespace csharpdemo
{

    /// <summary>
    /// Shows two ways of doing a calculation
    /// </summary>
    public static class CalculationExample
    {
        // using a pipe when functions have exactly one parameter
        static int Add1(int input) { return input + 1; }
        static int Square(int input) { return input * input; }
        static int Double(int input) { return input * 2; }

        public static int NestedCalls()
        {
            return Double(Square(Add1(5)));
        }

        /// <summary>
        /// Example of a horizontal pipeline
        /// </summary>
        public static int HorizontalPipeline()
        {
            return 5.Pipe(Add1).Pipe(Square).Pipe(Double);
        }

        /// <summary>
        /// Example of a vertical pipeline
        /// </summary>
        public static int VerticalPipeline()
        {
            return 5
                .Pipe(Add1)
                .Pipe(Square)
                .Pipe(Double);
        }

        // using a pipe when functions have more than one parameter
        static int Add(int i, int j) { return i + j; }
        static int Times(int i, int j) { return i * j; }

        public static int PipelineWithParams()
        {
            return 5
                .Pipe(Add, 1)
                .Pipe(Times, 2);
        }


    }
}
