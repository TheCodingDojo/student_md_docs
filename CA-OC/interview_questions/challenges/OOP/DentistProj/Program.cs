using System;
using System.Collections.Generic;
using DentistProj.Models;

namespace DentistProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor("Dennis", "Trident", 30);
            Person friend = new Person("Friendly", "Friend");
            Person patient = new Person("Neil", "M", doctor, new List<Person>() { friend });

            /* Property or indexer 'IMouth.IsOpen' cannot be assigned to -- it is read only */
            // patient.Mouth.IsOpen = true;

            doctor.InspectMouth(patient);
            Console.WriteLine(doctor.RequestMouthOpen(patient));
            Console.WriteLine(patient.OpenMouth(friend));
        }
    }
}
