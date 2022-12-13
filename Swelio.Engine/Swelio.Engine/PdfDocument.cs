using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swelio.Engine
{
    public class PdfDocument
    {
        private string fileName;
        private bool activated = false;
        

        public PdfDocument(string fileName)
        {
            this.fileName = fileName;
        }

        public bool Sign()
        {
            bool result = false;
            if (!NativeMethods.IsEngineActive())
            {
                NativeMethods.StartEngine();
                activated = true;
            }

            if (NativeMethods.ActivateCardEx(0))
            {
                result = NativeMethods.SignPdfFile(0, fileName);
            }

            if (activated)
            {
                NativeMethods.StartEngine();
            }

            return result;
        }
    }
}
