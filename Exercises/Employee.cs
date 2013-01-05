using System;

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
        public string Name { get; set; }

        public DateTime Joined { get; set; }

        public int Age { get; set; }

        public Location Home { get; set; }

        public string Email { get; set; }

        public EmployeeGrade Grade { get; set; }
    }
}
