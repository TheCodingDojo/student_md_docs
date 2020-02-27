namespace DentistProj.Models
{
    public class Dentist : Person
    {
        public int YearsPracticed { get; set; }

        public Dentist(int yearsPracticed, string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            YearsPracticed = yearsPracticed;
        }
    }
}