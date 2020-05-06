namespace BondHunter.Core.Helpers
{
    using System;
    using System.Threading.Tasks;
    using Exceptions;

    internal static class ExceptionHelper
    {
        public static async Task<T> WrapException<T>(Func<Task<T>> function)
        {
            try
            {
                return await function();
            }
            catch (HunterException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HunterException(ex.Message, ex);
            }
        }
    }
}