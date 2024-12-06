using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

namespace Open_API_Kliens
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
            IdForComboBox(carById);
            IdForComboBox(updId);
            IdForComboBox(deleteById);
            newFuel.DataSource = Enum.GetValues(typeof(Fuel));
            updFuel.DataSource = Enum.GetValues(typeof(Fuel));
        }
        private void IdForComboBox(ComboBox id)
        {
            id.Items.Clear();
            String URL = "http://localhost:3100";
            String ROUTE = "/cars";
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();
            bool working = false;

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
            working = true;
            if (working)
            {
                string reply = response.Content.ToString();
                List<Car> cars = JsonSerializer.Deserialize<List<Car>>(reply);
                foreach (Car c in cars)
                {
                    id.Items.Add(c.id.ToString());
                }
            }
        }
        private bool Empty(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new Exception();
            return false;
        }
        private void DataForm_Load(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            LoginForm.token = null;
            login.Show();
            this.Close();
        }

        private void carsFromDb_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/cars";
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
            bool working = true;
            if (working)
            {
                string reply = response.Content.ToString();
                List<Car> cars = JsonSerializer.Deserialize<List<Car>>(reply);
                foreach (Car c in cars)
                {
                    adatok.Items.Add($"Autó ID: {c.id}");
                    adatok.Items.Add($"Autó márkája: {c.brand}");
                    adatok.Items.Add($"Autó alvázszáma: {c.vin}");
                    adatok.Items.Add($"Autó színe: {c.color}");
                    adatok.Items.Add($"Modell év: {c.modelYear}");
                    adatok.Items.Add($"Hengerek száma: {c.numOfCylinders}");
                    adatok.Items.Add($"Hengerürtartalom: {c.engineDisplacement}");
                    adatok.Items.Add($"Tűzelöanyag típusa: {c.fuel}");
                    adatok.Items.Add($"Felhasználó aki rögzítette: {c.user_id}");
                    adatok.Items.Add("");
                }
            }
        }

        private void carFromDbById_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/cars/"+carById.Text;
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();
            int id = 0;
            try
            {
                id = int.Parse(carById.Text);
            }
            catch
            {
                MessageBox.Show("Please select an ID");
                return;
            }
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

            string reply = response.Content.ToString();
            Car car = new Car();
            try
            {
                car = JsonSerializer.Deserialize<Car>(reply);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            adatok.Items.Add($"Autó ID: {car.id}");
            adatok.Items.Add($"Autó márkája: {car.brand}");
            adatok.Items.Add($"Autó alvázszáma: {car.vin}");
            adatok.Items.Add($"Autó színe: {car.color}");
            adatok.Items.Add($"Modell éve: {car.modelYear}");
            adatok.Items.Add($"Hengerek száma: {car.numOfCylinders}");
            adatok.Items.Add($"Hengerürtartalom: {car.engineDisplacement}");
            adatok.Items.Add($"Tűzelöanyag típusa: {car.fuel}");
            adatok.Items.Add($"Felhasználó aki rögzítette: {car.user_id}");
            adatok.Items.Add("");
        }

        private void newCar_Click(object sender, EventArgs e)
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
                mYear = int.Parse(newModelYear.Text);
                numOfC = int.Parse(newNumOfCylinders.Text);
                engineD = int.Parse(newEngingeDisplacement.Text);
            }
            catch
            {
                MessageBox.Show("Please write only positive intiger number");
                return;
            }
            try
            {
                try
                {
                    if (newVin.Text.Length < 17)
                        throw new Exception();
                }
                catch
                {
                    MessageBox.Show("VIN length must be 17");
                }                
                Empty(newBrand.Text);
                Empty(newVin.Text);
                Empty(newColor.Text);              
            }
            catch
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            var body = new Car { brand = newBrand.Text, vin = newVin.Text.ToUpper(), color = newColor.Text, modelYear = mYear, numOfCylinders = numOfC, engineDisplacement = engineD, fuel = newFuel.Text };
            request.AddHeader("token", LoginForm.token);
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
            IdForComboBox(carById);
            IdForComboBox(updId);
            IdForComboBox(deleteById);
            MessageBox.Show(response.Content.ToString());
        }

        private void clearAdatok_Click(object sender, EventArgs e)
        {
            adatok.Items.Clear();
            Fuel.Items.Clear();
        }

        private void updId_DropDownClosed(object sender, EventArgs e)
        {
            
            String URL = "http://localhost:3100";
            String ROUTE = "/cars/"+updId.Text;
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();
            int id = 0;
            
            try
            {
                if (String.IsNullOrWhiteSpace(updId.Text))
                    return;
                id = int.Parse(updId.Text);                
            }
            catch
            {
                MessageBox.Show("Please write ids from the database");
                return;
            }
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

            string reply = response.Content.ToString();
            Car car = new Car();
            try
            {
                car = JsonSerializer.Deserialize<Car>(reply);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            updBrand.Text = car.brand.ToString();
            updVin.Text = car.vin.ToString();
            updColor.Text=car.color.ToString();
            updModelYear.Text = car.modelYear.ToString();
            updNumOfCylinders.Text = car.numOfCylinders.ToString();
            updEngineDisplacement.Text = car.engineDisplacement.ToString();
            updFuel.Text = car.fuel.ToString();            
            
        }

        private void updCar_Click(object sender, EventArgs e)
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
                mYear = int.Parse(updModelYear.Text);
                numOfC = int.Parse(updNumOfCylinders.Text);
                engineD = int.Parse(updEngineDisplacement.Text);
                uId = int.Parse(updId.Text);
            }
            catch
            {
                MessageBox.Show("Please select an ID");
                return;
            }

            try
            {
                try
                {
                    if (updVin.Text.Length < 17)
                        throw new Exception();
                }
                catch
                {
                    MessageBox.Show("VIN length must be 17");
                }
                Empty(updBrand.Text);
                Empty(updVin.Text);
                Empty(updColor.Text);
            }
            catch
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            var body = new Car { id=uId, brand = updBrand.Text, vin = updVin.Text.ToUpper(), color = updColor.Text, modelYear = mYear, numOfCylinders = numOfC, engineDisplacement = engineD, fuel = updFuel.Text };
            request.AddHeader("token", LoginForm.token);
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

        private void deleteById_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/cars/" + deleteById.Text;
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            request.AddHeader("token", LoginForm.token);
            var response = new RestResponse();
            int udelete = 0;
            try
            {
                udelete = int.Parse(deleteById.Text);
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
            MessageBox.Show(response.Content.ToString());
            IdForComboBox(carById);
            IdForComboBox(updId);
            IdForComboBox(deleteById);
        }

        private void getFuels_Click(object sender, EventArgs e)
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
                    MessageBox.Show(response.ErrorException.Message.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            bool working = true;
            if (working)
            {
                string reply = response.Content.ToString();
                List<Fuels> fuels = JsonSerializer.Deserialize<List<Fuels>>(reply);
                foreach (Fuels f in fuels)
                {
                    Fuel.Items.Add($"Típus: {f.type}");
                    Fuel.Items.Add($"Egységár: {f.price}");
                    Fuel.Items.Add("");
                }
            }
        }
    }    
}
