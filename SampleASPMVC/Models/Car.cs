using System;

namespace SampleASPMVC.Models;

public class Car
{
    public string CarId { get; set; } = null!;
    public string VIN { get; set; } = null!;
    public string ModelType { get; set; } = null!;
    public string FuelType { get; set; } = null!;
    public double BasePrice { get; set; } = 0.0;
}
