using System.Data.SqlTypes;

namespace zadanko.Models;

public class Reservation
{
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumofBoats { get; set; }
    // zakładam, że:
    //  0 - aktywna, 1 - zaakceptowana, 2 - odrzucona
    public byte Fulfilled { get; set; }
    public SqlMoney? Price { get; set; }
    public string? CancelReason { get; set; }
    
    public virtual Client Client { get; set; }
    public virtual BoatStandard BoatStandard { get; set; }
    public virtual ICollection<SailboatReservation> Sailboats { get; set; }
}