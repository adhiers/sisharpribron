using System;

namespace sisharpriborn.BL.DTO;

public class DealerUpdateDTO
{
    public string DealerId { get; set; }

    public string DealerName { get; set; }

    public string DealerAddress { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public int TaxRate { get; set; }
}
