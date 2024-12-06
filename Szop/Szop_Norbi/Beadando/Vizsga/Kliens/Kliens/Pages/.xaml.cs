using Kliens.Core;
using System.Collections.Generic;
using System.Windows;

namespace Kliens
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class HomePage : BasePage<HomeViewModel>
    {
        public HomePage()
        {            
            InitializeComponent();            
        }

        private void GetData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(carID.Text))
            {
                List<Car> Cars = DbHelper.CarsQuery();
                try
                {
                    foreach (Car car in Cars)
                    {
                        carList.Items.Add($"Autó ID: {car.id}");
                        carList.Items.Add($"Autó márkája: {car.brand}");
                        carList.Items.Add($"Autó alvázszáma: {car.vin}");
                        carList.Items.Add($"Autó színe: {car.color}");
                        carList.Items.Add($"Modell év: {car.modelYear}");
                        carList.Items.Add($"Hengerek száma: {car.numOfCylinders}");
                        carList.Items.Add($"Hengerürtartalom: {car.engineDisplacement}");
                        carList.Items.Add($"Tűzelöanyag típusa: {car.fuel}");
                        carList.Items.Add($"Felhasználó aki rögzítette: {car.user_id}");
                        carList.Items.Add("");
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                }
                
            }
            else
            {
                try
                {
                    Car car = DbHelper.OneCarQuery(carID.Text);
                    carList.Items.Add($"Autó ID: {car.id}");
                    carList.Items.Add($"Autó márkája: {car.brand}");
                    carList.Items.Add($"Autó alvázszáma: {car.vin}");
                    carList.Items.Add($"Autó színe: {car.color}");
                    carList.Items.Add($"Modell év: {car.modelYear}");
                    carList.Items.Add($"Hengerek száma: {car.numOfCylinders}");
                    carList.Items.Add($"Hengerürtartalom: {car.engineDisplacement}");
                    carList.Items.Add($"Tűzelöanyag típusa: {car.fuel}");
                    carList.Items.Add($"Felhasználó aki rögzítette: {car.user_id}");
                    carList.Items.Add("");
                }
                catch 
                {
                    MessageBox.Show("Something went wrong");
                }
                
            }
            
        }

        private void Clear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            carList.Items.Clear();
        }
    }
}
