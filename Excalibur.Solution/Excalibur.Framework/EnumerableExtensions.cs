﻿using System;
using System.Collections.Generic;

namespace Excalibur.Framework
{
    static class EnumerableExtensions
    {
        public static void Apply<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
    }
}
