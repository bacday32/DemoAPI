using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApi.Models
{
    public class Person
    {
        public int idPerson { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public Person()
        {
        }


    }
}