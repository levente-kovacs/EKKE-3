using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restapi3
{
    public partial class Form1 : Form
    {

        String URL = "http://aries.ektf.hu/~ksanyi/restapi/v1/";
        String ROUTE = "index.php";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.GET);

            IRestResponse<List<Employee>> response = client.Execute<List<Employee>>(request);
            foreach (Employee emp in response.Data)
            {
                listBox1.Items.Add(emp.Id+" "+emp.employee_name);   
            }
            
            //var content = response.Content;
            //textBox1.Text = content;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = "index.php"+"?id="+textBox2.Text;
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            textBox1.Text = content;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.POST);  //index is kellett mögé
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Employee
            {
                employee_name = "Kanga",
                employee_age = 101,
                employee_salary = 20000
            });
            IRestResponse response = client.Execute(request);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = "index.php/{id}";
            var request = new RestRequest(ROUTE, Method.DELETE);
            request.AddParameter("id", textBox2.Text);
            IRestResponse response = client.Execute(request);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Employee
    {
        public String Id { get; set; }
        public string employee_name { get; set; }
        public decimal employee_salary { get; set; }
        public decimal employee_age { get; set; }
    }

}
