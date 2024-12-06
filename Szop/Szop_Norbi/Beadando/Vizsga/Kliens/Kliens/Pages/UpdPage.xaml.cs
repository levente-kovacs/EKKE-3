using Kliens.Core;
using RestSharp;
using System;
using System.Windows;

namespace Kliens
{
    public partial class UpdPage : BasePage<UpdViewModel>
    {
        public UpdPage()
        {
            InitializeComponent();
        }

        private void Upd_Closed(object sender, System.EventArgs e)
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
                Brand.Text = "Brand";
                Vin.Text = "Vin";
                Color.Text = "Color";
                ModelYear.Text = "ModelYear";
                NumOfCylinders.Text = "NumOfCylinders";
                EngineDisplacement.Text = "EngineDisplacement";
                Fuel.Text = "Benzin";
            }
        }

        private void Upd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/car";
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();

            int mYear = 0;
            int numOfC = 0;
            int engineD = 0;
            int uId = 0;
            try
            {
                mYear = int.Parse(ModelYear.Text);                
            }
            catch
            {
                MessageBox.Show("Model year must be a number");
                return;
            }
            try
            {
                numOfC = int.Parse(NumOfCylinders.Text);                
            }
            catch
            {
                MessageBox.Show("Number of cylinders must be a number");
                return;
            }
            try
            {
                engineD = int.Parse(EngineDisplacement.Text);                
            }
            catch
            {
                MessageBox.Show("Engine displacement must be a number");
                return;
            }
            try
            {
                uId = int.Parse(carId.Text);
            }
            catch
            {
                MessageBox.Show("Id must be a number");
                return;
            }

            try
            {
                try
                {
                    if (Vin.Text.Length < 17)
                        throw new Exception();
                }
                catch
                {
                    MessageBox.Show("VIN length must be 17");
                    return;
                }
                Empty(Brand.Text);
                Empty(Vin.Text);
                Empty(Color.Text);
            }
            catch
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            var body = new Car { id = uId, brand = Brand.Text, vin = Vin.Text.ToUpper(), color = Color.Text, modelYear = mYear, numOfCylinders = numOfC, engineDisplacement = engineD, fuel = Fuel.Text };
            request.AddHeader("token", LoginViewModel.token);
            request.AddJsonBody(body);
            try
            {
                response = client.Put(request);
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
            MessageBox.Show(response.Content.ToString());
        }
        private bool Empty(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new Exception();
            return false;
        }
    }
}
