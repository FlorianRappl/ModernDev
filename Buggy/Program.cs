using ModernDev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDev
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = DB.Employees.Where(m => m.Grade = EmployeeGrade.Worker).ToList();

            Console.WriteLine("Anzahl Mitarbeiter: {0}" + workers.Count);

            for (var i = 1; i <= workers.Count; i++)
                Console.WriteLine("Mitarbeiter {0}: {1}", i, workers[i].Name);

            var youngest = FindRecentYoungestAsync(workers).Result;

            Console.WriteLine("Jüngster Mitarbeiter (seit diesem Jahr): {0} ({1} Jahre)", youngest.Name, youngest.Age);

            var maxWorker = new Employee();
            int most = int.MaxValue;

            foreach (var employee in DB.Employees)
            {
                var sum = 0;

                foreach (var project in DB.Projects)
                {
                    if (project.Responsible == employee)
                        sum++;
                    else
                    {
                        foreach (var worker in project.Workers)
                            if (worker == employee)
                                sum++;
                    }
                }

                if (sum < most)
                {
                    most = sum;
                    maxWorker = employee;
                }

                Console.WriteLine("{1} arbeitet an {2} Projekten mit.", employee.Name, sum);
            }

            Console.WriteLine("{0} ist an {1} Projekten beteiligt ...", maxWorker.Name, most);
        }

        static async Task<Employee> FindRecentYoungestAsync(List<Employee> workers)
        {
            return await Task.Run(() =>
            {
                return FindRecentYoungest(workers);
            });
        }

        static Employee FindRecentYoungest(List<Employee> workers)
        {
            return workers
                .Where(m => m.Joined.CompareTo(new DateTime(DateTime.Today.Year, 1, 1)) >= 0)
                .OrderBy(m => m.Age)
                .FirstOrDefault();
        }
    }
}
