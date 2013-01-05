using System;
using System.Collections.Generic;

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
    /// Diese "Datenbank" (ist natürlich keine echte Datenbank, aber simuliert für uns einen DAL
    /// zu einer Datenbank mittels eines ORM) gibt uns Zugang zu den Models, welche für die
    /// Aufgaben verwendet werden sollen.
    /// </summary>
    public static class DB
    {
        #region (Sample) Data

        #region Orte

        static List<Location> locations = new List<Location>(new[] {
            new Location
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "1a",
                State = "BY",
                Street = "Maximilianstraße",
                Zip = "93047"
            },
            new Location
            {
                City = "München",
                Country = "Germany",
                Number = "18",
                State = "BY",
                Street = "Türkenstraße",
                Zip = "80118"
            },
            new Location
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "81",
                State = "BY",
                Street = "Wahlenstraße",
                Zip = "93049"
            },
            new Location
            {
                City = "Regendorf",
                Country = "Germany",
                Number = "2",
                State = "BY",
                Street = "Am Berg",
                Zip = "93197"
            },
            new Location
            {
                City = "Nittendorf",
                Country = "Germany",
                Number = "20",
                State = "BY",
                Street = "Peter-Rosegger-Str.",
                Zip = "93152"
            },
            new Location
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "12b",
                State = "BY",
                Street = "Brennesstraße",
                Zip = "93053"
            },
            new Location
            {
                City = "Stuttgart",
                Country = "Germany",
                Number = "1",
                State = "BY",
                Street = "Daimlerstraße",
                Zip = "70372"
            },
            new Location
            {
                City = "Regendorf",
                Country = "Germany",
                Number = "39",
                State = "BY",
                Street = "Hinterm Mond",
                Zip = "93197"
            },
            new Location
            {
                City = "Nittendorf",
                Country = "Germany",
                Number = "5",
                State = "BY",
                Street = "Bernsteinstraße",
                Zip = "93152"
            },
            new Location
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "9f",
                State = "BY",
                Street = "Weichser Weg",
                Zip = "93053"
            }
        });

        #endregion

        #region Mitarbeiter

        static List<Employee> employees = new List<Employee>(new[] {
            new Employee
            {
                Age = 21,
                Email = "andreas.mustermann@gmail.com",
                Grade = EmployeeGrade.Trainee,
                Home = locations[0],
                Joined = new DateTime(2010, 9, 1),
                Name = "Andreas Mustermann"
            },
            new Employee
            {
                Age = 28,
                Email = "simon.franz@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[2],
                Joined = new DateTime(2009, 6, 1),
                Name = "Simon Franz"
            },
            new Employee
            {
                Age = 35,
                Email = "harryw@yahoo.com",
                Grade = EmployeeGrade.Head,
                Home = locations[3],
                Joined = new DateTime(2005, 1, 1),
                Name = "Harry Weinberg"
            },
            new Employee
            {
                Age = 48,
                Email = "ich@schuh.de",
                Grade = EmployeeGrade.Director,
                Home = locations[4],
                Joined = new DateTime(2005, 1, 1),
                Name = "Manuel Schuh"
            },
            new Employee
            {
                Age = 27,
                Email = "xymolit@inwow.de",
                Grade = EmployeeGrade.Director,
                Home = locations[5],
                Joined = new DateTime(2010, 12, 1),
                Name = "Michael Uhrmann"
            },
            new Employee
            {
                Age = 61,
                Email = "d.zetsche@daimler.de",
                Grade = EmployeeGrade.Board,
                Home = locations[1],
                Joined = new DateTime(2011, 1, 1),
                Name = "Dieter Zetsche"
            },
            new Employee
            {
                Age = 62,
                Email = "gmarquant@bigcompany.de",
                Grade = EmployeeGrade.CEO,
                Home = locations[6],
                Joined = new DateTime(2001, 1, 1),
                Name = "Günter Marquant"
            },
            new Employee
            {
                Age = 33,
                Email = "michael.hartung@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[7],
                Joined = new DateTime(2010, 1, 1),
                Name = "Michael Hartung"
            },
            new Employee
            {
                Age = 35,
                Email = "grub.alex@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[8],
                Joined = new DateTime(2008, 10, 1),
                Name = "Alexander Grub"
            },
            new Employee
            {
                Age = 26,
                Email = "lisa_bayer@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[9],
                Joined = new DateTime(2009, 9, 1),
                Name = "Lisa Bayer"
            }
        });

        #endregion

        #region Projekte

        static List<Project> projects = new List<Project>(new[] {
            new Project
            {
                Budget = 10000m,
                Description = "Eine einfache NoSQL DB auf Basis von MongoDB soll aufgesetzt werden um ein zentrales Dokumentrepository für unser Firmennetzwerk aufzubauen.",
                Name = "MongoDB Installation",
                Responsible = employees[1],
                Started = new DateTime(2011, 7, 7),
                Status = ProjectStatus.Started,
                Workers = new List<Employee>(new [] 
                { 
                    employees[0] 
                })
            },
            new Project
            {
                Budget = 1000000m,
                Description = "Das Rechenzentrum der TUM soll mit neuester Software und (teilweise) Technik ausgestattet werden. Das zentrale Thema heißt Cloud Computing.",
                Name = "Rechenzentrum TUM aufbauen",
                Responsible = employees[4],
                Started = new DateTime(2012, 1, 1),
                Status = ProjectStatus.Paused,
                Workers = new List<Employee>(new [] 
                {
                    employees[0],
                    employees[1],
                    employees[2]
                })
            }
        });

        #endregion

        #endregion

        #region Zugang zu den "Tabellen"

        public static IEnumerable<Employee> Employees
        {
            get
            {
                foreach (var employee in employees)
                    yield return employee;
            }
        }

        public static IEnumerable<Location> Locations
        {
            get
            {
                foreach (var location in locations)
                    yield return location;
            }
        }

        public static IEnumerable<Project> Projects
        {
            get
            {
                foreach (var project in projects)
                    yield return project;
            }
        }

        #endregion
    }
}
