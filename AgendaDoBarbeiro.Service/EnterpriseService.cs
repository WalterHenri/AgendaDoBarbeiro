using AgendaDoBarbeiro.Core;
using AgendaDoBarbeiro.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace AgendaDoBarbeiro.Service
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly AgendaDoBarbeiroContext _dbContext;

        public EnterpriseService(AgendaDoBarbeiroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Create(Enterprise enterprise)
        {
            _dbContext.Add(enterprise);
            await _dbContext.SaveChangesAsync();
            return enterprise.EnterpriseId;
        }

        public async Task<bool> Delete(Enterprise enterprise)
        {
            try
            {
                _dbContext.Remove(enterprise);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<Enterprise?> Get(long id)
        {
            return await _dbContext.Enterprises.FindAsync(id);
        }

        public async Task<IEnumerable<Enterprise>> GetAll()
        {
            return await _dbContext.Enterprises.ToListAsync();
        }

        public bool Update(Enterprise enterprise)
        {
            try
            {
                _dbContext.Update(enterprise);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }
    }
}
