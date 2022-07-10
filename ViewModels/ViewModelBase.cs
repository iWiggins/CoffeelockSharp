using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoffeelockSharp.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected void RaisePropertyChanged(string property)
        {
            ((IReactiveObject)this).RaisePropertyChanged(new PropertyChangedEventArgs(property));
        }
    }
}
