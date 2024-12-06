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
    public class FuelViewModel : BaseViewModel
    {
       public ICommand HomeCommand { get; set; }

        public ICommand teszt { get; set; }

        public List<Car> Cars { get; set; }

        public List<string> CarID { get; set; }


       
        public FuelViewModel()
        {            
            CarID = DbHelper.IdForComboBox();
        }       
        
    }
}
