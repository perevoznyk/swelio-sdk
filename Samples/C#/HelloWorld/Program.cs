using System;
using System.Collections.Generic;
using System.Text;
using Swelio.Engine;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = null;

            Manager engine = new Manager();
            engine.Active = true;

            if (engine.ReaderCount == 0)
            {
                Console.WriteLine("No card reader detected");
                return;
            }

            Console.WriteLine("Available readers:");
            for (int i = 0; i < engine.ReaderCount; i++)
            {
                Console.WriteLine(engine.GetReaderName(i));
            }

            Console.WriteLine("Please insert ID card in the reader and press Enter");
            Console.ReadLine();
            CardReader reader = engine.GetReader(0);
            if (reader != null)
            {
                reader.ActivateCard();
                card = reader.GetCard();
                if (card != null)
                {
                    Identity identity = card.ReadIdentity();
                    if (identity != null)
                    {
                        Console.WriteLine("Welcome {0} {1}", identity.FirstName1, identity.Surname);
                    }

                    //string csv = card.Save(ExportFormat.Csv, FileEncoding.Unicode);
                    //Console.WriteLine(csv);
                }
                reader.DeactivateCard();
            }


            //Card insertion and removal test
            card = reader.GetCard();
            if (reader.CardPresent)
                card = reader.GetCard();

            Console.WriteLine("Please remove ID card from the reader and press Enter");
            Console.ReadLine();

            if (card.Inserted)
            {
                Console.WriteLine("The card is still inserted in the reader");
            }

            Console.WriteLine();
            byte[] md5sum = Encryption.GetMD5("message digest");
            for (byte j = 0; j < 16; j++)
            {
                Console.Write("{0:X2}", md5sum[j]);
            }
            Console.WriteLine();


            engine.Dispose();
            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();
        }
    }
}
