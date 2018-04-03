using System;
using System.Collections.Generic;
using System.Text;
using Swelio.Engine;

namespace PhotoMimeEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            Swelio.Engine.Manager cardManager = new Manager();
            cardManager.Active = true;
            if (cardManager.ReaderCount > 0)
            {
                CardReader reader = cardManager.GetReader(0);
                if (reader != null)
                {
                    Card card = reader.GetCard();
                    if (card != null)
                    {
                        byte[] tempBytes = card.EncodePhoto();
                        string imageAsString = Encoding.UTF8.GetString(tempBytes);
                        Console.WriteLine(imageAsString);
                    }
                }
            
            }
        }
    }
}
