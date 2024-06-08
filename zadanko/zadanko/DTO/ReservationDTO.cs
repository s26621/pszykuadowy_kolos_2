namespace zadanko.DTO;

public record ReservationDTO(
    int IdClient,
    DateOnly DateFrom,
    DateOnly DateTo,
    int IdBoatStandard,
    int NumOfBoats
    );