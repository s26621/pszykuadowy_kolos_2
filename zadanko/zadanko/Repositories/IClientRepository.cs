using zadanko.DTO;
using zadanko.Models;

namespace zadanko.Repositories;

public interface IClientRepository
{
    public Task<ClientDTO> GetClient(int id);
    public Task<bool> DoesClientHaveActiveReservation(int id);
    
}