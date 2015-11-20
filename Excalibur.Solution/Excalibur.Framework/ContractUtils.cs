using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Framework
{
    internal static class ContractUtils
    {

        internal static Exception Unreachable
        {
            get
            {
                Debug.Assert(false, "Unreachable");
                return new InvalidOperationException("Code supposed to be unreachable");
            }
        }

        internal static void Requires(bool precondition, string paramName)
        {
            Debug.Assert(!string.IsNullOrEmpty(paramName));

            if (!precondition)
            {
                throw new ArgumentException("Invalid argument value:" + paramName);
            }
        }

        internal static void RequiresNotNull(object value, string paramName)
        {
            Debug.Assert(!string.IsNullOrEmpty(paramName));

            if (value == null)
            {
                throw new ArgumentNullException("Argument is null,value:" + paramName);
            }
        }

        internal static void RequiresNotEmpty<T>(ICollection<T> collection, string paramName)
        {
            RequiresNotNull(collection, paramName);
            if (collection.Count == 0)
            {
                throw new ArgumentException("Argument is empty,value:" + paramName);
            }
        }
    }
}
