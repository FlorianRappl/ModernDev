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
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets who is responsible for the project.
        /// </summary>
        public Employee Responsible { get; set; }

        /// <summary>
        /// Gets or sets the involved persons.
        /// </summary>
        public List<Employee> Workers { get; set; }

        /// <summary>
        /// Gets or sets the budget.
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// Gets or sets the time when the project has started or should start.
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// Gets or sets the status of the project.
        /// </summary>
        public ProjectStatus Status { get; set; }
    }
}
