using System.Collections;
using Microsoft.EntityFrameworkCore;
using zadanko.Context;
using zadanko.DTO;
using zadanko.Models;

namespace zadanko.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly BoatRentalDbContext _context;
    private readonly IReservationRepository _reservationRepository;

    public ClientRepository(BoatRentalDbContext context, IReservationRepository reservationRepository)
    {
        _context = context;
        _reservationRepository = reservationRepository;
    }

    public async Task<ClientDTO> GetClient(int id)
    {
        Client? client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            throw new NullReferenceException("Client with id " + id + " doesn't exist!");
        }

        ICollection<Reservation> reservations = await _reservationRepository.GetReservations(id);
        return new ClientDTO(client.IdClient, client.Name, client.LastName, client.Birthday,
            client.Pesel, client.Email, client.IdClientCategory, reservations);
    }

    

    public async Task<bool> DoesClientHaveActiveReservation(int id)
    {
        Client? client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            throw new NullReferenceException("There is no client with id " + id + "!");
        }

        return client.Reservations.Count(x => x.Fulfilled == 0) > 0;
    }
}