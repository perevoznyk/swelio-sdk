//===============================================================================
// Copyright (c) Serhiy Perevoznyk.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Swelio.Engine
{
    /// <summary>
    /// Windows shutdown options
    /// </summary>
    public enum ShutdownOption
    {
        /// <summary>
        /// Shuts down all processes running in the security context of the process that called the ExitWindowsEx function. Then it logs the user off.
        /// </summary>
        LogOff = 0,
        /// <summary>
        /// Shuts down the system and turns off the power. The system must support the power-off feature.
        /// </summary>
        PowerOff = 8,
        /// <summary>
        /// Shuts down the system and then restarts the system.
        /// </summary>
        Reboot = 2,
        /// <summary>
        /// Shuts down the system to a point at which it is safe to turn off the power. All file buffers have been flushed to disk, and all running processes have stopped. If the system supports the power-off feature, the power is also turned off.
        /// </summary>
        Shutdown = 1,
        /// <summary>
        /// Suspends the system.
        /// </summary>
        Suspend = -1,
        /// <summary>
        /// Hibernates the system.
        /// </summary>
        Hibernate = -2,
    }

    /// <summary>
    /// Windows power management class
    /// </summary>
    public static class WindowsOperations
    {
        /// <summary>
        /// Shutdown Computer
        /// </summary>
        /// <param name="option">The option.</param>
        public static void Shutdown(ShutdownOption option)
        {
            NativeMethods.ShutdownWindows((int)option);
        }

        /// <summary>
        /// Suspends computer
        /// </summary>
        public static void Suspend()
        {
            NativeMethods.SuspendWindows();
        }

        /// <summary>
        /// Hibernate computer
        /// </summary>
        public static void Hibernate()
        {
            NativeMethods.HibernateWindows();
        }
    }
}
