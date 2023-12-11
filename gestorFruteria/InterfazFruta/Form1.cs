using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InterfazFruta
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

        private async void Envio_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();


            if (comboBox1.SelectedItem.ToString() == "POST")
            {
                var request = new HttpRequestMessage(HttpMethod.Post, UrlText.Text);
                var content = new StringContent(Body.Text, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Body.Text = await response.Content.ReadAsStringAsync();

            }
            else if (comboBox1.SelectedItem.ToString() == "GET")
            {

                var request = new HttpRequestMessage(HttpMethod.Get, UrlText.Text);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Body.Text = await response.Content.ReadAsStringAsync();


            }
            else if (comboBox1.SelectedItem.ToString() == "PUT")
            {




               

            }
            else if (comboBox1.SelectedItem.ToString() == "DELETE")
            {



              



               
            }

        }
    }
}
