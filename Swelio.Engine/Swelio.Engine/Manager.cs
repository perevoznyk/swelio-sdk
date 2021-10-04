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
    /// The Swelio Engine Manager class used to activate and deactivate engine 
    /// and gives an access to the smart card readers, connected to the PC
    /// </summary>
    public sealed class Manager : IDisposable
    {
        private List<CardReader> readers;
        private bool traceEvents;
        private bool traceServiceEvents;
        private bool traceHardwareEvents;

        private ReaderCallbackDelegate InternalCallbackDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        public Manager()
        {
            readers = new List<CardReader>();
            traceHardwareEvents = true;
            traceServiceEvents = true;
            InternalCallbackDelegate = new ReaderCallbackDelegate(EventTracer);
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Manager"/> is reclaimed by garbage collection.
        /// </summary>
        ~Manager()
        {
            Dispose(false);
        }

        /// <summary>
        /// Clears the readers list.
        /// </summary>
        private void ClearReadersList()
        {
            for (int i = 0; i < readers.Count; i++)
                readers[i].Dispose();
            readers.Clear();
        }

        /// <summary>
        /// Retrieves the readers list from the native engine library.
        /// </summary>
        private void RetrieveReadersList()
        {
            ClearReadersList();
            for (int i = 0; i < NativeMethods.GetReadersCount(); i++)
            {
                int len = NativeMethods.GetReaderNameLen(i) / 2;
                StringBuilder sb = new StringBuilder(len);
                NativeMethods.GetReaderName(i, sb, len);
                CardReader reader = new CardReader();
                reader.Name = sb.ToString();
                reader.Index = i;
                readers.Add(reader);
            }
        }


        /// <summary>
        /// Setting up the trace of the card events handler
        /// </summary>
        /// <param name="readerNumber">The reader number.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="userContext">The user context.</param>
        private void EventTracer(ref int readerNumber, ref int eventCode, IntPtr userContext)
        {

            switch ((CardEvent)eventCode)
            {
                case CardEvent.CardInsert:
                    if (CardInserted != null)
                    {
                        CardInserted(this, new CardEventArgs((int)readerNumber));
                    }
                    break;
                case CardEvent.CardRemove:
                    if (CardRemoved != null)
                    {
                        CardRemoved(this, new CardEventArgs((int)readerNumber));
                        CardReader reader = GetReader(readerNumber);
                        if (reader != null)
                            reader.DeactivateCard();
                    }
                    break;
                case CardEvent.ReadersChange:
                    int newReadersCount = NativeMethods.GetReadersCount();
                    if ( (newReadersCount != readers.Count) && traceHardwareEvents)
                    {
                        ReloadReadersList();
                        if (ReadersListChanged != null)
                        {
                            ReadersListChanged(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        //Just continue to trace events
                        if (Active)
                        {
                            StopEventsTracing();
                            StartEventsTracing();
                        }
                    }
                    break;
                case CardEvent.UnknownEvent:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Starts the events tracing.
        /// </summary>
        private void StartEventsTracing()
        {
            if (Active)
            {
                traceEvents = true;

                NativeMethods.SetCallback(InternalCallbackDelegate, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Stops the events tracing.
        /// </summary>
        private void StopEventsTracing()
        {
            traceEvents = false;
            NativeMethods.RemoveCallback();
        }

        public bool TraceServiceEvents
        {
            get { return traceServiceEvents; }
            set 
            { 
                traceServiceEvents = value;
                NativeMethods.IgnoreServiceEvents(!value);
            }
        }

        public bool TraceHardwareEvents
        {
            get { return traceHardwareEvents; }
            set
            {
                traceHardwareEvents = value;
                NativeMethods.IgnoreHardwareEvents(!value);
            }
        }

        public event EventHandler<CardEventArgs> CardInserted;
        public event EventHandler<CardEventArgs> CardRemoved;
        public event EventHandler ReadersListChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the card events are traced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if trace card events; otherwise, <c>false</c>.
        /// </value>
        public bool TraceEvents
        {
            get { return traceEvents; }
            set
            {
                if (traceEvents != value)
                {
                    if (value)
                        StartEventsTracing();
                    else
                        StopEventsTracing();
                }
            }
        }

        /// <summary>
        /// Gets the reader count.
        /// </summary>
        public int ReaderCount
        {
            get
            {
                if (Active)
                {
                    return NativeMethods.GetReadersCount();
                }
                else
                    return 0;
            }
        }

        /// <summary>
        /// Reloads the readers list.
        /// </summary>
        public void ReloadReadersList()
        {
            if (Active)
            {
                StopEventsTracing();
                NativeMethods.ReloadReadersList();
                RetrieveReadersList();
            }
        }

        public bool SendAPDU(int readerNumber, byte[] apdu, int apduLen, byte[] result, ref int len)
        {
            CardReader reader = GetReader(readerNumber);
            if (reader == null)
                return false;

            Card card = reader.GetCard();
            if (card == null)
                return false;

            return NativeMethods.SendAPDU(readerNumber, apdu, apduLen, result, ref len);


        }

        /// <summary>
        /// Gets the name of the reader.
        /// </summary>
        /// <param name="readerNumber">The reader number.</param>
        /// <returns></returns>
        public string GetReaderName(int readerNumber)
        {
            if ((readerNumber < 0) || (readerNumber >= readers.Count))
                return null;
            else
                return readers[readerNumber].Name;
        }

        public CardReader GetReader(int readerNumber)
        {
            if ((readerNumber < 0) || (readerNumber >= readers.Count))
                return null;
            else
            {
                return readers[readerNumber];
            }
        }

        /// <summary>
        /// Gets the default card reader.
        /// </summary>
        /// <returns></returns>
        public CardReader GetReader()
        {
            CardReader result = GetReader(NativeMethods.GetSelectedReaderIndex());
            if (result == null)
                result = GetReader(0);
            return result;
        }

        /// <summary>
        /// Gets the reader.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public CardReader GetReader(string name)
        {
            int i = NativeMethods.GetReaderIndex(name);
            return GetReader(i);
        }

        /// <summary>
        /// Returns the array with the names of the attached card readers
        /// </summary>
        /// <returns></returns>
        public string[] ListReaders()
        {
            if (readers.Count > 0)
            {
                string[] result = new string[readers.Count];
                for (int i = 0; i < readers.Count; i++)
                    result[i] = readers[i].Name;
                return result;
            }
            else
                return null;
        }

        /// <summary>
        /// Sets the default card reader.
        /// </summary>
        /// <param name="readerNumber">The reader number.</param>
        public void SetDefaultReader(int readerNumber)
        {
            NativeMethods.SelectReader(readerNumber);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Manager"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active
        {
            get { return NativeMethods.IsEngineActive(); }
            set
            {
                ClearReadersList();
                if (value)
                {
                    NativeMethods.StartEngine();
                    RetrieveReadersList();
                }
                else
                    NativeMethods.StopEngine();
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            StopEventsTracing();
            NativeMethods.StopEngine();
            if (disposing)
            {
                ClearReadersList();
                InternalCallbackDelegate = null;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
