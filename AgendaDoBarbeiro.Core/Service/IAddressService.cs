using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDoBarbeiro.Core.Service
{
    public interface IAddressService
    {
        Address Get(int AddressId);
        bool Delete(int AddressId);
        bool Update(int AddressId, Address address);

    }
}
