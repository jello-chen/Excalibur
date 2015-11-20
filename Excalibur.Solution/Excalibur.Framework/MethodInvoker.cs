using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Framework
{
    public static class MethodInvoker
    {
        public static void Invoke<TObject, TEventArgs>(this MethodInfo method, object viewModel,
            TObject sender, TEventArgs e) where TEventArgs : EventArgs
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
            var parms = method.GetParameters();
            if (parms.Length == 2)
            {
                if (parms[0].ParameterType == typeof(object))
                {
                    if (parms[1].ParameterType == typeof(EventArgs))
                    {
                        method.Invoke(viewModel, new object[] { sender, e });
                    }
                    else
                    {
                        method.Invoke(viewModel, new object[] { sender, null });
                    }
                }
            }
            else if (parms.Length == 1)
            {
                if (parms[0].ParameterType == typeof(object))
                {
                    method.Invoke(viewModel, new object[] { sender });
                }
                else
                {
                    method.Invoke(viewModel, new object[] { null });
                }
            }
            else if (parms.Length == 0)
            {
                method.Invoke(viewModel, null);
            }
        }
    }
}
