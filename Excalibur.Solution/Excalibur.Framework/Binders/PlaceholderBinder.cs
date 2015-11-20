using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excalibur.Framework.Controls;
using System.ComponentModel;

namespace Excalibur.Framework.Binders
{
    public class PlaceholderBinder : Binder<Placeholder>
    {
        protected override void BindCore(Lifetime lifetime, Placeholder ctl, object viewModel)
        {
            var properties = TypeDescriptor.GetProperties(viewModel)
                .OfType<PropertyDescriptor>()
                .ToLookup(x => x.Name);

            var placeholderProp = properties[ctl.Name].FirstOrDefault();

            if (placeholderProp != null)
            {
                lifetime.Add(CreateBinding(ctl, "ViewModel", viewModel, placeholderProp.Name));
            }
        }
    }
}
