using System;
using sisharpriborn.BO;

namespace sisharpriborn.DAL;

public interface ICar : ICrud<Car>
{
    
    IEnumerable<Car> GetByModel(string modelType);
    // object GetCarById(string carId);
}