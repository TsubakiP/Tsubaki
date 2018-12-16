
namespace Tsubaki.Utilities.Serialization
{
    internal static class SerializerHelper
    {
        public static T Default<T>()
            => default(T);

        public static string Default()
            => string.Empty;
    }
}

