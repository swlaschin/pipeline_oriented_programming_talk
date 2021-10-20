using System;

namespace csharpdemo.ExtensionMethods
{
    public static class PipeExtensions
    {
        public static TOut Pipe<TIn, TOut>
            (this TIn input, Func<TIn, TOut> fn)
        {
            return fn(input);
        }

        public static TOut Pipe<TIn, TParam, TOut>
            (this TIn input, Func<TIn, TParam, TOut> fn, TParam p1)
        {
            return fn(input, p1);
        }
    }
}
