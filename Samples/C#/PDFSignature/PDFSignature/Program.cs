using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swelio.Engine;

namespace PDFSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument pdf = new PdfDocument(args[0]);
            Manager manager = new Manager();
            manager.Active = true;
            manager.GetReader(0).ActivateCard();
            pdf.SelectCertificate(0);
            pdf.Sign();
            pdf.Close();
            manager.Active = false;
        }
    }
}
