using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excalibur.Framework.Binders
{
    public class DataGridViewBinder:Binder<DataGridView>
    {
        protected override void BindCore(Lifetime lifetime, DataGridView ctl, object viewModel)
        {
            var properties = TypeDescriptor.GetProperties(viewModel)
                .OfType<PropertyDescriptor>()
                .ToLookup(x => x.Name, x => x)
                ;

            var dataSourceProperty = properties[ctl.Name].FirstOrDefault();
            if (dataSourceProperty != null && typeof(IEnumerable).IsAssignableFrom(dataSourceProperty.PropertyType))
            {
                lifetime.Add(CreateBinding(ctl, "DataSource", viewModel, dataSourceProperty.Name));
            }

            var vmType = TypeDescriptor.GetReflectionType(viewModel);
            var selectedChangedEventHandler = vmType.GetMethod(ctl.Name + "_SelectedChanged");
            if (selectedChangedEventHandler != null)
            {
                EventHandler selectionChanged = (s, e) =>
                {
                    selectedChangedEventHandler.Invoke<object, EventArgs>(viewModel, s, e);
                };
                ctl.SelectionChanged += selectionChanged;
                lifetime.Add(Disposable.Create(() => ctl.SelectionChanged -= selectionChanged));
            }
        }
    }
}
