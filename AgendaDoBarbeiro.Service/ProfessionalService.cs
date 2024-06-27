using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDoBarbeiro.Core.Service;
using AgendaDoBarbeiro.Core;
using Microsoft.EntityFrameworkCore;


namespace AgendaDoBarbeiro.Service
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly AgendaDoBarbeiroContext _dbContext;
        public ProfessionalService(AgendaDoBarbeiroContext dbContext) {
            _dbContext = dbContext;
        }

        public long Create(Professional professional)
        {
            _dbContext.Professionals.Add(professional);
            _dbContext.SaveChanges();
            return professional.ProfessionalId;

        }

        public void Delete(long id)
        {
            var user = _dbContext.Professionals.Find(id);
            if (user != null)
                _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public async Task<Professional?> Get(long id)
        {
            return await _dbContext.Professionals.FindAsync(id);
        }

        public async Task<IEnumerable<Professional?>> GetAll()
        {
            return await _dbContext.Professionals.ToListAsync();
        }

        public void Update(Professional professional)
        {
            _dbContext.Update(professional);
            _dbContext.SaveChanges();
        }
    }
}
