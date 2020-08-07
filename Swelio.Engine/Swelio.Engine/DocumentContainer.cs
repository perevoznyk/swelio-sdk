using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swelio.Engine
{
    /// <summary>
    /// ASIC document container. Associated Signature Containers (ASiC) 
    /// specifies the use of container structures to bind together one or more signed objects 
    /// with either advanced electronic signatures or timestamp tokens into one single digital container.
    /// </summary>
    public class DocumentContainer
    {
        private IntPtr ctx;

        /// <summary>Initializes a new instance of the <see cref="DocumentContainer" /> class.</summary>
        public DocumentContainer() : base()
        {
            ctx = NativeMethods.InitializeContainer();
        }

        /// <summary>Finalizes an instance of the <see cref="DocumentContainer" /> class.</summary>
        ~DocumentContainer()
        {
            Close();
        }

        /// <summary>Add file to the container</summary>
        /// <param name="fileName">The name of the file</param>
        public bool AddFile(string fileName)
        {
            return NativeMethods.AddFileToContainer(ctx, fileName);
        }

        /// <summary>Saves container to the file with specified file name.
        /// By default the file extension for ASIC containers is asice.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="readerNumber">The EID card reader number.</param>
        /// <returns>true, if success; otherwise - false.</returns>
        public bool Save(string fileName, int readerNumber)
        {
            return NativeMethods.SaveContainer(ctx, fileName);
        }

        /// <summary>Closes container. No any future calls are possible after closing container</summary>
        public void Close()
        {
            NativeMethods.FreeContainer(ctx);
        }

        /// <summary>Selects the certificate.</summary>
        /// <returns>True - if certificate is selected, otherwise - false</returns>
        public bool SelectCertificate()
        {
            return NativeMethods.ContainerPickCertificate(ctx);
        }

        /// <summary>Selects the certificate.</summary>
        /// <param name="readerNumber">The reader number.</param>
        /// <returns>True - if certificate is selected, otherwise - false</returns>
        public bool SelectCertificate(int readerNumber)
        {
            return NativeMethods.ContainerEidCertificate(ctx, readerNumber);
        }

        /// <summary>Selects the certificate.</summary>
        /// <param name="fileName">Name of the certificate file in pfx format</param>
        /// <param name="password">The password.</param>
        /// <returns>True - if certificate is selected, otherwise - false</returns>
        public bool SelectCertificate(string fileName, string password)
        {
            return NativeMethods.ContainerCertificate(ctx, fileName, password);
        }
    }
}
