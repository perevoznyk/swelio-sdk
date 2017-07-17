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
    /// The code of the card event
    /// </summary>
    internal enum CardEvent : int
    {
        CardInsert = 1,
        CardRemove = 2,
        ReadersChange = 3,
        UnknownEvent = 0
    }

}
