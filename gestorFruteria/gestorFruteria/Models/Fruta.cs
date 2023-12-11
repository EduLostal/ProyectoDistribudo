using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using MongoDB.Driver;

namespace CambioMoneda.Models
{
    public class Fruta
    {



        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nombreFruta")]
        public string NombreFruta { get; set; }

        [BsonElement("cantidad")]
        public int Cantidad { get; set; }

        [BsonElement("precioPorUnidad")]
        public double PrecioPorUnidad { get; set; }

        [BsonElement("proveedor")]
        public Proveedor Proveedor { get; set; }

        [BsonElement("ventas")]
        public Venta Venta { get; set; }

    }

    public class Proveedor
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("contacto")]
        public string Contacto { get; set; }

        [BsonElement("telefono")]
        public string Telefono { get; set; }
    }

    public class Venta
    {
        [BsonElement("cliente")]
        public string Cliente { get; set; }

        [BsonElement("cantidadVendida")]
        public int CantidadVendida { get; set; }

        [BsonElement("precioVenta")]
        public double PrecioVenta { get; set; }

        [BsonElement("fechaVenta")]
        public DateTime FechaVenta { get; set; }
    }



}
