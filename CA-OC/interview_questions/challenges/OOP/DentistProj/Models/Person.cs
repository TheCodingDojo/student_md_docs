using System.Collections.Generic;

namespace DentistProj.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private List<dynamic> _trustedEntities = new List<dynamic>();
    }
}