using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestSharp;
using System.Text.Json;
using System.Collections.Generic;

namespace Kliens.Core
{
    public class DelViewModel : BaseViewModel
    {
        public bool LoginIsRunning { get; set; }

        public List<string> CarID { get; set; }        

        public ICommand DelCommand { get; set; }


        public DelViewModel()
        {            
            CarID = DbHelper.IdForComboBoxWithOutNull();
            DelCommand = new RelayParameterizedCommand(async (parameter) => await Del(parameter));                                
        }
        
        
        public async Task Del(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                CarID = DbHelper.IdForComboBoxWithOutNull();
            });
        }
    }
}
