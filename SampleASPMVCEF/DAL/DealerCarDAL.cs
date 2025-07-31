using System;
using Microsoft.EntityFrameworkCore;
using SampleASPMVCEF.Models; // Add this if DealerCarList is in the Models namespace

namespace SampleASPMVCEF.DAL;

public class DealerCarDAL : IDealerCar
{
    private readonly FinalProjectContext _context;

    public DealerCarDAL(FinalProjectContext context)
    {
        _context = context;
    }
    public DealerCarList Create(DealerCarList entity)
    {
        try
        {
            _context.DealerCarLists.Add(entity);
            _context.SaveChanges();
            return entity;  
        }
        catch (ArgumentNullException ex)
        {
            throw new Exception($"Error creating dealer car: {ex.Message}");
        }
        
    }
    
    public DealerCarList GetById(string id)
    {
        var result = _context.DealerCarLists
            .Include(dc => dc.Car) // Assuming DealerCarList has a navigation property to Car
            .Include(dc => dc.Dealer) // Assuming DealerCarList has a navigation property to Dealer
            .FirstOrDefault(dc => dc.DealerCarId == id);
        
        if (result == null)
        {
            throw new Exception("Dealer car not found");
        }
        return result;
    }
    public DealerCarList Update(DealerCarList entity)
    {
        try
        { 
            var existingEntity = GetById(entity.DealerCarId);
            if (existingEntity == null)
            {
                throw new Exception("Dealer car not found");
            }
            existingEntity.CarId = entity.CarId;
            existingEntity.DealerId = entity.DealerId;
            existingEntity.Stock = entity.Stock;
            existingEntity.DealerCarPrice = entity.DealerCarPrice;

            _context.SaveChanges(); 
            return existingEntity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating dealer car: {ex.Message}");
        }
    }

    public void Delete(string id)
    {
        try
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new Exception("Dealer car not found");
            }
            _context.DealerCarLists.Remove(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting dealer car: {ex.Message}");
        }
    }

    public IEnumerable<DealerCarList> GetAll()
    {
        var results = _context.DealerCarLists
            .Include(dc => dc.Car) // Assuming DealerCarList has a navigation property to Car
            .Include(dc => dc.Dealer) // Assuming DealerCarList has a navigation property to Dealer
            .AsNoTracking().ToList();
        return results;
    }
}
