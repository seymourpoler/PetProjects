﻿using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public partial class ReadOnlyCollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            if (collection.IsNull())
            {
                return true;
            }
            throw new NotImplementedException();
        }
    }
}