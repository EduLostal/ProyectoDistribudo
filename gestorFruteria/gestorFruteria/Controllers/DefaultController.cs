using gestorFruteria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace gestorFruteria.Controllers
{
    public class DefaultController : ApiController
    {
        Enlace enlace = new Enlace();
        // GET: api/Default
        public  IEnumerable<Fruta> Get()
        {
           return enlace.GetAllAsync();
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Default/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/Default/5
        //public void Delete(int id)
        //{
        //}
    }
}
