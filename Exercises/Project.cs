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
    /// Model für ein Projekt
    /// </summary>
    public class Project
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Employee Responsible { get; set; }

        public List<Employee> Workers { get; set; }

        public decimal Budget { get; set; }

        public DateTime Started { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
