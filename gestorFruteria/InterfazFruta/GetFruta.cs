using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazFruta
{
    public partial class GetFruta : Form
    {
        public GetFruta()
        {
            InitializeComponent();
            
             
        }
        public string JsonData { get; set; }

        public void SetJsonData(string jsonData)
        {
            JsonData = jsonData;
                
        }
        private void buttonAcept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GetFrutaTabla()
        {
            if (string.IsNullOrEmpty(JsonData))
            {
                MessageBox.Show("No hay datos JSON para cargar.");
              
            }
           
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


            var json = JArray.Parse(JsonData);

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

            dataGridView1.DataSource = dataTable;
        }
    }
}
