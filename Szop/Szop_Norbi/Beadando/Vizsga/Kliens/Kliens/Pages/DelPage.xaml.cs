using Kliens.Core;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Kliens
{
    public partial class DelPage : BasePage<DelViewModel>
    {
        public DelPage()
        {
            InitializeComponent();
        }

        private void Del_Closed(object sender, System.EventArgs e)
        {
            Car temp;
            try
            {
                temp = DbHelper.OneCarQuery(carId.Text);
                if (temp == null)
                    return;
                Brand.Text = temp.brand;
                Vin.Text = temp.vin;
                Color.Text = temp.color;
                ModelYear.Text = temp.modelYear.ToString();
                NumOfCylinders.Text = temp.numOfCylinders.ToString();
                EngineDisplacement.Text = temp.engineDisplacement.ToString();
                Fuel.Text = temp.fuel;
            }
            catch
            {

            }
            
        }
        
        private bool Empty(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new Exception();
            return false;
        }

        private void Del_click(object sender, System.Windows.RoutedEventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/cars/" + carId.Text;
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            request.AddHeader("token", LoginViewModel.token);
            var response = new RestResponse();
            int udelete = 0;
            try
            {
                udelete = int.Parse(carId.Text);
            }
            catch
            {
                MessageBox.Show("Please select an ID");
                return;
            }
            try
            {
                response = client.Delete(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }        
    }
}
