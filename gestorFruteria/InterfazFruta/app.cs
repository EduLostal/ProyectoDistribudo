using System;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace InterfazFruta
{
    public partial class app : Form
    {
       
        
        public app()
        {
            InitializeComponent();            
            Alldata();
            

        }
        private async void Guardar_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44396/api/frutas");
            var content = new StringContent("{\r\n        \"Id\": \""+ BoxID.Text +"\",\r\n        \"NombreFruta\": \""+ BoxNameFruta.Text +"\",\r\n " +
                "\"Cantidad\": \""+ BoxCantidad.Text +"\" ,\r\n        \"PrecioPorUnidad\": \""+ BoxPrecioUnidad.Text +"\",\r\n        \"Proveedor\": {\r\n " +
                "\"Nombre\": \"" +BoxNameProovedor.Text +"\",\r\n            \"Contacto\": \""+ BoxContacto.Text +"\",\r\n   " +
                "\"Telefono\": \""+ BoxTlf.Text +"\"\r\n        },\r\n        \"Venta\": {\r\n            \"Cliente\": \""+ BoxCliente.Text +"\",\r\n " +
                "\"CantidadVendida\": \""+ BoxCantidadVendida.Text +"\",\r\n            \"PrecioVenta\": \""+ BoxPrecioVenta.Text +"\",\r\n            " +
                "\"FechaVenta\": \""+ BoxTime.Text +"\"\r\n        }\r\n    }", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Error: {response.StatusCode}");
                Console.WriteLine($"Error: {response.StatusCode}");
                string responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Detalles del error: {responseContent}");
                Console.WriteLine($"Detalles del error: {responseContent}");
                return;
            }
            //response.EnsureSuccessStatusCode();
            //string messageBox = await response.Content.ReadAsStringAsync();
            //MessageBox.Show(messageBox);
            Alldata();

        }


        public async void Alldata() 
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44396/api/frutas");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string jsonFilePath = await response.Content.ReadAsStringAsync() ; 
            try
            {             
                
                dataGridView1.DataSource = LoadJsonToDataTable(jsonFilePath);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al cargar el archivo JSON: " + ex.Message);
            }

           
            
        }      
       private DataTable LoadJsonToDataTable(string jsonFilePath)
       {
          DataTable dataTable = new DataTable();

           // Define las columnas del DataTable
          dataTable.Columns.Add("ID", typeof(string));
          dataTable.Columns.Add("NombreFruta", typeof(string));
          dataTable.Columns.Add("Cantidad", typeof(int));
          dataTable.Columns.Add("Precio/Unidad", typeof(decimal));
          dataTable.Columns.Add("Nombre", typeof(string));
          dataTable.Columns.Add("Contacto", typeof(string));
          dataTable.Columns.Add("Telefono", typeof(string));
          dataTable.Columns.Add("Cliente", typeof(string));
          dataTable.Columns.Add("Cantidad/Vendida", typeof(int));
          dataTable.Columns.Add("Precio/Venta", typeof(decimal));
          dataTable.Columns.Add("Fecha/Venta", typeof(DateTime));

          
          var json = JArray.Parse(jsonFilePath); 

             foreach (var item in json)
             {
               DataRow row = dataTable.NewRow();

               row["ID"] = item["Id"].ToString();
               row["NombreFruta"] = item["NombreFruta"].ToString();
               row["Cantidad"] = (int)item["Cantidad"];
               row["Precio/Unidad"] = (decimal)item["PrecioPorUnidad"];
               row["Nombre"] = item["Proveedor"]["Nombre"].ToString();
               row["Contacto"] = item["Proveedor"]["Contacto"].ToString();
               row["Telefono"] = item["Proveedor"]["Telefono"].ToString();
               row["Cliente"] = item["Venta"]["Cliente"].ToString();
               row["Cantidad/Vendida"] = (int)item["Venta"]["CantidadVendida"];
               row["Precio/Venta"] = (decimal)item["Venta"]["PrecioVenta"];
               row["Fecha/Venta"] = (DateTime)item["Venta"]["FechaVenta"];

               dataTable.Rows.Add(row);
             }

           return dataTable;
        }

  }
}
