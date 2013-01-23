using System;
using System.Threading;

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

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee joined the company.
        /// </summary>
        public DateTime Joined { get; set; }

        /// <summary>
        /// Gets or sets the age of the employee.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the home data of the employee.
        /// </summary>
        public Location Home { get; set; }

        /// <summary>
        /// Gets or sets the email of the employee.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the position of the employee.
        /// </summary>
        public EmployeeGrade Grade { get; set; }

        /// <summary>
        /// Computes the employee's salary. This takes ~300 ms.
        /// </summary>
        /// <returns>The freshly computed salary.</returns>
        public double ComputeSalary()
        {
            Thread.Sleep(300); //Simuliere Zeit zum Berechnen
            return 1200.0 + //Fix
                random.NextDouble() * 500.0 + //Leistungsbezogen
                1000.0 * (int)Grade + //Gehaltsstufe
                (DateTime.Today.Subtract(Joined).Days / 365) * 200.0; //Beförderungsstufen
        }

        /// <summary>
        /// Gets the birthday of the employee. This has to be computed and
        /// is not thread-safe.
        /// </summary>
        public DateTime Birthday
        {
            get
            {
				Thread.Sleep(300);
				birthday = DateTime.Today.AddYears(-Age);
				birthday = birthday.AddDays(-random.Next(0, 10));
				birthday = birthday.AddMonths(-random.Next(0, 10));
				Thread.Sleep(300);
                return birthday;
            }
        }
    }
}
