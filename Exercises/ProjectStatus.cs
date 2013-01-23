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
    /// Contains a list of possible states for the project.
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// The project is planned.
        /// </summary>
        Planned,
        /// <summary>
        /// The project already started.
        /// </summary>
        Started,
        /// <summary>
        /// The project is currently on hold.
        /// </summary>
        Paused,
        /// <summary>
        /// The project already finished.
        /// </summary>
        Finished
    }
}
