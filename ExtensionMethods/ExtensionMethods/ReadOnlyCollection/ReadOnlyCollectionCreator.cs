using System.Collections.ObjectModel;

namespace ExtensionMethods.ReadOnlyCollection
{
    public static class ReadOnlyCollectionCreator
    {
        public static ReadOnlyCollection<T> Of<T>(params T[] values)
        {
            return new ReadOnlyCollection<T>(values);
        }
    }
}