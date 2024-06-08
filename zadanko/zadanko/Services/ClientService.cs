using zadanko.DTO;
using zadanko.Repositories;

namespace zadanko.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClientDTO> GetClient(int id)
    {
        return await _repository.GetClient(id);
    }
}