using System;
using SampleASPMVC.Models;

namespace SampleASPMVC.Services;

public interface ICar : ICrud<Car>
{
    IEnumerable<Car> GetByModel(string modelType);
    
}
