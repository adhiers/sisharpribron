using System;

namespace sisharpriborn.BL.DTO;

public class CarUpdateDTO
{
    public string CarId { get; set; }

    public string VIN { get; set; }

    public string ModelType { get; set; }

    public string FuelType { get; set; }

    public double BasePrice { get; set; }
}
