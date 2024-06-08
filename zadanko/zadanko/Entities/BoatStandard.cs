using System.Collections;

namespace zadanko.Models;

public class BoatStandard
{
    public int IdBoatStandard { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    
    public virtual ICollection<Sailboat> Sailboats {get; set;}
    public virtual ICollection<Reservation> Reservations { get; set; }
}