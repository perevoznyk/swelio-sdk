using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swelio.Engine
{
    public class DocumentContainer
    {
        private IntPtr ctx;

        public DocumentContainer() : base()
        {

        }

        ~DocumentContainer()
        {
            Close();
        }

        public bool AddFile(string fileName)
        {
            return false;
        }

        public bool Save(string fileName, int readerNumber)
        {
            return false;
        }

        public void Close()
        {

        }
    }
}
