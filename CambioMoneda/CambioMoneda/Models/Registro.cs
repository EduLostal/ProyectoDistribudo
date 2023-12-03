using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CambioMoneda.Models
{
    public static class Registro
    {


        public static LinkedList<Cambio> list = new LinkedList<Cambio>();

        
        public static Cambio GetMoneda(Cambio camb)
        {
            foreach (Cambio cambio in list)
            {
                if(cambio.MonedaOrigen == camb.MonedaOrigen & cambio.MonedaDestino == camb.MonedaDestino)
                {
                    return cambio;
                }
            }

            return null;          
            

        }

        public static Cambio GetCambio(Cambio moneda)
        {
          
            

            foreach (Cambio cambio in list)
            {
                if (cambio.Moneda == moneda.Moneda)
                {
                    return cambio;
                }
            }

            

            return null;

        }

        public static bool SetCambio(Cambio camb)
        {
            bool cambio = false;

                foreach (Cambio elemento in list)
                {
                    if (camb.MonedaOrigen == elemento.MonedaOrigen & camb.MonedaDestino == elemento.MonedaDestino)
                    {
                        
                        return cambio;

                    } 
                }
          
            list.AddLast(camb);
            cambio = true;
            return cambio;

        }

        public static bool DeleteCambio(Cambio camb)
            
        {
            bool cambio = false;
            Cambio encontrado = null;
            foreach (Cambio elemento in list)
            {
                if (camb.MonedaOrigen == elemento.MonedaOrigen && camb.MonedaDestino == elemento.MonedaDestino && camb.Moneda == elemento.Moneda)
                {
                    encontrado = elemento;
                    break; // Deja de buscar una vez que encuentras el elemento
                }
            }

            // Si se encontró, eliminarlo de la lista
            if (encontrado != null)
            {
                list.Remove(encontrado);

                return cambio = true; // Retorna el Cambio eliminado
            }

            // Si no se encontró el Cambio, retorna null
            return cambio;
        }

        public static LinkedList<Cambio> ObtenerTodosLosPares()
        {            
            return list;
        }
        public static bool PutCambio(Cambio camb)
        {
            bool cambio = false;
            foreach (Cambio elemento in list)
            {
                if (camb.MonedaOrigen == elemento.MonedaOrigen && camb.MonedaDestino == elemento.MonedaDestino && camb.Moneda != elemento.Moneda)
                {
                    elemento.Moneda = camb.Moneda;
                    return cambio = true;
                }
            }
            return cambio;
        }
    }
   
}