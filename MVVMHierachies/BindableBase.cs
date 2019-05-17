using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections;

namespace MVVMHierachies
{
    public class BindableBase:INotifyPropertyChanged
    {
        public bool HasErrors => throw new NotImplementedException();

        protected virtual void SetProperty<T>(ref T member, T val,[CallerMemberName] string propertyName=null)
        {
            if (object.Equals(member, val)) return;
            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged (string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}
