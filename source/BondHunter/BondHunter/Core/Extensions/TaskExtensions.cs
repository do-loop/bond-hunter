namespace BondHunter.Core.Extensions
{
    using System.Threading.Tasks;

    internal static class TaskExtensions
    {
        public static T WaitTask<T>(this Task<T> task)
        {
            return task
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}