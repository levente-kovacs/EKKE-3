using RestSharp;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open_API_Kliens
{
    public partial class LoginForm : Form
    {
        public static string token = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost:3100";            
            String ROUTE = "/login";
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE);
            var body = new User { username = user.Text, password = pwd.Text };
            request.AddJsonBody(body);
            var response = new RestResponse();
            

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
                        
                var reply = response.Content.ToString();
                Token tk = new Token();
                try
                {
                    tk = JsonSerializer.Deserialize<Token>(reply);
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                }
            try
            {
                token = tk.token.ToString();
                DataForm data = new DataForm();
                this.Hide();
                data.Show();
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
                        
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
