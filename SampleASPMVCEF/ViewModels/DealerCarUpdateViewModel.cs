using System;
using System.ComponentModel.DataAnnotations;

namespace SampleASPMVCEF.ViewModels;

public class DealerCarUpdateViewModel
{
    public string DealerCarId { get; set; }
    public string CarId { get; set; }
    public string DealerId { get; set; }
    
    [Required(ErrorMessage = "Stock is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer")]
    [Display(Name = "Stock")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "Dealer Car Price is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Dealer Car Price must be a positive number")]
    public double DealerCarPrice { get; set; }
}
