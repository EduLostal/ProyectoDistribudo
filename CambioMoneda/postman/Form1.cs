using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace postman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("POST");
            comboBox1.Items.Add("GET");
            comboBox1.Items.Add("PUT");
            comboBox1.Items.Add("DELETE");
            comboBox1.SelectedItem = "POST";

        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            
            
            if (comboBox1.SelectedItem.ToString() == "POST")
            {
                var request = new HttpRequestMessage(HttpMethod.Post, textBox9.Text);
                var content = new StringContent("{\r\n    \"MonedaDestino\" : \"" + textBox2.Text + "\",\r\n\r\n    \"MonedaOrigen\" : \"" + textBox1.Text + "\",\r\n\r\n     \"Moneda\" : " + textBox3.Text + "\r\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                textBox7.Text = await response.Content.ReadAsStringAsync();

            }
            else if (comboBox1.SelectedItem.ToString() == "GET") 
            {
                string url = textBox9.Text;
                char lastChar = url[url.Length - 1];

                if (Char.IsDigit(lastChar)) 
                {



                    var request = new HttpRequestMessage(HttpMethod.Get, textBox9.Text);

                    textBox7.Text = textBox9.Text;
                    var content = new StringContent("{\r\n    \"MonedaDestino\" : \"" + textBox2.Text + "\",\r\n\r\n    \"MonedaOrigen\" : \"" + textBox1.Text + "\",\r\n\r\n     \"Moneda\" : " + textBox3.Text + "\r\n}", Encoding.UTF8, "application/json");
                    request.Content = content;

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    textBox7.Text = await response.Content.ReadAsStringAsync();

                }
                else
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, textBox9.Text);
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    textBox7.Text = await response.Content.ReadAsStringAsync();
                } 
                                        
            }
            else if (comboBox1.SelectedItem.ToString() == "PUT")
             {


                var request = new HttpRequestMessage(HttpMethod.Put, textBox9.Text);
                var content = new StringContent("{\r\n    \"MonedaDestino\" : \"" + textBox2.Text + "\",\r\n\r\n    \"MonedaOrigen\" : \"" + textBox1.Text + "\",\r\n\r\n     \"Moneda\" : " + textBox3.Text + "\r\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                

                textBox7.Text = await response.Content.ReadAsStringAsync();

             }else if (comboBox1.SelectedItem.ToString() == "DELETE")
              {


                
                var request = new HttpRequestMessage(HttpMethod.Delete, textBox9.Text);
                var content = new StringContent("{\r\n    \"MonedaDestino\" : \"" + textBox2.Text + "\",\r\n\r\n    \"MonedaOrigen\" : \"" + textBox1.Text + "\",\r\n\r\n     \"Moneda\" : " + textBox3.Text + "\r\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                


                textBox7.Text = await response.Content.ReadAsStringAsync();
              }

        }

      
    }
}
