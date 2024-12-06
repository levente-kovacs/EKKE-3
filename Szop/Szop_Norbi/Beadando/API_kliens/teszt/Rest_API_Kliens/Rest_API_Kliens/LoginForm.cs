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

namespace Rest_API_Kliens
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
        
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            String URL = "http://localhost/API/index.php";
            var client = new RestClient(URL);
                String ROUTE = "index.php" + "?users=login";
                var request = new RestRequest(ROUTE);
                var body = new User { username = user.Text, password = pwd.Text };
                request.AddJsonBody(body);
                var response = new RestResponse();
            bool login = false;

                try
                {
                    response = client.Post(request);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                        return;
                    
                }
            login = true;
            if (login)
            {
                string reply = response.Content.ToString();
                Token tkn = new Token();
                try
                {
                    tkn = JsonSerializer.Deserialize<Token>(reply);
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                }
                
                token = tkn.token.ToString();
                DataForm data = new DataForm();
                this.Hide();
                data.Show();
            }             
        }
        
    }
}
