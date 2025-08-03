using System;
using sisharpriborn.BL.DTO;

namespace sisharpriborn.BL; 

public interface IDealerCarBL
{
    IEnumerable<DealerCarDTO> GetAllDealerCars();
    DealerCarDTO GetDealerCarById(string id);
    DealerCarDTO AddDealerCar(DealerCarInsertDTO a);   
    DealerCarDTO UpdateDealerCar(DealerCarUpdateDTO dealerCarUpdateDTO);
    void DeleteDealerCar(string id);
}
