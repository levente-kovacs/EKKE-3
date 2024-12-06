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
    public class UpdViewModel : BaseViewModel
    {
        public bool LoginIsRunning { get; set; }

        public string UpdId { get; set; }
        public string UpdBrand { get; set; }
        public string UpdVin { get; set; }
        public string UpdColor { get; set; }
        public string UpdModelYear { get; set; }
        public string UpdNumOfCylinders { get; set; }
        public string UpdEngineDisplacement { get; set; }
        public string UpdFuel { get; set; }

        public List<string> CarID { get; set; }        

        public ICommand UpdCommand { get; set; }


        public UpdViewModel()
        {            
            CarID = DbHelper.IdForComboBoxWithOutNull();
            UpdCommand = new RelayParameterizedCommand(async (parameter) => await Upd(parameter));                                
        }
        
        
        public async Task Upd(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                
                String URL = "http://localhost:3100";
                String ROUTE = "/car";
                var client = new RestClient(URL);
                var request = new RestRequest(ROUTE);
                var response = new RestResponse();

                int mYear = 0;
                int numOfC = 0;
                int engineD = 0;
                try
                {
                    mYear = int.Parse(UpdModelYear);
                    numOfC = int.Parse(UpdNumOfCylinders);
                    engineD = int.Parse(UpdEngineDisplacement);
                }
                catch
                {

                    return;
                }
                try
                {
                    try
                    {
                        if (UpdVin.Length < 17)
                            throw new Exception();
                    }
                    catch
                    {

                    }
                    DbHelper.Empty(UpdBrand);
                    DbHelper.Empty(UpdFuel);
                    DbHelper.Empty(UpdColor);
                    DbHelper.Empty(UpdVin);
                }
                catch
                {
                    return;
                }

                var body = new Car { brand = UpdBrand, vin = UpdVin.ToUpper(), color = UpdColor, modelYear = mYear, numOfCylinders = numOfC, engineDisplacement = engineD, fuel = UpdFuel };
                request.AddHeader("token", LoginViewModel.token);
                request.AddJsonBody(body);
                response = new RestResponse();

                try
                {
                    response = client.Put(request);
                    if (response.IsSuccessStatusCode == false)
                    {

                        return;
                    }
                }
                catch (Exception ex)
                {

                    return;
                }


            });
        }
    }
}
