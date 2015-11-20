using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Excalibur.Framework.Binders
{
    public class TextBoxBinder : Binder<TextBox>
    {
        protected override void BindCore(Lifetime lifetime, TextBox ctl, object viewModel)
        {
            var properties = TypeDescriptor.GetProperties(viewModel)
                .OfType<PropertyDescriptor>()
                .ToLookup(x => x.Name, x => x)
                ;

            var textProperty = properties[ctl.Name].FirstOrDefault();
            if (textProperty != null && textProperty.PropertyType == typeof(string))
            {
                lifetime.Add(CreateBinding(ctl, "Text", viewModel, textProperty.Name));
            }
            else
            {
                if (ctl.Name.Contains("_"))
                {
                    var modelName = ctl.Name.Split('_')[0];
                    var modelProp = properties[modelName].FirstOrDefault();
                    if (modelProp != null)
                    {
                        lifetime.Add(CreateBinding(ctl, "Text", viewModel, ctl.Name.Replace('_', '.')));
                    }
                }
            }
        }
    }
}
