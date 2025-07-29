using System;
using SampleASPMVCEF.Models; // Add this if Car is defined in Models namespace

namespace SampleASPMVCEF.DAL;

public interface ICar : ICrud<Car>
{
    
    IEnumerable<Car> GetByModel(string modelType);
}