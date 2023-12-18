using System;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using Amazon.Runtime.Internal;

namespace InterfazFruta
{
    public partial class app : Form
    {
       
        
        public app()
        {
            InitializeComponent();            
            Alldata();
            

        }
        //Boton guardar,introducir todos los datos excepto ID(POST)
        private async void Guardar_Click(object sender, EventArgs e)
        {
            //string responseContent = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44396/api/frutas");
            var content = new StringContent("{\r\n        \"Id\": \""+ BoxID.Text +"\",\r\n        \"NombreFruta\": \""+ BoxNameFruta.Text +"\",\r\n " +
                "\"Cantidad\": \""+ BoxCantidad.Text +"\" ,\r\n        \"PrecioPorUnidad\": \""+ BoxPrecioUnidad.Text +"\",\r\n        \"Proveedor\": {\r\n " +
                "\"Nombre\": \"" +BoxNameProovedor.Text +"\",\r\n            \"Contacto\": \""+ BoxContacto.Text +"\",\r\n   " +
                "\"Telefono\": \""+ BoxTlf.Text +"\"\r\n        },\r\n        \"Venta\": {\r\n            \"Cliente\": \""+ BoxCliente.Text +"\",\r\n " +
                "\"CantidadVendida\": \""+ BoxCantidadVendida.Text +"\",\r\n            \"PrecioVenta\": \""+ BoxPrecioVenta.Text +"\",\r\n            " +
                "\"FechaVenta\": \""+ BoxTime.Value.ToString("o") + "\"\r\n        }\r\n    }", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Ya existe la fruta");
                
                //responseContent = await response.Content.ReadAsStringAsync();
               
                
                return;
            }
            
            MessageBox.Show("Fruta guardada");
            Alldata();

        }

        //Boton borrar,solo introducir ID(DELETE)
        private async void Borrar_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:44396/api/frutas/" + BoxID.Text);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Alldata();
            MessageBox.Show(await response.Content.ReadAsStringAsync());
        }

        //Boton modificar,introducir ID y datos a modificar(PUT)
        private async void Modificar_Click(object sender, EventArgs e)
        {
            string responseContent = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:44396/api/frutas/"+ BoxID.Text);
            var content = new StringContent("{\r\n        \"Id\": \"" + BoxID.Text + "\",\r\n        \"NombreFruta\": \"" + BoxNameFruta.Text + "\",\r\n " +
                "\"Cantidad\": \"" + BoxCantidad.Text + "\" ,\r\n        \"PrecioPorUnidad\": \"" + BoxPrecioUnidad.Text + "\",\r\n        \"Proveedor\": {\r\n " +
                "\"Nombre\": \"" + BoxNameProovedor.Text + "\",\r\n            \"Contacto\": \"" + BoxContacto.Text + "\",\r\n   " +
                "\"Telefono\": \"" + BoxTlf.Text + "\"\r\n        },\r\n        \"Venta\": {\r\n            \"Cliente\": \"" + BoxCliente.Text + "\",\r\n " +
                "\"CantidadVendida\": \"" + BoxCantidadVendida.Text + "\",\r\n            \"PrecioVenta\": \"" + BoxPrecioVenta.Text + "\",\r\n            " +
                "\"FechaVenta\": \"" + BoxTime.Value.ToString("o") + "\"\r\n        }\r\n    }", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Error: {response.StatusCode}");

                responseContent = await response.Content.ReadAsStringAsync();
                
                
                return;
            }
            MessageBox.Show("Modificado..");
            Alldata();
           
        
        }

        //Boton buscar,solo introducir nombre fruta y saldra una ventana con los datos de la fruta(GET)
        private async void Buscar_Click(object sender, EventArgs e)
        {
            
            if (BoxNameFrutaGet.Text != "")
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44396/api/frutas/" + BoxNameFrutaGet.Text);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                if (jsonResponse != "[]")
                {
                    GetFruta gtfruta = new GetFruta();
                    gtfruta.SetJsonData(jsonResponse);
                    gtfruta.GetFrutaTabla();
                    gtfruta.Show();
                }
                else { MessageBox.Show("No existe fruta"); }
            }
            else { MessageBox.Show("No has introducido datos"); }
            
        }

        //Metodo en el cual usa el GET para mostrar la base entera y que implementa todos los botones para tener tabla actualizada
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

        //Creacion tabla datos
       private DataTable LoadJsonToDataTable(string jsonFilePath)
       {
          DataTable dataTable = new DataTable();

           
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
