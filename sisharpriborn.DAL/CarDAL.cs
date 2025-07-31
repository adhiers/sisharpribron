using System;
using Microsoft.EntityFrameworkCore;
using sisharpriborn.BO;

namespace sisharpriborn.DAL;

public class CarDAL : ICar
{
    private readonly FinalProjectContext _context;
    public CarDAL(FinalProjectContext context)
    {
        _context = context;
    }
    public IEnumerable<Car> GetByModel(string modelType)
    {
        try
        {
            // var cars = from c in _context.Car
            //            where c.ModelType.Contains(modelType) || c.FuelType.Contains(modelType)
            //            select c;
            var results = _context.Cars
                .Where(c => c.ModelType.Contains(modelType) || c.FuelType.Contains(modelType))
                .OrderBy(c => c.CarId).ToList();
            return results;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving cars by model: {ex.Message}");
        }
    }

    public Car Create(Car item)
    {
        try
        {
            _context.Cars.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating car: {ex.Message}");
        }
    }

    public Car GetById(string id)
    {
       var result = _context.Cars.Where(c => c.CarId == id).FirstOrDefault();
        if (result == null)
        {
            throw new Exception("Car not found");
        }
        return result;
    }

    public Car Update(Car item)
    {
        var result = GetById(item.CarId);
        if (result == null)
        {
            throw new Exception("Car not found");
        }
        try
        {
            _context.Entry(result).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating car: {ex.Message}");
        }
    }

    public void Delete(string id)
    {
        var car = GetById(id);
        if (car == null)
        {
            throw new Exception("Car not found");
        }
        try
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting car: {ex.Message}");
        }
    }

    public IEnumerable<Car> GetAll()
    {
        // List<Car> cars = _context.Car.ToList();
        var cars = from c in _context.Cars orderby c.CarId ascending select c;
        return cars;
    }

}
