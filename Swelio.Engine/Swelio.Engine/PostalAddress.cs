using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swelio.Engine
{
    public class PostalAddress
    {
        public string Street { get; }
        public string House { get; }
        public string Zip { get; }
        public string Municipality { get; }

        public PostalAddress (Address value)
        {
            string street = value.Street;
            string house = string.Empty;
            street = street.Trim();
            int idx = street.Length - 1;

            while (idx > 0)
            {
                if (street[idx] == ' ')
                    break;
                else
                    --idx;
            }

            if (idx > 1)
            {
                house = street.Substring(idx + 1, street.Length - idx - 1);
                if (house[0] == '/')
                {
                    house = house.Substring(1);
                }
                street = street.Substring(0, idx);
            }


            House = house;
            Municipality = value.Municipality;
            Zip = value.Zip;
            Street = street;
        }
    }
}
