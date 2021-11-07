using BaseLogic.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLogic.Tests
{
    public class AddressFactory
    {
        public static Address GenerateNewAddress(int id)
        {
            return new Address() { City = $"GeneratedCity{id}", Street = $"GeneratedStreet{id}" };
        }

        public static Address GenerateAddressForType(int id,string fieldName)
        {
            return new Address() { City = $"{fieldName}City{id}", Street = $"{fieldName}Street{id}" };
        }
    }
}
