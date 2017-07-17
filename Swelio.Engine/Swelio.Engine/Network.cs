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
    public static class Network
    {
        /// <summary>
        /// Gets a value indicating whether PC is connected to internet.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this PC is connected to internet; otherwise, <c>false</c>.
        /// </value>
        public static bool IsConnectedToInternet
        {
            get { return NativeMethods.IsConnectedToInternet(); }
        }

        /// <summary>
        /// Gets the current IP address.
        /// </summary>
        public static string CurrentIPAddress
        {
            get
            {
                StringBuilder sb = new StringBuilder(32);
                NativeMethods.CurrentIPAddress(sb, 31);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Ports the available.
        /// </summary>
        /// <param name="portNumber">The port number.</param>
        /// <returns></returns>
        public static bool PortAvailable(int portNumber)
        {
            return NativeMethods.PortAvailable(portNumber);
        }
    }
}
