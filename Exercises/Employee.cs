using System;
using System.Threading.Tasks;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace ModernDev
{
    /// <summary>
    /// Model für einen Mitarbeiter Datensatz
    /// </summary>
    public class Employee
    {
        static Random random = new Random();

        static DateTime birthday;

        public string Name { get; set; }

        public DateTime Joined { get; set; }

        public int Age { get; set; }

        public Location Home { get; set; }

        public string Email { get; set; }

        public EmployeeGrade Grade { get; set; }

        public double ComputeSalary()
        {
            Task.Delay(200); //Simuliere Zeit zum Berechnen
            return 1200.0 + //Fix
                random.NextDouble() * 500.0 + //Leistungsbezogen
                1000.0 * (int)Grade + //Gehaltsstufe
                (DateTime.Today.Subtract(Joined).Days / 365) * 200.0; //Beförderungsstufen
        }

        public DateTime Birthday
        {
            get
            {
                birthday = DateTime.Today.AddYears(-Age);
                birthday = birthday.AddDays(-random.Next(0, 10));
                birthday = birthday.AddMonths(-random.Next(0, 10));
                return birthday;
            }
        }
    }
}
