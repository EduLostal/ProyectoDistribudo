using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace InterfazFruta
{
    public partial class app : Form
    {
        DataTable dt = new DataTable();
        
        public app()
        {
            InitializeComponent();            
            Alldata();
            

        }


        public async void Alldata() 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, textBox11.Text);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string jsonFilePath = await response.Content.ReadAsStringAsync() ; // Ruta de tu archivo JSON
            try
            {
                // Lee el contenido del archivo JSON
                string jsonString = File.ReadAllText(jsonFilePath);

                // Convierte el JSON en DataTable
                dt = JsonConvert.DeserializeObject<DataTable>(jsonString);

                // Ahora puedes usar tu DataTable, por ejemplo, asignándolo a un DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al cargar el archivo JSON: " + ex.Message);
            }

           
            
        }

      
    }
}
