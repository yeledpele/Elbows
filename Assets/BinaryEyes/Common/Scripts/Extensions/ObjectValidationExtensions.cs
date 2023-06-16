using System;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// Provides common (object) validation extensions.
    /// </summary>
    public static class ObjectValidationExtensions
    {
        public static T ThrowIfNull<T>(this T entry) where T : class
        {
            return entry.ThrowIfNull($"expected object of {typeof(T).Name} but entry was null");
        }

        public static T ThrowIfNull<T>(this T entry, string message) where T : class
        {
            if (entry == null)
                throw new NullReferenceException(message);

            return entry;
        }
    }
}
