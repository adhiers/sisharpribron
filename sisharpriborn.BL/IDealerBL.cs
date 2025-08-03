using System;

namespace sisharpriborn.BL.DTO;

public interface IDealerBL
{
    IEnumerable<DealerDTO> GetDealers();
    DealerDTO GetById(string dealerId);
    DealerDTO AddDealer(DealerInsertDTO dealerDto);
    DealerDTO UpdateDealer(DealerUpdateDTO dealerDto);
    void DeleteDealer(string dealerId);
}
