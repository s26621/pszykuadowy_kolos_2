using Microsoft.EntityFrameworkCore;
using zadanko.Context;
using zadanko.DTO;
using zadanko.Models;

namespace zadanko.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly BoatRentalDbContext _context;
    private readonly IClientRepository _clientRepository;

    public ReservationRepository(BoatRentalDbContext context, IClientRepository clientRepository)
    {
        _context = context;
        _clientRepository = clientRepository;
    }

    public async Task<ICollection<Reservation>> GetReservations(int idClient)
    {
        return await _context.Reservations
            .Where(x => x.IdClient == idClient)
            .OrderBy(x=>x.DateTo)
            .ToListAsync();
    }

    public async void AddReservation(ReservationDTO reservation)
    {
        (
            int IdClient, 
            DateOnly DateFrom, DateOnly DateTo, 
            int IdBoatStandard, 
            int NumOfBoats
            ) = reservation;

        if (await _clientRepository.DoesClientHaveActiveReservation(IdClient))
        {
            throw new Exception("Client already has an active reservation!");
        }
        
        // pomijam sprawdzanie liczby wolnych żaglówek
        // pomijam też liczenie ceny, bo to sie wiąże z tym wyżej
        // sztucznie robię pola
        int capacity = 20;
        int price = 1000;

        await _context.Reservations.AddAsync(new Reservation
        { 
            IdReservation = await GetNewId(),
            IdClient = IdClient,
            DateFrom = DateFrom,
            DateTo = DateTo,
            IdBoatStandard = IdBoatStandard,
            Capacity = capacity,
            NumofBoats = NumOfBoats,
            Fulfilled = 1,
            Price = price
        });
    }

    private async Task<int> GetNewId()
    {
        return await _context.Reservations.MaxAsync(x => x.IdReservation);
    }

    // już nie mam siły tego tak rozdzielać, a na kolosie pewnie nie będę miała czasu
    // nie wiem, jak sprawdzić liczbę wolnych żaglówek, pewnie na kolosie mogłabym się zaputać o to
//     private async Task<bool> SubstractNumberOfBoats(int id, int number)
//     {
//         
//     }
}