using zadanko.DTO;

namespace zadanko.Services;

public interface IClientService
{
    public Task<ClientDTO> GetClient(int id);
}