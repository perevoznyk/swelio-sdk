using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swelio.Engine
{
    public static class Algorithm
    {
        public const byte RSASSA_PKCS1 = 0x01;
        public const byte RSASSA_PKCS1_SHA1 = 0x02;
        public const byte RSASSA_PKCS1_MD5 = 0x04;
        public const byte RSASSA_PKCS1_SHA256 = 0x08;
        public const byte RSASSA_PSS_SHA1 = 0x10;
        public const byte RSASSA_PSS_SHA256 = 0x20;

        public const byte ECDSA_SHA2_256 = 0x01;
        public const byte ECDSA_SHA2_384 = 0x02;
        public const byte ECDSA_SHA2_512 = 0x04;
        public const byte ECDSA_SHA3_256 = 0x08;
        public const byte ECDSA_SHA3_384 = 0x10;
        public const byte ECDSA_SHA3_512 = 0x20;
        public const byte ECDSA = 0x40;
    }
}
