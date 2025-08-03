using System;
using AutoMapper;
using sisharpriborn.BL.DTO;
using sisharpriborn.BO;
using sisharpriborn.DAL;

namespace sisharpriborn.BL;

public class DealerCarBL : IDealerCarBL
{
    private readonly IDealerCar _dealerCarDAL;
    private readonly IMapper _mapper;

    public DealerCarBL(IDealerCar dealerCarDAL, IMapper mapper)
    {
        _dealerCarDAL = dealerCarDAL;
        _mapper = mapper;
    }
    public DealerCarDTO AddDealerCar(DealerCarInsertDTO dealerCarInsertDTO)
    {
        try
        {
            var newDealerCar = _mapper.Map<DealerCarList>(dealerCarInsertDTO);
            var addedDealerCar = _dealerCarDAL.Create(newDealerCar);
            if (addedDealerCar == null)
            {
                throw new Exception("Failed to add dealer car list");
            }
            var dealerCarDTO = _mapper.Map<DealerCarDTO>(addedDealerCar);
            return dealerCarDTO;    
        }
        catch (ArgumentException aEx)
        {
            throw new ArgumentException(aEx.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding the dealer car.", ex);
        } 
    }

    public void DeleteDealerCar(string id)
    {
        try
        {
            _dealerCarDAL.Delete(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public DealerCarDTO GetDealerCarById(string id)
    {
        var dealerCar = _dealerCarDAL.GetById(id);
        if (dealerCar == null)
        {
            throw new ArgumentException($"Dealer with ID {id} not found.");
        }
        var dealerCarDTO = _mapper.Map<DealerCarDTO>(dealerCar);
        return dealerCarDTO;
    }

    public IEnumerable<DealerCarDTO> GetAllDealerCars()
    {
        var dealerCars = _dealerCarDAL.GetAll();
        var dealerCarDTOs = _mapper.Map<IEnumerable<DealerCarDTO>>(dealerCars);
        return dealerCarDTOs;
    }

    public DealerCarDTO UpdateDealerCar(DealerCarUpdateDTO dealerCarUpdateDTO)
    {
        try
        {
            var updateDealerCar = _mapper.Map<DealerCarList>(dealerCarUpdateDTO);
            var updatedDealerCar = _dealerCarDAL.Update(updateDealerCar);
            if (updatedDealerCar == null)
            {
                throw new Exception("Failed to update the dealer car.");
            }
            var dealerCarDTO = _mapper.Map<DealerCarDTO>(updatedDealerCar);
            return dealerCarDTO;
        }
        catch (Exception e)
        {
            throw new(e.Message);
        }
    }
}
