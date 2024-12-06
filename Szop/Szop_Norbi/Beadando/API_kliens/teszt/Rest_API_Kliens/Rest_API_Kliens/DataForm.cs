using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Rest_API_Kliens
{
    public partial class DataForm : Form
    {        
        public DataForm()
        {
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }
        
        private void delete_TextChanged(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void adatok_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void productsFromDb_Click(object sender, EventArgs e)
        {
         String URL = "http://localhost/API/index.php";
         var client = new RestClient(URL);
         String ROUTE = "index.php"+"?products";
         var request = new RestRequest(ROUTE);            
         var response = new RestResponse();
         bool working = false;
         
         try
         {
             response = client.Get(request);
         
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
             List<Products>  products= JsonSerializer.Deserialize<List<Products>>(reply);
             foreach (Products p in products)
             {
                    adatok.Items.Add($"Termék ID: {p.id}");
                    adatok.Items.Add($"Termék megnevezése: {p.name}");
                    adatok.Items.Add($"Termék ára: {p.price}");
                    adatok.Items.Add($"Termék mennyiség: {p.stock}");
                    adatok.Items.Add($"Ki rögzítette: {p.user_id}");
                    adatok.Items.Add("");
             }
         }
        }

        private void productFromDbByID_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost/API/index.php";
            var client = new RestClient(URL);
            String ROUTE = "index.php?products="+productById.Text;
            var request = new RestRequest(ROUTE);
            var response = new RestResponse();
            int id = 0;
            try
            {
                id = int.Parse(productById.Text);
            }
            catch
            {
                MessageBox.Show("Please write only positive intiger number");
                return;
            }
            try
            {
                response = client.Get(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

                string reply = response.Content.ToString();
                Products product = new Products();
                try
                {
                    product = JsonSerializer.Deserialize<Products>(reply);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }                           
                    adatok.Items.Add($"Termék ID: {product.id}");
                    adatok.Items.Add($"Termék megnevezése: {product.name}");
                    adatok.Items.Add($"Termék ára: {product.price}");
                    adatok.Items.Add($"Termék mennyiség: {product.stock}");
                    adatok.Items.Add($"Ki rögzítette: {product.user_id}");
                    adatok.Items.Add("");               
            
        }

        private void productDelete_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost/API/index.php";
            var client = new RestClient(URL);
            int udelete = 0;            
           try
           {
              udelete = int.Parse(delete.Text);              
               
           }
           catch
           {
               MessageBox.Show("Please write only positive intiger number");
                return;
           }
            String ROUTE = "index.php?"+ udelete;
            var request = new RestRequest(ROUTE);
            request.AddHeader("token", LoginForm.token);
            request.AddParameter("id",delete.Text);            
            var response = new RestResponse();           

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
        }

        private void newProduct_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost/API/index.php";
            var client = new RestClient(URL);
            String ROUTE = "index.php" + "?product";
            var request = new RestRequest(ROUTE);
            
            int nprice = 0;
            int nstock = 0;
            try
            {
                nprice = int.Parse(price.Text);
                nstock = int.Parse(stock.Text);
            }
            catch
            {
                MessageBox.Show("Please write only positive intiger number");
                return;
            }
            try
            {
                Empty(name.Text);
            }
            catch
            {
                MessageBox.Show("Please fill the \"Megnevezés\" field");
                return;
            }
            var body = new Products { name = name.Text, price = nprice, stock = nstock };
            request.AddHeader("token",LoginForm.token);            
            request.AddJsonBody(body);
            var response = new RestResponse();            

            try
            {
                response = client.Post(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show(response.Content.ToString());
        }

        private void update_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost/API/index.php";
            var client = new RestClient(URL);           
            String ROUTE = "index.php?" + updateID;
            var request = new RestRequest(ROUTE);            
            var response = new RestResponse();
            int uPrice = 0;
            int uStock = 0;
            int uId = 0;
            try
            {
                uPrice = int.Parse(newPrice.Text);
                uStock = int.Parse(newStock.Text);
                uId = int.Parse(updateID.Text);
            }
            catch
            {
                MessageBox.Show("Please write only positive intiger number");
                return;
            }
            
            try
            {
                Empty(newName.Text);
            }
            catch
            {
                MessageBox.Show("Please fill the \"Új megnevezés\" field");
                return;
            }
            var body = new Products {id=uId,name = newName.Text, price = uPrice, stock = uStock };
            request.AddHeader("token", LoginForm.token);            
            request.AddJsonBody(body);
            try
            {
                response = client.Put(request);
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

        private void productById_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

