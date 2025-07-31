using System;
using System.ComponentModel.DataAnnotations; 

namespace SampleASPMVCEF.ViewModels;
    
public class DealerCarInsertViewModel
{
    public string DealerCarId { get; set; }
    public string CarId { get; set; }

    public string DealerId { get; set; }

    [Required(ErrorMessage = "Stock is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Stock must be greater than 0.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Dealer Car Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Dealer Car Price must be greater than 0.")]
    public decimal DealerCarPrice { get; set; }

    // [Required(ErrorMessage = "Model Type is required.")]
    // public string ModelType { get; set; }

    // [Required(ErrorMessage = "Dealer Name is required.")]
    // public string DealerName { get; set; }




}
