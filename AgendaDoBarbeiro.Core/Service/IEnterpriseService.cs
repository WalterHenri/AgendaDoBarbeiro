
namespace AgendaDoBarbeiro.Core.Service
{
    public interface IEnterpriseService
    {
        Task<long> Create(Enterprise enterprise);
        bool Update(Enterprise enterprise);
        Task<bool> Delete(Enterprise enterprise);
        Task<Enterprise?> Get(long id);
        Task<IEnumerable<Enterprise>> GetAll();
    }
}

