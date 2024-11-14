using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swelio.Engine
{
    /// <summary>
    /// The digital signature for PDF documents
    /// </summary>
    public class PdfDocument
    {
        private string fileName;
        private bool activated = false;
        private IntPtr ctx;
        private bool certificateSelected = false;


        /// <summary>
        /// Initializes a new instance of the <see cref="PdfDocument"/> class.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        public PdfDocument(string fileName)
        {
            this.fileName = fileName;
            ctx = NativeMethods.InitializeContainer();
        }

        ~PdfDocument()
        {
            Close();
        }
        /// <summary>Closes container. No any future calls are possible after closing container</summary>
        public void Close()
        {
            NativeMethods.FreeContainer(ctx);
            if (activated)
            {
                NativeMethods.StopEngine();
            }
        }

        /// <summary>Selects the certificate.</summary>
        /// <returns>True - if certificate is selected, otherwise - false</returns>
        public bool SelectCertificate()
        {
            certificateSelected = NativeMethods.ContainerPickCertificate(ctx);
            return certificateSelected;
        }

        /// <summary>Selects the certificate.</summary>
        /// <param name="readerNumber">The reader number.</param>
        /// <returns>True - if certificate is selected, otherwise - false</returns>
        public bool SelectCertificate(int readerNumber)
        {
            if (!NativeMethods.IsEngineActive())
            {
                NativeMethods.StartEngine();
                activated = true;
            }
            if (NativeMethods.ActivateCardEx(readerNumber))
            {
                certificateSelected = NativeMethods.ContainerEidCertificate(ctx, readerNumber);
            }
            else
            {
                certificateSelected = false;
               
            }
            return certificateSelected;
        }

        /// <summary>Selects the certificate.</summary>
        /// <param name="fileName">Name of the certificate file in pfx format</param>
        /// <param name="password">The password.</param>
        /// <returns>True - if certificate is selected, otherwise - false</returns>
        public bool SelectCertificate(string fileName, string password)
        {
            certificateSelected = NativeMethods.ContainerCertificate(ctx, fileName, password);
            return certificateSelected;
        }

        /// <summary>Sign PDF file using selected certificate</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool Sign()
        {
            if (certificateSelected)
            {
                return NativeMethods.SignPdfFileEx(ctx, fileName);
            }
            else
            {
                return false;
            }
        }
    }
}
