using System;
using sisharpriborn.BL.DTO;
using sisharpriborn.BO;
using sisharpriborn.DAL;
using AutoMapper;

namespace sisharpriborn.BL;

public class DealerBL : IDealerBL
{
    private readonly IMapper _mapper;
    private readonly IDealer _dealerDAL;

    public DealerBL(IMapper mapper, IDealer dealerDAL)
    {
        _mapper = mapper;
        _dealerDAL = dealerDAL;
    }
    public DealerDTO AddDealer(DealerInsertDTO dealerInsertDTO)
    {
        try
        {
            var newDealer = _mapper.Map<Dealer>(dealerInsertDTO);
            _dealerDAL.Create(newDealer);
            var result = _mapper.Map<DealerDTO>(newDealer);
            return result;
        }
        catch (System.Exception ex)
        {
            throw new ArgumentException($"An error occurred while adding the dealer. {ex.Message}", ex);
        }
    }

    public void DeleteDealer(string dealerId)
    {
        try
        {
            _dealerDAL.Delete(dealerId);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"An error occurred while deleting the dealer. {ex.Message}", ex);
        }
    }

    public DealerDTO GetById(string dealerId)
    {
        var dealer = _dealerDAL.GetById(dealerId);
        if (dealer == null)
        {
            throw new ArgumentException($"Dealer with ID {dealerId} not found.");
        }
        var dealerDto = _mapper.Map<DealerDTO>(dealer);
        return dealerDto;
    }

    public IEnumerable<DealerDTO> GetDealers()
    {
        var dealers = _dealerDAL.GetAll();  
        var dealerDtos = _mapper.Map<IEnumerable<DealerDTO>>(dealers);
        if (dealerDtos == null)
        {
            throw new ArgumentException("No dealers found.");
        }
        return dealerDtos;
    }

    public DealerDTO UpdateDealer(DealerUpdateDTO dealerUpdateDto)
    {
        try
        {
            var editDealer = _mapper.Map<Dealer>(dealerUpdateDto);
            _dealerDAL.Update(editDealer);
            var result = _mapper.Map<DealerDTO>(editDealer);
            return result;
        }
        catch (Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            throw new ArgumentException($"An error occurred while updating the dealer. {ex.Message}", ex);
        }
    }
}
