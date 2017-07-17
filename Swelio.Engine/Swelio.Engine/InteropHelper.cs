//===============================================================================
// Copyright (c) Serhiy Perevoznyk.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Security.Permissions;

namespace Swelio.Engine
{
    /// <summary>
    /// Helper class for accessing native Windows API and resources
    /// Not recommeded to use it directly without deep understanding of Windows API
    /// </summary>
    public static class InteropHelper
    {

        /// <summary>Shows the windows error.</summary>
        /// <param name="errorCode">The error code.</param>
        public static void ShowWindowsError(int errorCode)
        {
            NativeMethods.ShowError(errorCode);
        }

        /// <summary>Clears the unused memory.</summary>
        public static void ClearUnusedMemory()
        {
            NativeMethods.ClearUnusedMemory();
        }

        /// <summary>
        /// Determines if the application is running on Windows 7
        /// </summary>
        public static bool RunningOnWin7
        {
            get
            {
                return NativeMethods.IsWindows7();
            }
        }

        /// <summary>
        /// Determines if the application is running on Windows 10
        /// </summary>
        public static bool RunningOnWin10
        {
            get
            {
                return NativeMethods.IsWindows10();
            }
        }

        public static bool RunningOnWin8
        {
            get
            {
                return NativeMethods.IsWindows8();
            }
        }

        public static bool MetroActive
        {
            get
            {
                return NativeMethods.IsMetroActive();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [running on vista].
        /// </summary>
        /// <value><c>true</c> if [running on vista]; otherwise, <c>false</c>.</value>
        public static bool RunningOnVista
        {
            get
            {
                return NativeMethods.IsWindowsVista();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [running on XP].
        /// </summary>
        /// <value><c>true</c> if [running on XP]; otherwise, <c>false</c>.</value>
        public static bool RunningOnXP
        {
            get
            {
                return NativeMethods.IsWindowsXP();
            }
        }

        public static bool IsMultiTouchReady
        {
            get { return NativeMethods.IsMultiTouchReady(); }
        }

        public static bool IsTabletPC
        {
            get { return NativeMethods.IsTabletPC(); }
        }

        public static bool IsMediaCenter
        {
            get { return NativeMethods.IsMediaCenter(); }
        }

        /// <summary>
        /// Shows the screen keyboard.
        /// </summary>
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void ShowScreenKeyboard()
        {
            string keyboardApp;

            if (RunningOnWin8)
                keyboardApp = @"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe";
            else
                keyboardApp = @"C:\WINDOWS\system32\osk.exe";

            if (File.Exists(keyboardApp))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.FileName = keyboardApp;
                startInfo.Arguments = string.Empty;
                startInfo.ErrorDialog = true;
                Process.Start(startInfo);
            }
        }

        /// <summary>
        /// Add/Remove registry entries for windows startup. Only for current user
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="appPath">The application path.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public static void SetStartup(string appName, string appPath, bool enable)
        {
            if (enable)
            {
                NativeMethods.SetStartup(appName, appPath);
            }
            else
            {
                // remove startup
                NativeMethods.RemoveStartup(appName);
            }
        }

        public static bool GetStartup(string appName)
        {
            return NativeMethods.GetStartup(appName);
        }

        /// <summary>
        /// Turns the monitor on.
        /// </summary>
        public static void TurnMonitorOn()
        {
            NativeMethods.TurnMonitorOn();
        }

        /// <summary>
        /// Turns the monitor off.
        /// </summary>
        public static void TurnMonitorOff()
        {
            NativeMethods.TurnMonitorOff();
        }

    }
}
