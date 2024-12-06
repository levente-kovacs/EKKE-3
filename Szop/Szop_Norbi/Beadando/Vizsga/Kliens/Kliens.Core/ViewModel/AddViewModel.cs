using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestSharp;
using System.Text.Json;


namespace Kliens.Core
{
    public class AddViewModel : BaseViewModel
    {
        public bool LoginIsRunning { get; set; }
        public string Brand { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public string ModelYear { get; set; }
        public string NumOfCylinders { get; set; }
        public string EngineDisplacement { get; set; }
        public string Fuel { get; set; }

        public ICommand AddCommand { get; set; }

        public AddViewModel()
        {
            AddCommand = new RelayParameterizedCommand(async (parameter) => await Add(parameter));

        }

        public async Task Add(object parameter)
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
                    mYear = int.Parse(ModelYear);
                }
                catch
                {
                    MessageBox.Show("Model year must be a number");
                    return;
                }
                try
                {
                    numOfC = int.Parse(NumOfCylinders);
                }
                catch
                {
                    MessageBox.Show("Number of cylinders must be a number");
                    return;
                }
                try
                {
                    engineD = int.Parse(EngineDisplacement);
                }
                catch
                {
                    MessageBox.Show("Engine displacement must be a number");
                    return;
                }
                try
                {
                    try
                    {
                        if (Vin.Length < 17)
                            throw new Exception();
                    }
                    catch
                    {
                        
                    }
                    DbHelper.Empty(Brand);
                    DbHelper.Empty(Fuel);
                    DbHelper.Empty(Color);
                    DbHelper.Empty(Vin);
                }
                catch
                {                   
                    return;
                }

                var body = new Car { brand = Brand, vin = Vin.ToUpper(), color = Color, modelYear = mYear, numOfCylinders = numOfC, engineDisplacement = engineD, fuel = Fuel };
                request.AddHeader("token", LoginViewModel.token);
                request.AddJsonBody(body);
                response = new RestResponse();

                try
                {
                    response = client.Post(request);
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
                

            });
        }
    }
}
