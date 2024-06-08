using zadanko.DTO;

namespace zadanko.Services;

public interface IReservationService
{
    public void AddReservation(ReservationDTO reservationDto);
}