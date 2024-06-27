using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDoBarbeiro.Core;
using AgendaDoBarbeiro.Core.Service;    

namespace AgendaDoBarbeiro.Service
{
    public class AddressService : IAddressService
    {
        private readonly AgendaDoBarbeiroContext _dbContext;
        public AddressService(AgendaDoBarbeiroContext dbContext) {
            _dbContext = dbContext;
        }

        public bool Delete(int AddressId)
        {
            Address? address = _dbContext.Addresses.FirstOrDefault(a => a.AddressId == AddressId);
            if (address == null) return false;
            _dbContext.Remove(address);
            _dbContext.SaveChanges();
            return true;
        }

        public Address? Get(int AddressId)
        {
            return _dbContext.Addresses.FirstOrDefault(a => a.AddressId == AddressId);
        }

        public bool Update(int AddressId, Address address)
        {
            throw new NotImplementedException();
        }
    }
}
