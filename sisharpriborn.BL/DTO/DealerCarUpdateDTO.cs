using System;

namespace sisharpriborn.BL.DTO;

public class DealerCarUpdateDTO
{
    public string DealerCarId { get; set; }

    public string CarId { get; set; }

    public string DealerId { get; set; }

    public int? Stock { get; set; }

    public double DealerCarPrice { get; set; }

    // public virtual CarDTO Car { get; set; }

    // public virtual DealerDTO Dealer { get; set; }
}
