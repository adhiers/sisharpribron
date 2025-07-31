using System;
using sisharpriborn.BL.DTO;
using sisharpriborn.DAL;
using sisharpriborn.BO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace sisharpriborn.BL;

public class CarBL : ICarBL
{
    private readonly ICar _carDAL;
    public CarBL(ICar carDAL)
    {
        _carDAL = carDAL;
    }

    public CarDTO AddCar(CarInsertDTO carInsertDto)
    {
        try
        {
            var car = new Car
            {
                CarId = carInsertDto.CarId,
                VIN = carInsertDto.VIN,
                ModelType = carInsertDto.ModelType,
                FuelType = carInsertDto.FuelType,
                BasePrice = carInsertDto.BasePrice
            };

            var addedCar = _carDAL.Create(car);
            return new CarDTO
            {
                CarId = car.CarId,
                VIN = car.VIN,
                ModelType = car.ModelType,
                FuelType = car.FuelType,
                BasePrice = car.BasePrice
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding car", ex);
        }
    }

    public void DeleteCar(string carId)
    {
        try
        {
            var car = _carDAL.GetById(carId);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            _carDAL.Delete(car.CarId);  
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting car with ID {carId}: {ex.Message}");
        }
    }

    public CarDTO GetById(string carId)
    {
        var car = _carDAL.GetById(carId);
        if (car == null)
        {
            throw new Exception("Car not found");
        }
        return new CarDTO
        {
            CarId = car.CarId,
            VIN = car.VIN,
            ModelType = car.ModelType,
            FuelType = car.FuelType,
            BasePrice = car.BasePrice,
        };
    }

    public IEnumerable<CarDTO> GetCars()
    {
        var carDTOS = new List<CarDTO>();
        var cars = _carDAL.GetAll(); // Assuming you want all cars
        foreach (var car in cars)
        {
            carDTOS.Add(new CarDTO
            {
                CarId = car.CarId,
                VIN = car.VIN,
                ModelType = car.ModelType,
                FuelType = car.FuelType,
                BasePrice = car.BasePrice,
            });
        }
        return carDTOS;
    }

    public IEnumerable<CarDTO> GetCarsBySearch(string search)
    {
        var carDTOS = new List<CarDTO>();
        var cars = _carDAL.GetByModel(search);  
        foreach (var car in cars)
        {
            carDTOS.Add(new CarDTO
            {
                CarId = car.CarId,
                VIN = car.VIN,
                ModelType = car.ModelType,
                FuelType = car.FuelType,
                BasePrice = car.BasePrice,
            });
        }
        return carDTOS;
    }   

    public CarDTO UpdateCar(CarUpdateDTO carUpdateDto)
    {
        try
        {
            var car = _carDAL.GetById(carUpdateDto.CarId);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            car.VIN = carUpdateDto.VIN;
            car.ModelType = carUpdateDto.ModelType;
            car.FuelType = carUpdateDto.FuelType;
            car.BasePrice = carUpdateDto.BasePrice;
            var updatedCar = _carDAL.Update(car);

            return new CarDTO   
            {   
                CarId = updatedCar.CarId,
                VIN = updatedCar.VIN,
                ModelType = updatedCar.ModelType,
                FuelType = updatedCar.FuelType,
                BasePrice = updatedCar.BasePrice
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating car with ID {carUpdateDto.CarId}: {ex.Message}");
        }
    }
}
