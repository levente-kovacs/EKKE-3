using RestSharp;
using System.Text.Json;
using System.Collections.Generic;
using System;
using System.Windows;

namespace Kliens.Core
{
    public static class DbHelper
    {     
        public static List<string> IdForComboBox()
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
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }

            List<string> list = new List<string>();
           
           string reply = response.Content.ToString();
           List<Car> cars = JsonSerializer.Deserialize<List<Car>>(reply);
            list.Add("");
           foreach (Car car in cars)
            {
                list.Add(car.id.ToString());
            }
           return list;
        }

        public static List<string> IdForComboBoxWithOutNull()
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
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }

            List<string> list = new List<string>();

            string reply = response.Content.ToString();
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(reply);            
            foreach (Car car in cars)
            {
                list.Add(car.id.ToString());
            }
            return list;
        }

        public static List<Car> CarsQuery()
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
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }

            List<Car> list = new List<Car>();

            string reply = response.Content.ToString();
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(reply);

            foreach (Car car in cars)
            {
                list.Add(car);
            }
            return list;
        }

        public static Car OneCarQuery(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            String URL = "http://localhost:3100";
            String ROUTE = "/cars/" + id;
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();
            try
            {
                response = client.Get(request);

                if (response.IsSuccessStatusCode == false)
                {
                    MessageBox.Show(response.ErrorException.Message.ToString());
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }
            string reply = response.Content.ToString();
            Car car = new Car();

            car = JsonSerializer.Deserialize<Car>(reply);


            return car;
        }

        public static bool Empty(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new Exception();
            return false;
        }
    }
    
}
