using System;
using System.Collections.Generic;

namespace DentistProj.Models
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Honorific { get; }
        private Mouth mouth = new Mouth();

        // return interface type: the interface has getter's only for props that should be readonly
        public IMouth Mouth { get { return mouth; } }
        private Doctor _currentDoctor;
        private List<Person> trustedPersons;

        public Person() { }
        public Person(string firstName, string lastName, Doctor currentDoctor = null, List<Person> trustedPersons = null, string honorific = "Mr.")
        {
            FirstName = firstName;
            LastName = lastName;
            Honorific = honorific;
            _currentDoctor = currentDoctor;
            this.trustedPersons = trustedPersons ?? new List<Person>();
        }

        public bool OpenMouth(Person requester)
        {
            if (trustedPersons.Contains(requester) || requester == _currentDoctor)
            {
                mouth.IsOpen = true;
                return true;
            }
            return false;
        }

        // return bool represents success, not IsOpen state
        public bool CloseMouth(Person requester)
        {
            if (trustedPersons.Contains(requester) || requester == _currentDoctor)
            {
                mouth.IsOpen = false;
                return true;
            }
            return false;
        }


    }
}