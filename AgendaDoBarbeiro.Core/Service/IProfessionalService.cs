using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDoBarbeiro.Core.Service
{
    public interface IProfessionalService
    {
        public long Create(Professional professional);
        public void Update(Professional professional);
        public void Delete(long id);
        public Task<IEnumerable<Professional?>> GetAll();
        public Task<Professional?> Get(long id);
    }
}
