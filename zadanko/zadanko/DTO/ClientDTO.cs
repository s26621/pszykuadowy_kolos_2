using System.Collections;
using zadanko.Models;

namespace zadanko.DTO;

public record ClientDTO(
    int IdClient,
    string Name,
    string LastName,
    DateOnly Birthday,
    string Pesel,
    string Email,
    int IdClientCategory,
    ICollection<Reservation> Reservations
    );