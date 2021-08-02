﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjectCallerAssemblyContextualBinding
{
    internal static class Extensions
    {
        internal static bool IsNotContextualInterface(this Type type, Type notContextualInterface)
            => type.IsAssignableFrom(notContextualInterface) || type.GetInterfaces().Any(x => x.IsAssignableFrom(notContextualInterface));

        internal static bool HasData<T>(this IEnumerable<T> data)
            => data is not null && data.Any();

        internal static bool HasValue(this string input)
           => !string.IsNullOrWhiteSpace(input);
    }
}
