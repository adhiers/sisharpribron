using System;

namespace SampleASPMVCEF.ViewModels;

public class DealerCarViewModel
{
    public required string DealerCarId { get; set; } 
    public required string CarId { get; set; }
    public required string DealerId { get; set; }
    public required int Stock { get; set; }
    public required decimal DealerCarPrice { get; set; }
    public required string DealerName { get; set; }
    public required string ModelType { get; set; }
}
