using System.Collections;
using zadanko.DTO;
using zadanko.Models;

namespace zadanko.Repositories;

public interface IReservationRepository
{
    public Task<ICollection<Reservation>> GetReservations(int idClient);

    public void AddReservation(ReservationDTO reservation);
}