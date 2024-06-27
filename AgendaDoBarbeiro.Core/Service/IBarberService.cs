

namespace AgendaDoBarbeiro.Core.Service
{
    public interface IBarberService
    {
        Task<long> Create(BarberService barberService);
        Task<long> Update(BarberService barberService);
        Task<bool> Delete(BarberService barberService);
        Task<BarberService> Get(long id);
        Task<BarberService> GetAll(long IdBarber);

    }
}
