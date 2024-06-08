using System.ComponentModel.DataAnnotations;

namespace zadanko.Models;

public class Client
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public string Pesel { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public int IdClientCategory { get; set; }

    public virtual ClientCategory ClientCategory { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}