using Swelio.Engine;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Signature
{
    class Program
    {
        static void Main(string[] args)
        {
            Swelio.Engine.Manager engine = new  Manager();
            engine.Active = true;

            using (CardReader reader = engine.GetReader())
            {
                if (reader != null)
                {
                    using (Card card = reader.GetCard(true))
                    {
                        if (card != null)
                        {
                            var guid = Guid.NewGuid();
                            var guidData = guid.ToByteArray();
                            using (SHA256Managed sha256 = new SHA256Managed())
                            {
                                var sha256hash = sha256.ComputeHash(guidData);
                                var encryptedData = Encryption.GenerateNonRepudiationSignature(reader, "1234", sha256hash, sha256hash.Length);

                                if (encryptedData != null)
                                {
                                    Console.WriteLine("Signed data: " + Convert.ToBase64String(encryptedData, Base64FormattingOptions.None) + Environment.NewLine);
                                }
                                else
                                {
                                    Console.WriteLine("Could not sign data");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
