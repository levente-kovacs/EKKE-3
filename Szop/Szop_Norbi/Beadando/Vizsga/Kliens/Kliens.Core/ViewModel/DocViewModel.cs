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
    public class DocViewModel : BaseViewModel
    {
        public bool LoginIsRunning { get; set; }
             
        public string Document { get; set; }
        public ICommand DocCommand { get; set; }

        public DocViewModel()
        {            
            
            DocCommand = new RelayParameterizedCommand(async (parameter) => await Get_Doc(parameter));                                
        }
        
        
        public async Task Get_Doc(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                String URL = "http://localhost:3100";
                String ROUTE = "/swagger";
                var client = new RestClient(URL);
                var request = new RestRequest(ROUTE);
                var response = new RestResponse();

                try
                {
                    response = client.Get(request);
                    if (response.IsSuccessStatusCode == false)
                    {
                        MessageBox.Show(response.ErrorException.Message.ToString());
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Document = response.Content.ToString();
                
            });
        }
    }
}
