using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Antlr.Runtime.Tree;
using CambioMoneda.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace CambioMoneda.Controllers
{

    public class CambioController : ApiController
    {



        // GET: api/Cambio
        public IEnumerable<Cambio> Get()
        {


            return Registro.ObtenerTodosLosPares();

        }

        // GET: api/Cambio/5
        public Cambio Get(int id,Cambio cambio)
        {
            return Registro.GetMoneda(cambio);
        }

        // POST: api/Cambio
        public string Post([FromBody]Cambio value)
        {
            if (Registro.SetCambio(value)) { return "Cambio registrado"; }
            return "El cambio ya esta registrado";
        }

        // PUT: api/Cambio/5
        public string Put( [FromBody]Cambio value)
        {
            if (Registro.PutCambio(value)) { return "Cambio actualizado"; }
            return "Fallo al actualizar";

           



        }

        // DELETE: api/Cambio/5
        public string Delete(Cambio cambio)
        {
            if (Registro.DeleteCambio(cambio)) { return "Cambio borrado"; }
             return "El cambio no existe o ha habido un error";
        }
    }
}
