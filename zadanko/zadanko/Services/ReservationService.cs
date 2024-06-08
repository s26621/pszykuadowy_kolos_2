using zadanko.DTO;
using zadanko.Repositories;

namespace zadanko.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public void AddReservation(ReservationDTO reservationDto)
    {
        if (reservationDto.DateFrom < reservationDto.DateTo)
        {
            throw new Exception("Incorrect date");
        }

        _reservationRepository.AddReservation(reservationDto);
    }
}