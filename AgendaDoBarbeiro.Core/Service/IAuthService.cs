using AgendaDoBarbeiro.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDoBarbeiro.Core.Service
{
    public interface IAuthService
    {
        public long Create(User user);
        public void Update(User user);
        public void Delete(long id);
        public Task<IEnumerable<User>> GetAll();
        public Task<User> Get(long id);
    }
}
