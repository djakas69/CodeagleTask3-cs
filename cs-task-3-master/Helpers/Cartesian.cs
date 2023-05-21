using System.Collections;

namespace Csharp_Task_3.Helpers
{
    /// <summary>
    /// https://ericlippert.com/2010/06/28/computing-a-cartesian-product-with-linq/
    /// </summary>
    public static class Cartesian
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>
              (this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }
    }

}
