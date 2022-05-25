using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana09.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool isTecsup { get; set; }

    }
}