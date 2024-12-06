using Kliens.Core;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Kliens
{
    public partial class DocPage : BasePage<DocViewModel>
    {
        public DocPage()
        {
            InitializeComponent();
        }

        private void Get_Data(object sender, System.Windows.RoutedEventArgs e)
        {
            String URL = "http://localhost:3100";
            String ROUTE = "/swagger";
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
            docList.Items.Add(response.Content.ToString());
            

             
        }

        private void Clear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            docList.Items.Clear();
        }
    }
}
