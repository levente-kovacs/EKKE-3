using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kliens.Core
{
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender,e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        protected async Task RunCommand(Expression<Func<bool>> updateingFlag,Func<Task> action)
        {
            if (updateingFlag.GetPropertyValue())
                return;

            updateingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                updateingFlag.SetPropertyValue(false);
            }

        }




    }
}
