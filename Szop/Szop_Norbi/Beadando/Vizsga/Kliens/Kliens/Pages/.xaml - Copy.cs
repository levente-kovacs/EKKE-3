using Kliens.Core;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class FuelPage : BasePage<FuelViewModel>
    {
        public FuelPage()
        {            
            InitializeComponent();            
        }

        private void GetData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/fuels";
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();

            try
            {
                response = client.Get(request);
                if (response.IsSuccessStatusCode == false)
                {
                    //MessageBox.Show(response.ErrorException.Message.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return;
            }
            bool working = true;
            if (working)
            {
                string reply = response.Content.ToString();
                List<Fuels> fuels = JsonSerializer.Deserialize<List<Fuels>>(reply);
                foreach (Fuels f in fuels)
                {
                    fuelList.Items.Add($"Típus: {f.type}");
                    fuelList.Items.Add($"Egységár: {f.price}");
                    fuelList.Items.Add("");
                }
            }

        }

        private void Clear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            fuelList.Items.Clear();
        }
    }
}
