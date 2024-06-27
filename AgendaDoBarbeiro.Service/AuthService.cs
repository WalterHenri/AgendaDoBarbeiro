using AgendaDoBarbeiro.Core.Service;
using AgendaDoBarbeiro.Core;
using Microsoft.EntityFrameworkCore;


namespace AgendaDoBarbeiro.Service
{
    public class AuthService : IAuthService
    {
        private readonly AgendaDoBarbeiroContext _dbContext;
        public AuthService(AgendaDoBarbeiroContext dbContext)
        {
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
            var user = _dbContext.Users.Find(id);
            if (user != null)
                _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public async Task<User?> Get(long id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User?>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public void Update(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
