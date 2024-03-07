namespace AzureFunctionExample.Domain.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Determines whether the specified obj is null.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        ///   <c>true</c> if the specified obj is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Determines whether the specified obj is NOT null.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        ///   <c>false</c> if the specified obj is NOT null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }
    }
}
