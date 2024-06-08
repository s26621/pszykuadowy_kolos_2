using System.Collections;

namespace zadanko.Models;

public class ClientCategory
{
    public int IdClientCatherogy { get; set; }
    public string Name { get; set; }
    public int DiscountPerc { get; set;}
    
    public virtual ICollection<Client> Clients { get; set; }
}