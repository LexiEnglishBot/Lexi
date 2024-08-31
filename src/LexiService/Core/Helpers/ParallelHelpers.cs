using System.Collections.Concurrent;

namespace Core.Helpers;

public static class ParallelHelpers
{
    public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> body, int degreeOfParallelization = 100)
    {
        return Task.WhenAll(
            Partitioner
                .Create(source)
                .GetPartitions(degreeOfParallelization)
                .AsParallel()
                .Select(AwaitPartition));

        async Task AwaitPartition(IEnumerator<T> partition)
        {
            using (partition)
            {
                while (partition.MoveNext())
                {
                    await body(partition.Current);
                }
            }
        }
    }
}