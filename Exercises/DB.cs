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
            new Location // 0
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "1a",
                State = "BY",
                Street = "Maximilianstraße",
                Zip = "93047"
            },
            new Location // 1
            {
                City = "München",
                Country = "Germany",
                Number = "18",
                State = "BY",
                Street = "Türkenstraße",
                Zip = "80118"
            },
            new Location // 2
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "81",
                State = "BY",
                Street = "Wahlenstraße",
                Zip = "93049"
            },
            new Location // 3
            {
                City = "Regendorf",
                Country = "Germany",
                Number = "2",
                State = "BY",
                Street = "Am Berg",
                Zip = "93197"
            },
            new Location // 4
            {
                City = "Nittendorf",
                Country = "Germany",
                Number = "20",
                State = "BY",
                Street = "Peter-Rosegger-Str.",
                Zip = "93152"
            },
            new Location // 5
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "12b",
                State = "BY",
                Street = "Brennesstraße",
                Zip = "93053"
            },
            new Location // 6
            {
                City = "Stuttgart",
                Country = "Germany",
                Number = "1",
                State = "BW",
                Street = "Daimlerstraße",
                Zip = "70372"
            },
            new Location // 7
            {
                City = "Regendorf",
                Country = "Germany",
                Number = "39",
                State = "BY",
                Street = "Hinterm Mond",
                Zip = "93197"
            },
            new Location // 8
            {
                City = "Nittendorf",
                Country = "Germany",
                Number = "5",
                State = "BY",
                Street = "Bernsteinstraße",
                Zip = "93152"
            },
            new Location // 9
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "9f",
                State = "BY",
                Street = "Weichser Weg",
                Zip = "93053"
            },
            new Location // 10
            {
                City = "Regensburg",
                Country = "Austria",
                Number = "2",
                State = "SM",
                Street = "Felsentalweg",
                Zip = "8774"
            },
            new Location // 11
            {
                City = "Wien",
                Country = "Austria",
                Number = "191",
                State = "VI",
                Street = "Königsstraße",
                Zip = "1220"
            },
            new Location // 12
            {
                City = "München",
                Country = "Germany",
                Number = "74",
                State = "BY",
                Street = "Stollbergstr.",
                Zip = "80539"
            },
            new Location // 13
            {
                City = "Mariaort",
                Country = "Germany",
                Number = "3",
                State = "BY",
                Street = "Bauernstraße",
                Zip = "93165"
            },
            new Location // 14
            {
                City = "Neutraubling",
                Country = "Germany",
                Number = "89",
                State = "BY",
                Street = "Bayerwaldstraße",
                Zip = "93195"
            },
            new Location // 15
            {
                City = "Regenstauf",
                Country = "Germany",
                Number = "17g",
                State = "BY",
                Street = "Mozartstraße",
                Zip = "93128"
            },
            new Location // 16
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "1",
                State = "BY",
                Street = "Wernerwerkstraße",
                Zip = "93051"
            },
            new Location // 17
            {
                City = "Stuttgart",
                Country = "Germany",
                Number = "29",
                State = "BW",
                Street = "Lumpenallee",
                Zip = "70375"
            },
            new Location // 18
            {
                City = "Zeitlarn",
                Country = "Germany",
                Number = "8",
                State = "BY",
                Street = "Troppauerstraße",
                Zip = "93197"
            },
            new Location // 19
            {
                City = "Undorf",
                Country = "Germany",
                Number = "19",
                State = "BY",
                Street = "Am Angerberg",
                Zip = "93152"
            },
            new Location // 20
            {
                City = "Regensburg",
                Country = "Germany",
                Number = "6",
                State = "BY",
                Street = "Obere Bachgasse",
                Zip = "93047"
            },
            new Location // 21
            {
                City = "Zeitlarn",
                Country = "Austria",
                Number = "19",
                State = "SL",
                Street = "Bergstraße",
                Zip = "5237"
            },
            new Location // 22
            {
                City = "Nittendorf",
                Country = "Germany",
                Number = "16",
                State = "BY",
                Street = "Peter-Rosegger-Str.",
                Zip = "93152"
            },
        });

        #endregion

        #region Mitarbeiter

        static List<Employee> employees = new List<Employee>(new[] {
            new Employee // 0
            {
                Age = 21,
                Email = "andreas.mustermann@gmail.com",
                Grade = EmployeeGrade.Trainee,
                Home = locations[0],
                Joined = new DateTime(2010, 9, 1),
                Name = "Andreas Mustermann"
            },
            new Employee // 1
            {
                Age = 28,
                Email = "simon.franz@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[2],
                Joined = new DateTime(2009, 6, 1),
                Name = "Simon Franz"
            },
            new Employee // 2
            {
                Age = 35,
                Email = "harryw@yahoo.com",
                Grade = EmployeeGrade.Head,
                Home = locations[3],
                Joined = new DateTime(2005, 1, 1),
                Name = "Harry Weinberg"
            },
            new Employee // 3
            {
                Age = 48,
                Email = "ich@schuh.de",
                Grade = EmployeeGrade.Director,
                Home = locations[4],
                Joined = new DateTime(2005, 1, 1),
                Name = "Manuel Schuh"
            },
            new Employee // 4
            {
                Age = 27,
                Email = "xymolit@inwow.de",
                Grade = EmployeeGrade.Director,
                Home = locations[5],
                Joined = new DateTime(2010, 12, 1),
                Name = "Michael Uhrmann"
            },
            new Employee // 5
            {
                Age = 61,
                Email = "d.zetsche@daimler.de",
                Grade = EmployeeGrade.Board,
                Home = locations[1],
                Joined = new DateTime(2011, 1, 1),
                Name = "Dieter Zetsche"
            },
            new Employee // 6
            {
                Age = 62,
                Email = "gmarquant@bigcompany.de",
                Grade = EmployeeGrade.CEO,
                Home = locations[6],
                Joined = new DateTime(2001, 1, 1),
                Name = "Günter Marquant"
            },
            new Employee // 7
            {
                Age = 33,
                Email = "michael.hartung@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[7],
                Joined = new DateTime(2010, 1, 1),
                Name = "Michael Hartung"
            },
            new Employee // 8
            {
                Age = 35,
                Email = "grub.alex@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[8],
                Joined = new DateTime(2008, 10, 1),
                Name = "Alexander Grub"
            },
            new Employee // 9
            {
                Age = 26,
                Email = "lisa_bayer@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[9],
                Joined = new DateTime(2009, 9, 1),
                Name = "Lisa Bayer"
            },
            new Employee // 10
            {
                Age = 29,
                Email = "hsteinmassl@aol.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[10],
                Joined = new DateTime(2008, 8, 1),
                Name = "Herbert Steinmassl"
            },
            new Employee // 11
            {
                Age = 20,
                Email = "christian_heidl@web.de",
                Grade = EmployeeGrade.Trainee,
                Home = locations[11],
                Joined = new DateTime(2010, 9, 1),
                Name = "Christian Heidl"
            },
            new Employee // 12
            {
                Age = 18,
                Email = "gnom@hotmail.com",
                Grade = EmployeeGrade.Trainee,
                Home = locations[12],
                Joined = new DateTime(2010, 9, 1),
                Name = "Lisa Pisa"
            },
            new Employee // 13
            {
                Age = 19,
                Email = "josemia@arcor.de",
                Grade = EmployeeGrade.Trainee,
                Home = locations[13],
                Joined = new DateTime(2010, 9, 1),
                Name = "Jose Mourinho"
            },
            new Employee // 14
            {
                Age = 45,
                Email = "rainerw@live.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[14],
                Joined = new DateTime(2006, 2, 1),
                Name = "Rainer Wagner"
            },
            new Employee // 15
            {
                Age = 30,
                Email = "mm72@googlemail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[15],
                Joined = new DateTime(2010, 11, 1),
                Name = "Michael Maier"
            },
            new Employee // 16
            {
                Age = 60,
                Email = "ulrich.wagner@bigcompany.de",
                Grade = EmployeeGrade.Head,
                Home = locations[16],
                Joined = new DateTime(2010, 7, 1),
                Name = "Ulrich Wagner"
            },
            new Employee // 17
            {
                Age = 49,
                Email = "rene.obermann@t-online.de",
                Grade = EmployeeGrade.Board,
                Home = locations[17],
                Joined = new DateTime(2011, 1, 1),
                Name = "Rene Obermann"
            },
            new Employee // 18
            {
                Age = 34,
                Email = "sergey.krug@gmail.com",
                Grade = EmployeeGrade.Worker,
                Home = locations[18],
                Joined = new DateTime(2009, 1, 1),
                Name = "Sergey Krug"
            },
            new Employee // 19
            {
                Age = 38,
                Email = "berndb@gmx.de",
                Grade = EmployeeGrade.Worker,
                Home = locations[19],
                Joined = new DateTime(2008, 11, 1),
                Name = "Bernd Bieber"
            },
            new Employee // 20
            {
                Age = 36,
                Email = "shog@bigcompany.de",
                Grade = EmployeeGrade.Director,
                Home = locations[20],
                Joined = new DateTime(2009, 12, 1),
                Name = "Sheryl Ogomani"
            },
            new Employee // 21
            {
                Age = 23,
                Email = "marissa_meyer@yahoo.de",
                Grade = EmployeeGrade.Worker,
                Home = locations[21],
                Joined = new DateTime(2008, 9, 1),
                Name = "Marissa Meyer"
            },
            new Employee // 22
            {
                Age = 23,
                Email = "mfass@demail.de",
                Grade = EmployeeGrade.Trainee,
                Home = locations[22],
                Joined = new DateTime(2011, 9, 1),
                Name = "Michael Fassbender"
            }
        });

        #endregion

        #region Projekte

        static List<Project> projects = new List<Project>(new[] {
            new Project // 0
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
            new Project // 1
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
                    employees[2],
                    employees[7]
                })
            },
            new Project // 2
            {
                Budget = 50000m,
                Description = "Umstrukturierungen zwingen uns eine neue Ausrichtung der Abteilungen zu bestimmen.",
                Name = "Neugestaltung Abteilungen",
                Responsible = employees[5],
                Started = new DateTime(2012, 1, 1),
                Status = ProjectStatus.Finished,
                Workers = new List<Employee>(new [] 
                { 
                    employees[3],
                    employees[4]
                })
            },
            new Project // 3
            {
                Budget = 100000m,
                Description = "Microsofts HyperV soll von uns noch weiter verbessert werden um auch in HPC die notwendige Leistung zu bringen.",
                Name = "Ultra-HyperV",
                Responsible = employees[6],
                Started = new DateTime(2013, 4, 1),
                Status = ProjectStatus.Planned,
                Workers = new List<Employee>(new [] 
                { 
                    employees[8],
                    employees[9],
                    employees[10]
                })
            },
            new Project // 4
            {
                Budget = 250000m,
                Description = "Unsere Firmenseite muss endlich auf Vordermann gebracht werden. Neben Contentaktualisierungen sind neue Designs, sauberes Markup und social Integration auf der TODO-Liste.",
                Name = "Homepage Redesign",
                Responsible = employees[2],
                Started = new DateTime(2011, 7, 7),
                Status = ProjectStatus.Started,
                Workers = new List<Employee>(new [] 
                { 
                    employees[1],
                    employees[6],
                    employees[8]
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

		#region Add and Remove entries

		public static void AddEmployee(Employee employee)
		{
			employees.Add(employee);

			if(!locations.Contains(employee.Home))
				AddLocation(employee.Home);
		}

		public static void AddProject(Project project)
		{
			projects.Add(project);
		}

		public static void AddLocation(Location location)
		{
			locations.Remove(location);
		}

		public static void RemoveEmployee(Employee employee)
		{
			employees.Remove(employee);
		}

		public static void RemoveProject(Project project)
		{
			projects.Remove(project);
		}

		public static void RemoveLocation(Location location)
		{
			locations.Remove(location);
		}

		#endregion
    }
}
