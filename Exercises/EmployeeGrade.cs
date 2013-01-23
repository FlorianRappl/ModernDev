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
    /// A list of possible positions in the company.
    /// </summary>
    public enum EmployeeGrade
    {
        /// <summary>
        /// A trainee.
        /// </summary>
        Trainee,
        /// <summary>
        /// A normal worker.
        /// </summary>
        Worker,
        /// <summary>
        /// Department head.
        /// </summary>
        Head,
        /// <summary>
        /// Director of a department.
        /// </summary>
        Director,
        /// <summary>
        /// On the board.
        /// </summary>
        Board,
        /// <summary>
        /// The boss!
        /// </summary>
        CEO
    }
}
