using csharpdemo.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpdemo
{
    /// <summary>
    /// Demonstrates two ways of processing a collection
    /// </summary>
    static class CollectionExample
    {
        /// <summary>
        /// Using a for loop
        /// </summary>
        static int LoopStyle(List<int> list)
        {
            var count = 0;
            foreach (var i in list)
            {
                var j = i + 2;
                if (j > 3)
                {
                    count++;
                }
            }
            return count;
        }


        /// <summary>
        /// Using a LINQ pipeline
        /// </summary>
        static int LinqStyle(List<int> list)
        {
            return list
                .Select(x => x + 2)
                .Where(x => x > 3)
                .Count();
        }

        /// <summary>
        /// Using a LINQ pipeline with a "strategy" parameter
        /// </summary>
        static int StrategyPattern(List<int> list, Func<IEnumerable<int>, IEnumerable<int>> injectedFn)
        {
            return list
                .Select(x => x + 2)
                // .injectedFn
                .Where(x => x > 3)
                .Count();
        }

        /// <summary>
        /// Using a LINQ pipeline with a "strategy" parameter
        /// </summary>
        static int StrategyPattern2(List<int> list, Func<IEnumerable<int>, IEnumerable<int>> injectedFn)
        {
            return list
                .Select(x => x + 2)
                .Pipe(injectedFn)
                .Where(x => x > 3)
                .Count();
        }

    }
}
