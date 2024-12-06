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
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }    

        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; set; }

        public static string token = "";
       
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }
        
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {


                await Task.Delay(1000);

                String URL = "http://localhost:3100";
                String ROUTE = "/login";
                var client = new RestClient(URL);
                var request = new RestRequest(ROUTE);
                var body = new User { username = Username, password = (parameter as IHavePassword).SecurePassword.Unsecure() };
                request.AddJsonBody(body);
                var response = new RestResponse();
                bool canLogin = false;
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
                    canLogin = true;
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                }
                if (!canLogin)
                    return;
                else
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Home);

                (parameter as IHavePassword).SecurePassword.Unsecure();

            });                
        }
    }
}
