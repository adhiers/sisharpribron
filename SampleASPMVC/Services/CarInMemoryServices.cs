using System;
using SampleASPMVC.Models;

namespace SampleASPMVC.Services;

public class CarInMemoryServices : ICar
{
    private List<Car> cars = new List<Car>();

    public CarInMemoryServices()
    {
        cars.Add(new Car { CarId = "CAR001", VIN = "1HGCM82633A123456", ModelType = "Xpander Cross", FuelType = "Gasoline", BasePrice = 500000000 });
        cars.Add(new Car { CarId = "CAR002", VIN = "1HGCM82633A123457", ModelType = "Avanza", FuelType = "Diesel", BasePrice = 300000000 });
        cars.Add(new Car { CarId = "CAR003", VIN = "1HGCM82633A123458", ModelType = "Innova", FuelType = "Gasoline", BasePrice = 600000000 });
        cars.Add(new Car { CarId = "CAR004", VIN = "1HGCM82633A123459", ModelType = "Fortuner", FuelType = "Diesel", BasePrice = 800000000 });
        cars.Add(new Car { CarId = "CAR005", VIN = "1HGCM82633A123460", ModelType = "Pajero Sport", FuelType = "Diesel", BasePrice = 900000000 });
    }

    public Car Create(Car item)
    {

        cars.Add(item);
        return item;
    }

    public Car Read(string carId)
    {
        // var car = cars.FirstOrDefault(c => c.CarId == carId);
        var car = (from c in cars
                   where c.CarId == carId
                   select c).FirstOrDefault();
        if (car == null)
        {
            throw new KeyNotFoundException($"Car with ID {carId} not found.");
        }
        return car;
    }

    public Car Update(Car item)
    {
        var result = Read(item.CarId);
        result.VIN = item.VIN;
        result.ModelType = item.ModelType;
        result.FuelType = item.FuelType;
        result.BasePrice = item.BasePrice;

        return result;
    }

    public void Delete(string carId)
    {
        var car = Read(carId);
        cars.Remove(car);
    }

    public IEnumerable<Car> GetAll()
    {
        return cars;
    }

    public IEnumerable<Car> GetByModel(string model)
    {
        // return cars.Where(c => c.ModelType.Contains(model, StringComparison.OrdinalIgnoreCase));
        var cars = this.cars.Where(c => c.ModelType.ToLower().Contains(model.ToLower()) || c.FuelType.ToLower().Contains(model.ToLower()));
        return cars;
    }

    // public IEnumerable<Car> GetByFuelType(string fuelType)
    // {
    //     return cars.Where(c => c.FuelType.Equals(fuelType, StringComparison.OrdinalIgnoreCase));
    // }
        
}
