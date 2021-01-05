using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoApi.Models;
using System.Collections;

namespace DemoApi.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Person1", "Person2" };
        //}
        public ArrayList Get()
        {
            PersonApp pa = new PersonApp();
            
            return pa.GetPerson();
        }

        // GET: api/Person/5
        public Person Get(int idPerson)
        {
            PersonApp pa = new PersonApp();
            Person person = pa.GetPerson(idPerson);
            //person.idPerson =  id;
            //person.firstName = "Bac";
            //person.lastName = "Le Phuoc";
            //person.dateOfBirth = "03/02/1996"; 
            return person;
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersonApp pa = new PersonApp();
            int id = pa.SavePerson(value);
            value.idPerson = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("person/{0}",id));
            return response;
        }

        // PUT: api/Person/5
        public HttpResponseMessage Put(int id, [FromBody]Person value)
        {
            PersonApp pa = new PersonApp();
            bool recordExisted = false;
            recordExisted = pa.UpdatePerson(id, value);
            HttpResponseMessage response;

            if(recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        // DELETE: api/Person/5
        public HttpResponseMessage Delete(int id)
        {
            PersonApp pa = new PersonApp();
            bool recordExisted = false;
            recordExisted = pa.DeletePerson(id);
            HttpResponseMessage response;
            if(recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response; 
        }
    }
}
