using AgendaDoBarbeiro.Core;
using AgendaDoBarbeiro.Core.Dtos;
using AgendaDoBarbeiro.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace AgendaDoBarbeiro.Service
{
    public class AuthService : IAuthService
    {
        private readonly AgendaDoBarbeiroContext _dbContext;
        public AuthService(AgendaDoBarbeiroContext dbContext) { 
            _dbContext = dbContext; 
        }
        

        public long Create(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user.UserId;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
